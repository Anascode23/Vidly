using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerVM
    {

        public Customer Customer { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MembershipTypeList { get; set; }
    }
}
