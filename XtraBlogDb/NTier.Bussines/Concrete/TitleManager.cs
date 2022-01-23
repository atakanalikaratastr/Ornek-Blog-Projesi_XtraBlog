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
    public class TitleManager : ITitleService
    {
        ITitleDAL _titleDAL;
        public TitleManager(ITitleDAL titleDAL)
        {
            _titleDAL = titleDAL;
        }
        public void Add(Title title)
        {
            _titleDAL.Add(title);
        }

        public void Delete(Title title)
        {
            _titleDAL.Delete(title);
        }

        public Title GetTitleByTitleId(int? id)
        {
            return _titleDAL.Get(x => x.TitleId == id);
        }

        public List<Title> GetTitleList()
        {
            return _titleDAL.GetAll();
        }

        public void Update(Title title)
        {
            _titleDAL.Update(title);
        }
    }
}
