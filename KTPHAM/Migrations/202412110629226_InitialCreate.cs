namespace KTPHAM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.KitchenNotifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        NotificationTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        TableID = c.Int(nullable: false),
                        CustomerID = c.Int(),
                        OrderTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Tables", t => t.TableID, cascadeDelete: true)
                .Index(t => t.TableID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        MenuItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.MenuItemID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemID);
            
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        TableNumber = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
            CreateTable(
                "dbo.MenuStatistics",
                c => new
                    {
                        StatisticID = c.Int(nullable: false, identity: true),
                        MenuItemID = c.Int(nullable: false),
                        TotalOrders = c.Int(nullable: false),
                        LastOrdered = c.DateTime(),
                    })
                .PrimaryKey(t => t.StatisticID)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemID, cascadeDelete: true)
                .Index(t => t.MenuItemID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        TableID = c.Int(nullable: false),
                        ReservationTime = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Tables", t => t.TableID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.TableID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "TableID", "dbo.Tables");
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Payments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.MenuStatistics", "MenuItemID", "dbo.MenuItems");
            DropForeignKey("dbo.KitchenNotifications", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "TableID", "dbo.Tables");
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "MenuItemID", "dbo.MenuItems");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Reservations", new[] { "TableID" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropIndex("dbo.Payments", new[] { "OrderID" });
            DropIndex("dbo.MenuStatistics", new[] { "MenuItemID" });
            DropIndex("dbo.OrderDetails", new[] { "MenuItemID" });
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "TableID" });
            DropIndex("dbo.KitchenNotifications", new[] { "OrderID" });
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Payments");
            DropTable("dbo.MenuStatistics");
            DropTable("dbo.Tables");
            DropTable("dbo.MenuItems");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.KitchenNotifications");
            DropTable("dbo.Customers");
        }
    }
}
