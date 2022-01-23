using Core.DataAccess.EntityFramework;
using NTier.DataAccess.Abstract;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DataAccess.Concrete.EntityFramework
{
    public class EfUserDAL : RepositoryBase<User, NTier_Context>, IUserDAL
    {
        public List<UserDetailDTO> GetUserDetails()
        {
            using (var context = new NTier_Context())
            {
                var result = from user in context.Users
                             join title in context.Titles
                             on user.TitleId equals title.TitleId
                             select new UserDetailDTO
                             {
                                 UserId = user.UserId,
                                 Title_Name = title.Name,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Mail = user.Mail,
                                 Password = user.Password,
                                 Statement = user.Statement
                             };

                return result.ToList();
            }
        }
    }
}
