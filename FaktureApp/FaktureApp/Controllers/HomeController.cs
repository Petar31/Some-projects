using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FaktureApp.Models.Fakture;

namespace FaktureApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FakturaContext _context;

        public HomeController(FakturaContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index(string str)
        {
            if (str != null)
            {
                ViewBag.Message = str;
            }
            return View(await _context.Fakture.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktura = await _context.Fakture
                .SingleOrDefaultAsync(m => m.BrojDokumenta == id);
            if (faktura == null)
            {
                return NotFound();
            }

            return View(faktura);
        }

        // GET: Home/Create
        public IActionResult Create(string str)
        {
            ViewBag.Message = str;
            ViewBag.BrojFakture = _context.Fakture;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojFakture,DatumDokumenta,Ukupno")] Faktura faktura)
        {
            string poruka;
            if (ModelState.IsValid)
            {
                faktura.Ukupno = 0;
                _context.Add(faktura);
                await _context.SaveChangesAsync();
                poruka = $"Uspesno ste dodali fakturu {faktura.BrojFakture}";
                return RedirectToAction("Index", new { str= poruka});
            }
            else
            {
                poruka = "Neispravni podaci";
            }

            ViewBag.BrojFakture = _context.Fakture;
            return View("Create");
        }



        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
             
                var faktura = await _context.Fakture.SingleOrDefaultAsync(m => m.BrojDokumenta == id);
                return View(faktura);
            }
            catch (Exception ex)
            {

                ViewBag.Poruka = ex.Message;
                return View("Index");
            }

            
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("BrojDokumenta, BrojFakture,DatumDokumenta,Ukupno")] Faktura faktura)
        {
            if (ModelState.IsValid)
            {
                _context.Update(faktura);
                await _context.SaveChangesAsync();
                string poruka = $"Uspesno ste izmenili fakturu {faktura.BrojFakture}";
                return RedirectToAction("Index", new { str = poruka });
            }
            else
            {
                ViewBag.Error = "Greska pri izmeni";
                return View();
            }
        
              
              
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(string id)
        {

            try
            {
                var faktura = await _context.Fakture
               .SingleOrDefaultAsync(m => m.BrojDokumenta == id);
                    return View(faktura);
            }
            catch (Exception ex)
            {

                ViewBag.Poruka = ex.Message;
                return View("Index");
            }

           
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            IQueryable<Stavka> stavke = _context.Stavke.Where(x => x.BrojDokumenta == id);
            foreach (var item in stavke)
            {
                _context.Stavke.Remove(item);
            }

            var faktura = await _context.Fakture.SingleOrDefaultAsync(m => m.BrojDokumenta == id);
            _context.Fakture.Remove(faktura);
            await _context.SaveChangesAsync();

            string poruka = $"Uspesno ste obrisali fakturu {faktura.BrojFakture}";
            return RedirectToAction("Index", new { str = poruka });
        }

        private bool FakturaExists(string id)
        {
            return _context.Fakture.Any(e => e.BrojDokumenta == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewItem([Bind("BrojDokumenta,Kolicina,Cena")] Stavka stavka)
        {
            string poruka;
            if (ModelState.IsValid)
            {
                stavka.Ukupno = stavka.Kolicina * stavka.Cena;

                Faktura faktura = _context.Fakture.SingleOrDefault(x => x.BrojDokumenta == stavka.BrojDokumenta);
                if (faktura != null)
                {
                    faktura.Ukupno += stavka.Ukupno;
                }

                _context.Add(stavka);
                _context.Update(faktura);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                poruka = $"Uspesno ste dodali stavku u {faktura.BrojFakture}";
                

            }
            else
            {
                poruka = "Doslo je do greske";
                
            }
            return RedirectToAction("Create", new { str = poruka });

        }


        public PartialViewResult _FindItems(string select)
        {
            IQueryable<Stavka> stavke = _context.Stavke.Where(x => x.BrojDokumenta == select);
            return PartialView(stavke);
        }

        public PartialViewResult _NewItem()
        {
            ViewBag.BrojFakture = _context.Fakture;
            return PartialView();
        }

       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(int id, string fak)
        {
            string poruka;
          
            try
            {
                Stavka stavka = _context.Stavke.Include(s=>s.Faktura).SingleOrDefault(x => x.RedniBroj == id && x.BrojDokumenta == fak);
                Faktura faktura = _context.Fakture.SingleOrDefault(x => x.BrojDokumenta == stavka.BrojDokumenta);
                faktura.Ukupno = faktura.Ukupno - stavka.Ukupno;

                _context.Stavke.Remove(stavka);
                _context.Fakture.Update(faktura);
               await _context.SaveChangesAsync();
                poruka = $"Uspesno ste obrisali stavku iz fakture {stavka.Faktura.BrojFakture}";
               

            }
            catch (Exception ex)
            {

                poruka = ex.Message;
                

            }
            return RedirectToAction("Create", new { str = poruka });
        }

        public PartialViewResult _ChangeItem(int id, string fak)
        {

            Stavka stavka = _context.Stavke.SingleOrDefault(x => x.RedniBroj == id && x.BrojDokumenta == fak);

            return PartialView(stavka);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeItem([Bind("BrojDokumenta,RedniBroj,Kolicina,Cena")] Stavka stavka)
        {
           
            if (ModelState.IsValid)
            {
                stavka.Ukupno = stavka.Cena * stavka.Kolicina;
                _context.Update(stavka);
                await _context.SaveChangesAsync();
                Faktura faktura = _context.Fakture.SingleOrDefault(x => x.BrojDokumenta == stavka.BrojDokumenta);
                IQueryable<Stavka> stavke = _context.Stavke.Where(x => x.BrojDokumenta == stavka.BrojDokumenta);
                faktura.Ukupno = stavke.Sum(x => x.Ukupno);
                _context.Update(faktura);
                await _context.SaveChangesAsync();
              
                //ViewBag.BrojFakture = _context.Fakture;
                ViewBag.Message = $"Uspesno ste izmenili stavku {stavka.RedniBroj}";
                return PartialView("_Message");
            }
            else
            {
                return PartialView("_ChangeItem", stavka);
            }


            

            


        }
    }
}
