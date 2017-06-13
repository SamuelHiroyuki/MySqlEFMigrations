namespace MySqlEFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, unicode: false),
                        Autor = c.String(nullable: false, unicode: false),
                        AnoPublicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livro");
        }
    }
}
