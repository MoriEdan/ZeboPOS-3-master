using System;
using Zebo.Domain.Models.Settings;
using Zebo.Localization;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.SettingsModule
{
    public class NumeratorViewModel : EntityViewModelBase<Numerator>
    {
        [LocalizedDisplayName("Name")]
        public string NumeratorName
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        [LocalizedDisplayName("NumberFormat")]
        public string NumberFormat
        {
            get { return Model.NumberFormat; }
            set { Model.NumberFormat = value; }
        }

        public override Type GetViewType()
        {
            return typeof(GenericEntityView);
        }

        public override string GetModelTypeString()
        {
            return Resources.Numerator;
        }
    }
}
