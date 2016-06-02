using System;
using System.Linq;
using Zebo.Domain.Models.Entities;
using Zebo.Domain.Models.Tickets;
using Zebo.Localization.Properties;

namespace Zebo.Modules.PosModule
{
    public class EntityButton
    {
        private readonly Ticket _selectedTicket;
        public EntityButton(EntityType model, Ticket selectedTicket)
        {
            _selectedTicket = selectedTicket;
            Model = model;
        }

        public EntityType Model { get; set; }
        public string Name
        {
            get
            {
                var format = Resources.Select_f;
                if (_selectedTicket != null && _selectedTicket.TicketEntities.Any(x => x.EntityTypeId == Model.Id))
                    format = Resources.Change_f;
                return string.Format(format, Model.EntityName).Replace(" ", Environment.NewLine);
            }
        }
    }
}