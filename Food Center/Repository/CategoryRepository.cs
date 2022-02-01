using Food_Center.Model;
using FoodCenterContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Center.Repository
{
    public class CategoryRepository: ICategoryRepositor
    {
        FoodCenterDataContext fs = new FoodCenterDataContext();
        Category category = new Category();
        
        public async Task<string>AddCategoryNew(CategoryModel categoryModel)
        {
            var res = fs.Categories.FirstOrDefault(x => x.CategoryName == categoryModel.CategoryName);
            if (res != null)
            {
                throw new ArgumentException("Category Already Exist");
            }
            else
            {
                category.CategoryName = categoryModel.CategoryName;
                category.CategoryDescription = categoryModel.Descritption;

                fs.Categories.InsertOnSubmit(category);
                fs.SubmitChanges();
                return "Category Add SuccessFully";
            }
        }
    }
}
