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
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Add(Category category)
        {
            _categoryDAL.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public Category GetCategoryByCategoryId(int? id)
        {
            return _categoryDAL.Get(x => x.CategoryId == id);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDAL.GetAll();
        }

        public void Update(Category category)
        {
            _categoryDAL.Update(category);
        }
    }
}
