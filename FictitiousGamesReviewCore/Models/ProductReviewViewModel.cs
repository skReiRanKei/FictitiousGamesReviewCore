using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FictitiousGamesReviewCore.Models
{
    public class ProductReviewViewModel
    {
        [ValidateNever]
        public Product? Product { get; set; } = new Product();
        public Review NewReview { get; set; } = new Review();

    }
}
