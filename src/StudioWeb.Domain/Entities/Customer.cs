using StudioWeb.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudioWeb.Domain.Entities
{
    public class Customer
    {
            public int Id { get; set; }

            [Required(ErrorMessage = "Full name is required")]
            [StringLength(100, ErrorMessage = "Full name must be up to 100 characters")]
            public string FullName { get; set; }

            [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
            public string PhoneNumber { get; set; }

            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string EMail { get; set; }

            [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters")]
            public string? Comment { get; set; }

            [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid budget format. Use up to 2 decimal places.")]
            public string Budget { get; set; }

            public Status Status { get; set; }
    }
}
