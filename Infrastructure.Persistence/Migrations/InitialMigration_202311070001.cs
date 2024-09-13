using FluentMigrator;

namespace Infrastructure.Persistence.Migrations
{
    [Migration(202311070001)]
    public class InitialMigration_202311070001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Offices");
        }
        public override void Up()
        {
            Create.Table("Offices")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey().WithDefault(SystemMethods.NewGuid)
                .WithColumn("City").AsString(2048).NotNullable()
                .WithColumn("Street").AsString(2048).NotNullable()
                .WithColumn("HouseNumber").AsInt32().NotNullable()
                .WithColumn("OfficeNumber").AsInt32().NotNullable()
                .WithColumn("RegistryPhoneNumber").AsString(1024).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("PhotoId").AsGuid().NotNullable();
        }
    }
}
