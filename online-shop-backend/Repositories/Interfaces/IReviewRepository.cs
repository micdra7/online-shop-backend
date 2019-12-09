using System.Collections.Generic;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        void RemoveReview(Review review);
        void UpdateReview(Review review);
        Review GetReview(long id);
        ICollection<Review> GetAllReviews();
        ApplicationUser GetUserForReview(long id);
        Product GetProductForReview(long id);
    }
}