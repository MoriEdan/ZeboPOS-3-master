using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zebo.Domain.Models.Inventory;
using Zebo.Localization.Properties;
using Zebo.Presentation.Common.Commands;
using Zebo.Presentation.Common.ModelBase;
using Zebo.Presentation.Common.Services;
using Zebo.Presentation.Services;

namespace Zebo.Modules.InventoryModule
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    class RecipeListViewModel : EntityCollectionViewModelBase<RecipeViewModel, Recipe>
    {
        private readonly IInventoryService _inventoryService;
        public ICaptionCommand TestRecipesCommand { get; set; }
        public ICaptionCommand TestAllRecipesCommand { get; set; }

        [ImportingConstructor]
        public RecipeListViewModel(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
            TestRecipesCommand = new CaptionCommand<string>(string.Format(Resources.Find_f, Resources.RequiredRecipes), OnTestRequiredRecipes);
            TestAllRecipesCommand = new CaptionCommand<string>(string.Format(Resources.Find_f, Resources.MissingRecipes), OnTestMissingRecipes);
            CustomCommands.Add(TestRecipesCommand);
            CustomCommands.Add(TestAllRecipesCommand);
        }

        private void OnTestRequiredRecipes(string obj)
        {
            Mouse.SetCursor(Cursors.Wait);
            var items = _inventoryService.GetRequiredRecipesForSales().ToList();
            Mouse.UpdateCursor();
            if (items.Any())
            {
                var message = string.Join("\r\n", items);
                InteractionService.UserIntraction.GetStringFromUser(Resources.RequiredRecipes, items.Count + " " + Resources.RequiredRecipes, message);
            }
            else
            {
                MessageBox.Show(string.Format(Resources.No_f, Resources.RequiredRecipes));
            }
        }
        private void OnTestMissingRecipes(string obj)
        {
            Mouse.SetCursor(Cursors.Wait);
            var items = _inventoryService.GetMissingRecipes().ToList();
            Mouse.UpdateCursor();
            if (items.Any())
            {
                var message = string.Join("\r\n", items);
                InteractionService.UserIntraction.GetStringFromUser(Resources.MissingRecipes, items.Count + " " + Resources.MissingRecipes, message);
            }
            else
            {
                MessageBox.Show(string.Format(Resources.No_f, Resources.MissingRecipes));
            }
        }
    }
}
