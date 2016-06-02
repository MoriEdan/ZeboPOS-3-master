﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;
using Zebo.Presentation.Services;
using Zebo.Presentation.Services.Common;
using Zebo.Services;
using Zebo.Services.Common;

namespace Zebo.Modules.AccountModule.ActionProcessors
{
    [Export(typeof(IActionType))]
    class CreateAccountTransaction : ActionType
    {
        private readonly ICacheService _cacheService;
        private readonly ITicketService _ticketService;

        [ImportingConstructor]
        public CreateAccountTransaction(ICacheService cacheService, ITicketService ticketService)
        {
            _cacheService = cacheService;
            _ticketService = ticketService;
        }

        protected override object GetDefaultData()
        {
            return new { AccountTransactionTypeName = "", Amount = 0m };
        }

        protected override string GetActionName()
        {
            return string.Format(Resources.Create_f, Resources.AccountTransaction);
        }

        protected override string GetActionKey()
        {
            return ActionNames.CreateAccountTransaction;
        }

        public override void Process(ActionData actionData)
        {
            var ticket = actionData.GetDataValue<Ticket>("Ticket");
            if (ticket != null)
            {
                var amount = actionData.GetAsDecimal("Amount");
                var transactionName = actionData.GetAsString("AccountTransactionTypeName");
                if (!string.IsNullOrEmpty(transactionName))
                {
                    var accountTransactionType = _cacheService.GetAccountTransactionTypeByName(transactionName);
                    if (accountTransactionType != null)
                    {
                        var ts = ticket.TicketEntities.FirstOrDefault(x => _ticketService.CanMakeAccountTransaction(x, accountTransactionType, 0));
                        if (ts != null)
                        {
                            ticket.TransactionDocument.AddNewTransaction(accountTransactionType, ticket.GetTicketAccounts(), amount, 1);
                        }
                    }
                }
            }
        }
    }
}
