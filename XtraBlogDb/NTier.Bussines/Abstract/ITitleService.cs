using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface ITitleService
    {
        List<Title> GetTitleList();
        void Add(Title title);
        void Update(Title title);
        void Delete(Title title);
        Title GetTitleByTitleId(int? id);
    }
}
