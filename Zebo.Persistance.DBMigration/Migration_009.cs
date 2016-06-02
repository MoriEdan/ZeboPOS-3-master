using System.Data.Entity;
using System.Linq;
using FluentMigrator;
using Zebo.Domain.Models.Settings;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services.Common;

namespace Zebo.Persistance.DBMigration
{
    [Migration(9)]
    public class Migration_009 : Migration
    {
        public override void Up()
        {
            Create.Column("PrimaryFieldName").OnTable("EntityTypes").AsString(128).Nullable();
            Create.Column("PrimaryFieldFormat").OnTable("EntityTypes").AsString(128).Nullable();
        }

        public override void Down()
        {

        }
    }
}