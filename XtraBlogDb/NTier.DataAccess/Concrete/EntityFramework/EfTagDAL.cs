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
    public class EfTagDAL : RepositoryBase<Tag, NTier_Context>, ITagDAL
    {
        public string GetTagByTagName(string tagName)
        {
            using (var context = new NTier_Context())
            {
                List<string> tags = new List<string>();
                if (context.Tags.ToList().Count > 0)
                {
                    foreach (var item in context.Tags.ToList())
                    {
                        tags.Add(item.Name);
                    }
                }
                //return context.Tags.FirstOrDefault(x => x.Name == tagName).Name;
                bool tagIsName = tags.Contains(tagName);
                if (tagIsName == true)
                    return tagName;
                return "Değer yok";
            }
        }

        public int GetTagNameByTagId(string tagName)
        {
            using (var context = new NTier_Context())
            {
                return context.Tags.FirstOrDefault(x => x.Name == tagName).TagId;
            }
        }
    }
}
