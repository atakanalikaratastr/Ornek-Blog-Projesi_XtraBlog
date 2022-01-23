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
    public class TagManager : ITagService
    {
        ITagDAL _tagDAL;
        public TagManager(ITagDAL tagDAL)
        {
            _tagDAL = tagDAL;
        }

        public void Add(Tag tag)
        {

            _tagDAL.Add(tag);
        }

        public void Delete(Tag tag)
        {
            _tagDAL.Delete(tag);
        }

        public Tag GetTagByTagId(int? id)
        {
            return _tagDAL.Get(x => x.TagId == id);
        }

        public string GetTagByTagName(string tagName)
        {
           return _tagDAL.GetTagByTagName(tagName);
        }

        public List<Tag> GetTagList()
        {
            return _tagDAL.GetAll();
        }

        public int GetTagNameByTagId(string tagName)
        {
            return _tagDAL.GetTagNameByTagId(tagName);
        }

        public void Update(Tag tag)
        {
            _tagDAL.Update(tag);
        }
    }
}
