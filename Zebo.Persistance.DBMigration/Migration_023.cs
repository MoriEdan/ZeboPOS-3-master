using FluentMigrator;

namespace Zebo.Persistance.DBMigration
{
    [Migration(23)]
    public class Migration_023 : Migration
    {
        public override void Up()
        {
            Create.Column("ForeignCurrencyId").OnTable("AccountTransactionTypes").AsInt32().WithDefaultValue(0);
        }

        public override void Down()
        {

        }
    }
}