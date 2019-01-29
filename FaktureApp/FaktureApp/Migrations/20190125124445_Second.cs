using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Sql;

namespace FaktureApp.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var str = @"CREATE TRIGGER Trg1

  ON[dbo].[Stavka]

    instead of INSERT
    AS

    declare @sid int
    declare @iid varchar(450)
    declare @kol float
    declare @cena float
    declare @ukupno float
    

	select @iid = BrojDokumenta from inserted
    select @kol = Kolicina from inserted
    select @cena = Cena from inserted
   select @ukupno = Ukupno from inserted


    if not exists(select * from Stavka where BrojDokumenta = @iid) set @sid = 1
	else set @sid = (select max(F.RedniBroj) + 1 from Stavka as F where F.BrojDokumenta = @iid )

	insert into Stavka values(@sid, @iid, @cena, @kol, @ukupno)";

            migrationBuilder.Sql(str);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
