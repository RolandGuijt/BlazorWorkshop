using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Server.Components
{
    public class EmployeeRowBase: ComponentBase
    {
        [Parameter]
        public EmployeeModel Employee { get; set; }

    }
}
