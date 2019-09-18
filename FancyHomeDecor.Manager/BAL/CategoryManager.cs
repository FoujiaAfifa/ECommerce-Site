using FancyHomeDecor.Models.Models;
using FancyHomeDecor.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyHomeDecor.Manager.BAL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public void Add(Category category)
        {

             _categoryRepository.Add(category);
        }

        public List<Category> GetAllCategory()
        {
           return _categoryRepository.GetAllCategory();
        }

        public Category GetByID(int ID)
        {
            return _categoryRepository.GetByID(ID);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.DeleteCategory(category);
        }
    }
}
