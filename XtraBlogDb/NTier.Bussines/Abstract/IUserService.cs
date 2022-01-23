using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface IUserService
    {
        List<User> GetUserList();
        List<UserDetailDTO> GetUserDetails();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetUserByUserId(int? id);
    }
}
