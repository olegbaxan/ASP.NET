﻿namespace SampleMvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
            DropColumn("dbo.Customers", "MembershipType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipType", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropColumn("dbo.Customers", "MembershipType_Id");
            DropTable("dbo.MembershipTypes");
        }
    }
}
