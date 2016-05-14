﻿using FluentMigrator;

namespace Serene1.Migrations.NorthwindDB
{
    [Migration(20151014030700)]
    public class DefaultDB_20151014_030700_OrderDetailID : AutoReversingMigration
    {
        public override void Up()
        {
            IfDatabase("sqlserver", "postgres")
                .Alter.Table("Order Details")
                    .AddColumn("DetailID").AsInt32().Identity().NotNullable();
        }
    }
}