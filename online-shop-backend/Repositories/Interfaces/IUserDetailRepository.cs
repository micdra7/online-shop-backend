using System.Collections.Generic;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Repositories.Interfaces
{
    public interface IUserDetailRepository
    {
        void AddUserDetail(UserDetail userDetail);
        void RemoveUserDetail(UserDetail userDetail);
        void UpdateUserDetail(UserDetail userDetail);
        UserDetail GetUserDetail(long id);
        ICollection<UserDetail> GetAllUserDetails();
        ICollection<UserDetail> GetDetailsForUser(string userId);
        ApplicationUser GetUserForUserDetail(long id);
    }
}