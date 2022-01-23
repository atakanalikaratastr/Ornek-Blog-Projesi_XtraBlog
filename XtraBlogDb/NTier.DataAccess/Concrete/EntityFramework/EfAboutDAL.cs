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
    public class EfAboutDAL : RepositoryBase<About, NTier_Context>, IAboutDAL
    {
    }
}
