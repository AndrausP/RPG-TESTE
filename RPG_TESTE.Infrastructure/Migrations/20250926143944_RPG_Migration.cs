using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace RPG_TESTE.Infrastructure.Migrations
{
    [FluentMigrator.Migration(20250926143944)]
    public sealed partial class RPG_Migration : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("Characters");
        }
        public override void Up()
        {
            Create.Table("Characters")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("HP").AsInt32().NotNullable()
                .WithColumn("Level").AsInt32().NotNullable()
                .WithColumn("Strength").AsInt32().NotNullable()
                .WithColumn("Defense").AsInt32().NotNullable()
                .WithColumn("Intelligence").AsInt32().NotNullable()
                .WithColumn("RpgClass").AsInt32().NotNullable()
                .WithColumn("IsAlive").AsBoolean().NotNullable().WithDefaultValue(true);
        }
    }
}
