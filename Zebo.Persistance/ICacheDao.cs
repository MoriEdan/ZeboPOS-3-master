using System.Collections.Generic;
using Zebo.Domain.Models.Accounts;
using Zebo.Domain.Models.Automation;
using Zebo.Domain.Models.Entities;
using Zebo.Domain.Models.Inventory;
using Zebo.Domain.Models.Menus;
using Zebo.Domain.Models.Settings;
using Zebo.Domain.Models.Tasks;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Persistance
{
    public interface ICacheDao
    {
        void ResetCache();
        IEnumerable<Entity> GetEntities(int entitiyTypeId);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<ProductTimer> GetProductTimers();
        IEnumerable<OrderTagGroup> GetOrderTagGroups();
        IEnumerable<AccountTransactionType> GetAccountTransactionTypes();
        IEnumerable<EntityType> GetEntityTypes();
        IEnumerable<AccountType> GetAccountTypes();
        IEnumerable<AccountTransactionDocumentType> GetAccountTransactionDocumentTypes();
        IEnumerable<State> GetStates();
        IEnumerable<PrintJob> GetPrintJobs();
        IEnumerable<PaymentType> GetPaymentTypes();
        IEnumerable<ChangePaymentType> GetChangePaymentTypes();
        IEnumerable<TicketTagGroup> GetTicketTagGroups();
        IEnumerable<AutomationCommand> GetAutomationCommands();
        IEnumerable<CalculationSelector> GetCalculationSelectors();
        IEnumerable<CalculationType> GetCalculationTypes();
        IEnumerable<AccountScreen> GetAccountScreens();
        IEnumerable<ScreenMenu> GetScreenMenus();
        IEnumerable<EntityScreen> GetEntityScreens();
        IEnumerable<TicketType> GetTicketTypes();
        IEnumerable<TaskType> GetTaskTypes();
        IEnumerable<ForeignCurrency> GetForeignCurrencies();
        IEnumerable<Department> GetDepartments();
        Entity GetEntityByName(int entityTypeId, string entityName);
        IEnumerable<TaxTemplate> GetTaxTemplates();
        IEnumerable<Warehouse> GetWarehouses();
        IEnumerable<InventoryTransactionType> GetInventoryTransactionTypes();
        IEnumerable<AppRule> GetRules();
        IEnumerable<AppAction> GetActions();
    }
}
