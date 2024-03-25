using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime? BirthDate { get; set; }


        [ValidateNever]
        [ForeignKey("MembershipTypeId")]
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}
