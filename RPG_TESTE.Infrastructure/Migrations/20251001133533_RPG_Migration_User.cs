using FluentMigrator;

namespace RPG_TESTE.Infrastructure.Migrations
{
    [FluentMigrator.Migration(20251001133533)]
    public sealed partial class RPG_Migration_User : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Name").AsString(200).NotNullable()
            .WithColumn("Email").AsString(200).NotNullable()
            .WithColumn("PasswordHash").AsBinary(64).NotNullable()
            .WithColumn("PasswordSalt").AsBinary(32).NotNullable()
            .WithColumn("UserType").AsInt32().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithDefault(SystemMethods.CurrentUTCDateTime);
        }

        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
