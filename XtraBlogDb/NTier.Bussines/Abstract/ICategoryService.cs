using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{

    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Category GetCategoryByCategoryId(int? id);

    }
}
