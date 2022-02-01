using Food_Center.Model;
using System.Threading.Tasks;

namespace Food_Center.Repository
{
    public interface ICategoryRepositor
    {
        Task<string> AddCategoryNew(CategoryModel categoryModel);
    }
}
