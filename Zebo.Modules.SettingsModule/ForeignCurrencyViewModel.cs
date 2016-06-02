﻿using System;
using FluentValidation;
using Zebo.Domain.Models.Settings;
using Zebo.Localization;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.ModelBase;

namespace Zebo.Modules.SettingsModule
{
    class ForeignCurrencyViewModel : EntityViewModelBase<ForeignCurrency>
    {
        [LocalizedDisplayName("Name")]
        public string NumeratorName
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }

        [LocalizedDisplayName("CurrencySymbol")]
        public string CurrencySymbol
        {
            get { return Model.CurrencySymbol; }
            set { Model.CurrencySymbol = value; }
        }

        [LocalizedDisplayName("ExchangeRate")]
        public decimal ExchangeRate
        {
            get { return Model.ExchangeRate; }
            set { Model.ExchangeRate = value; }
        }

        [LocalizedDisplayName("Rounding")]
        public decimal Rounding
        {
            get { return Model.Rounding; }
            set { Model.Rounding = value; }
        }

        public override Type GetViewType()
        {
            return typeof(GenericEntityView);
        }

        public override string GetModelTypeString()
        {
            return Resources.ForeignCurrency;
        }

        protected override AbstractValidator<ForeignCurrency> GetValidator()
        {
            return new ForeignCurrencyValidator();
        }

        internal class ForeignCurrencyValidator : EntityValidator<ForeignCurrency>
        {
            public ForeignCurrencyValidator()
            {
                RuleFor(x => x.ExchangeRate).GreaterThan(0);
            }
        }
    }
}
