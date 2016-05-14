﻿using FluentMigrator;

namespace Serene1.Migrations.DefaultDB
{
    [Migration(20141111113000)]
    public class DefaultDB_20141111_113000_Permissions : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("UserPermissions")
                .WithColumn("UserPermissionId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("PermissionKey").AsString(100).NotNullable();

            Create.ForeignKey("FK_UserPermissions_UserId")
                .FromTable("UserPermissions")
                .ForeignColumn("UserId")
                .ToTable("Users")
                .PrimaryColumn("UserId");

            Create.Index("UQ_UserPermissions_UserId_PermissionKey")
                .OnTable("UserPermissions")
                .OnColumn("UserId").Ascending()
                .OnColumn("PermissionKey").Ascending()
                .WithOptions().Unique();

            Create.Table("Roles")
                .WithColumn("RoleId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("RoleName").AsString(100).NotNullable();

            Create.Table("RolePermissions")
                .WithColumn("RolePermissionId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("PermissionKey").AsString(100).NotNullable();

            Create.ForeignKey("FK_RolePermissions_RoleId")
                .FromTable("RolePermissions")
                .ForeignColumn("RoleId")
                .ToTable("Roles")
                .PrimaryColumn("RoleId");

            Create.Index("UQ_RolePermissions_RoleId_PermissionKey")
                .OnTable("RolePermissions")
                .OnColumn("RoleId").Ascending()
                .OnColumn("PermissionKey").Ascending()
                .WithOptions().Unique();

            Create.Table("UserRoles")
                .WithColumn("UserRoleId").AsInt64().Identity().PrimaryKey().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable();

            Create.ForeignKey("FK_UserRoles_UserId")
                .FromTable("UserRoles")
                .ForeignColumn("UserId")
                .ToTable("Users")
                .PrimaryColumn("UserId");

            Create.ForeignKey("FK_UserRoles_RoleId")
                .FromTable("UserRoles")
                .ForeignColumn("RoleId")
                .ToTable("Roles")
                .PrimaryColumn("RoleId");

            Create.Index("UQ_UserRoles_UserId_RoleId")
                .OnTable("UserRoles")
                .OnColumn("UserId").Ascending()
                .OnColumn("RoleId").Ascending()
                .WithOptions().Unique();

            Create.Index("IX_UserRoles_RoleId_UserId")
                .OnTable("UserRoles")
                .OnColumn("RoleId").Ascending()
                .OnColumn("UserId").Ascending();
        }
    }
}