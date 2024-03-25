using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> GenreList { get; set; }
    }
}
