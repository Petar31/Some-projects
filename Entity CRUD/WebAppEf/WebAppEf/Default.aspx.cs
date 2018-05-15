using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebAppEf
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


            using (var ctx = new Database1Entities())
            {

                var query = from que in ctx.Employees select que;
                int num = 1;
                //for (int i = 0; i < query.Count(); i++)
                foreach (var item in query)

                {

                    TableRow tr = new TableRow();


                    TableCell tableCell0 = new TableCell();
                    tableCell0.Text = num.ToString();
                    tr.Cells.Add(tableCell0);
                    num++;

                    TableCell tableCell1 = new TableCell();
                    tableCell1.Text = item.FirstName;
                    tr.Cells.Add(tableCell1);


                    TableCell tableCell2 = new TableCell();
                    tableCell2.Text = item.LastName;
                    tr.Cells.Add(tableCell2);

                    TableCell tableCellB = new TableCell();
                    tableCellB.Text = item.BirthDate.Value.ToShortDateString();
                    tr.Cells.Add(tableCellB);

                    Button button1 = new Button();
                    button1.CssClass = "btn btn-danger";
                    button1.Text = "Delete";

                    button1.Click += (s, e1) => { BtnDelete_Click(item.EmployeeID); };

                    TableCell tableCell3 = new TableCell();
                    tableCell3.Controls.Add(button1);
                    tr.Cells.Add(tableCell3);

                    Button button2 = new Button()
                    {
                        Text = "Edit",
                        //OnClientClick = "return Update();"

                    };
                    button2.CssClass = "btn btn-success";
                    button2.Click += (s1, e2) => { Edit(item.EmployeeID, item.FirstName, item.LastName, item.BirthDate.Value); };

                    TableCell tableCell4 = new TableCell();
                    tableCell4.Controls.Add(button2);
                    tr.Cells.Add(tableCell4);


                    Table1.Rows.Add(tr);

                }


            }

        }


        private bool Validation(TextBox tbFName, TextBox tbLName, HtmlInputGenericControl birthDate)
        {
            if (string.IsNullOrWhiteSpace(tbFName.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please enter First Name value');", true);
                tbFName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbLName.Text))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please enter Last Name value');", true);
                tbLName.Focus();
                return false;

            }
            if (string.IsNullOrWhiteSpace(birthDate.Value))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Please enter Date of birth ');", true);
                return false;
            }
            return true;

        }

        private void Edit(int employeeID, string firstName, string lastName, DateTime birthDate)
        {
            LabelHide.Text = employeeID.ToString();
            TextBox4.Text = firstName;

            TextBox5.Text = lastName;
            Date1.Value = birthDate.Year + "-" +birthDate.ToString("MM").PadLeft(2, '0') + "-"+ birthDate.ToString("dd").PadLeft(2,'0') ;
            Page.SetFocus(TextBox4.ClientID);

            divForm2.Visible = true;
        }



        private void BtnDelete_Click(int id)
        {

           
                using (var ctx = new Database1Entities())

                {
                    var query = (from que in ctx.Employees where que.EmployeeID == id select que).FirstOrDefault();
                    ctx.Employees.Remove(query);
                    ctx.SaveChanges();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            


        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (! Validation( TextBox1, TextBox2, calendar))
            {
                return;
            }

            Employee employee1 = new Employee()
            {
                FirstName = TextBox1.Text,
                LastName = TextBox2.Text,
                BirthDate = DateTime.ParseExact(calendar.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)

        };

            //DateTime dateTime = DateTime.ParseExact(calendar.Value, "yyyy-MM-dd HH:mm:ss,fff",System.Globalization.CultureInfo.InvariantCulture);

            using (var ctx = new Database1Entities())
            {
                ctx.Employees.Add(employee1);
                ctx.SaveChanges();
            }
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;

            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (!Validation(TextBox4, TextBox5, Date1))
            {
                return;
            }

            using (var ctx = new Database1Entities())
            {
                int id = int.Parse(LabelHide.Text);
                var query = (from quer in ctx.Employees where quer.EmployeeID == id select quer).FirstOrDefault();

                query.FirstName = TextBox4.Text;
                query.LastName = TextBox5.Text;
                query.BirthDate = DateTime.ParseExact(Date1.Value, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                ctx.SaveChanges();

            }
            Response.Redirect(Request.Url.AbsoluteUri);

        }
    }
}