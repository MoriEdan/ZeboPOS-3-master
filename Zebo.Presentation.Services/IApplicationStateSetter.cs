using System.Collections.Generic;
using Zebo.Domain.Models.Entities;
using Zebo.Domain.Models.Tickets;
using Zebo.Domain.Models.Users;
using Zebo.Presentation.Services.Common;

namespace Zebo.Presentation.Services
{
    public interface IApplicationStateSetter
    {
        void SetCurrentLoggedInUser(User user);
        void SetCurrentDepartment(int departmentId);
        void SetCurrentApplicationScreen(AppScreens appScreen);
        EntityScreen SetSelectedEntityScreen(EntityScreen entityScreen);
        void SetApplicationLocked(bool isLocked);
        void SetNumberpadValue(string value);
        void SetCurrentTicketType(TicketType ticketType);
        void SetCurrentTerminal(string terminalName);
        void ResetWorkPeriods();
    }
}