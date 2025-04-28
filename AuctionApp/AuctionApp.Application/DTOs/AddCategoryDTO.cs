using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Application.DTOs
{
    public class AddCategoryDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Category name can only contain alphabets and spaces.")]
        public string Name { get; set; }
    }
}
