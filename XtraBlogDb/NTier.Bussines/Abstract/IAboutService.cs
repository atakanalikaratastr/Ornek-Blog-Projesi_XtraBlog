using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        void Add(About about);
        void Update(About about);
        void Delete(About about);
        About GetAboutByAboutId(int? id);
    }
}
