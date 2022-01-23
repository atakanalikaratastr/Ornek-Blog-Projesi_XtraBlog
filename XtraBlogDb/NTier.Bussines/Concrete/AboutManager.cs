using NTier.Bussines.Abstract;
using NTier.DataAccess.Abstract;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }
        public void Add(About about)
        {
            _aboutDAL.Add(about);
        }

        public void Delete(About about)
        {
            _aboutDAL.Delete(about);
        }

        public About GetAboutByAboutId(int? id)
        {
            return _aboutDAL.Get(x => x.AboutId == id);
        }

        public List<About> GetAboutList()
        {
            return _aboutDAL.GetAll();
        }

        public void Update(About about)
        {
            _aboutDAL.Update(about);
        }
    }
}
