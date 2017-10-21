namespace PEAKBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedHintCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO HintCategories (Name, Description) VALUES ('Prevention', 'Avoid situations by actively taking steps to prevent them.');
INSERT INTO HintCategories (Name, Description) VALUES ('Instruction', 'Teach proper behavior for coping with different situations.');
INSERT INTO HintCategories (Name, Description) VALUES ('Response', 'Appropriately address situations to discourage bad behavior.');
");
        }
        
        public override void Down()
        {
        }
    }
}
