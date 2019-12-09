using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public void RemoveReview(Review review)
        {
            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            context.Reviews.Update(review);
            context.SaveChanges();
        }

        public Review GetReview(long id)
        {
            return context.Reviews.Find(id);
        }

        public ICollection<Review> GetAllReviews()
        {
            return context.Reviews.ToList();
        }

        public ApplicationUser GetUserForReview(long id)
        {
            return context.Reviews.Find(id)?.ApplicationUser;
        }

        public Product GetProductForReview(long id)
        {
            return context.Reviews.Find(id)?.Product;
        }
    }
}