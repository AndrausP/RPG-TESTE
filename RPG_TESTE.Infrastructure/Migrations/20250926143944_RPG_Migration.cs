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
                .WithColumn("HitPoints").AsInt32().NotNullable()
                .WithColumn("Strength").AsInt32().NotNullable()
                .WithColumn("Defense").AsInt32().NotNullable()
                .WithColumn("Intelligence").AsInt32().NotNullable()
                .WithColumn("Class").AsString().NotNullable();
        }
    }
}
