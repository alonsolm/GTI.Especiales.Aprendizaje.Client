namespace GTI.Especiales.Aprendizaje.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeID = c.Int(nullable: false, identity: true),
                        EmployeName = c.String(),
                        RFC = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employes");
        }
    }
}
