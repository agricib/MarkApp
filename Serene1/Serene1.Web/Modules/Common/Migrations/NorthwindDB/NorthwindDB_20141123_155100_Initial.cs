﻿using FluentMigrator;

namespace Serene1.Migrations.NorthwindDB
{
    [Migration(20141123155100)]
    public class DefaultDB_20141123_155100_ProductImage : Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver")
                .Execute.EmbeddedScript("Serene1.Modules.Common.Migrations.NorthwindDB.NorthwindDBScript_SqlServer.sql");

            IfDatabase("postgres")
                .Execute.EmbeddedScript("Serene1.Modules.Common.Migrations.NorthwindDB.NorthwindDBScript_Postgres.sql");

            IfDatabase("postgres")
                .Execute.EmbeddedScript("Serene1.Modules.Common.Migrations.NorthwindDB.NorthwindDBScript_PostgresData.sql");

            IfDatabase("mysql")
                .Execute.EmbeddedScript("Serene1.Modules.Common.Migrations.NorthwindDB.NorthwindDBScript_MySql.sql");

            IfDatabase("sqlserver", "postgres")
                .Alter.Table("Customers")
                    .AddColumn("ID").AsInt32().Identity().NotNullable();

            IfDatabase("sqlserver", "postgres")
                .Alter.Table("Territories")
                    .AddColumn("ID").AsInt32().Identity().NotNullable();

            Alter.Table("Products")
                .AddColumn("ProductImage").AsString(100).Nullable();
        }

        public override void Down()
        {
        }
    }
}