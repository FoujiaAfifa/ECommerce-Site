using FancyHomeDecor.DatabaseContext.DatabaseContext;
using FancyHomeDecor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyHomeDecor.Repository.Repository
{
    public class CategoryRepository
    {
        HomeDecorContext _db = new HomeDecorContext();
        public void Add(Category category)
        {

            _db.Categories.Add(category);

            _db.SaveChanges();
        }

        public List<Category> GetAllCategory()
        {
            return _db.Categories.ToList();
        }

        public Category GetByID(int ID)
        {
            return _db.Categories.Find(ID);
        }

        public void UpdateCategory(Category category)
        {
            _db.Entry(category).State = System.Data.Entity.EntityState.Modified;

            _db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);

            _db.SaveChanges();
        }
    }
}
