using Core.DataAccess;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DataAccess.Abstract
{
    public interface IUserDAL : IRepository<User>
    {
        List<UserDetailDTO> GetUserDetails();
    }
}
