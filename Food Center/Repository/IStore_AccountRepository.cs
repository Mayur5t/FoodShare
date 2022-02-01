using Food_Center.Model;
using System.Threading.Tasks;

namespace Food_Center.Repository
{
    public interface IStore_AccountRepository
    {
        Task<string> AddRole(RoleModel roleModel);
        Task<string> SignUp(Store_SignUpModel store_SignUpModel);

        Task<string> Login(LoginModel loginModel);
    }
}
