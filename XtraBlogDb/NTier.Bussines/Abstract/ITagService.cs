using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface ITagService
    {
        List<Tag> GetTagList();
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
        Tag GetTagByTagId(int? id);
        string GetTagByTagName(string tagName);
        int GetTagNameByTagId(string tagName);

    }
}
