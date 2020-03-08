using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Repositories.Implementations
{
    public class EFUserDetailRepository : IUserDetailRepository
    {
        private ApplicationDbContext context;

        public EFUserDetailRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public void AddUserDetail(UserDetail userDetail)
        {
            context.UserDetails.Add(userDetail);
            context.SaveChanges();
        }

        public void RemoveUserDetail(UserDetail userDetail)
        {
            context.UserDetails.Remove(userDetail);
            context.SaveChanges();
        }

        public void UpdateUserDetail(UserDetail userDetail)
        {
            context.UserDetails.Update(userDetail);
            context.SaveChanges();
        }

        public UserDetail GetUserDetail(long id)
        {
            return context.UserDetails.Find(id);
        }

        public ICollection<UserDetail> GetAllUserDetails()
        {
            return context.UserDetails.ToList();
        }

        public ICollection<UserDetail> GetDetailsForUser(string userId)
        {
            return context.UserDetails.Where(detail => detail.ApplicationUserID == userId).ToList();
        }

        public ApplicationUser GetUserForUserDetail(long id)
        {
            return (ApplicationUser) context.Users.Find(
                context.UserDetails.Find(id)?.ApplicationUserID
            );
        }
    }
}