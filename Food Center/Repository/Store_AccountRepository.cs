using Food_Center.Model;
using FoodCenterContext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Food_Center.Repository
{
    public class Store_AccountRepository : IStore_AccountRepository
    {
        FoodCenterDataContext context = new FoodCenterDataContext();
        SignUp re = new SignUp();
        Role role = new Role();
        private readonly IConfiguration _configuration;

        public Store_AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> AddRole(RoleModel roleModel)
        {
            using (FoodCenterDataContext context = new FoodCenterDataContext())
            {
                role.RoleName = roleModel.RoleName;
                var check = context.Roles.FirstOrDefault(x => x.RoleName == roleModel.RoleName);
                if (check != null)
                {
                    return "Role already exist";
                    
                    //return "Role already exist";
                }
                else
                {
                    context.Roles.InsertOnSubmit(role);
                    context.SubmitChanges();
                    return "New Role Added Successfully";
                  
                    //return "New Role Added Successfully";
                }
            }
        }



        public async Task<string> SignUp(Store_SignUpModel store_SignUpModel)
        {
            var query = (from SignUp in context.SignUps
                         join role in context.Roles
                         on SignUp.RoleId equals role.RoleId
                         where SignUp.EmailId == SignUp.EmailId && SignUp.Password == SignUp.Password
                         select new
                         {
                             role.RoleName
                         }).Count();
            if (query != 0)
            {
                throw new ArgumentException("User Already exist");
                //return "User Already exist";
            }

            var res = context.SignUps.FirstOrDefault(x => x.EmailId == store_SignUpModel.EmailId);
            if (res != null)
            {
                throw new ArgumentException("Email Id Already Exist");
            }
            else
            {
                re.EmailId = store_SignUpModel.EmailId;
                re.Password = store_SignUpModel.Password;
                re.ConfirmPassword = store_SignUpModel.Confirm_Password;
                re.StoreName = store_SignUpModel.Shop_Name;
                re.StoreAddress = store_SignUpModel.Address;
                re.StoreEmailid = store_SignUpModel.Shop_Emailid;
                re.StorePhoneNo = store_SignUpModel.Shop_Number;
                re.StoreAlternatePhoneNo = store_SignUpModel.Alternate_Number;
                re.DeliveryRadius = store_SignUpModel.Delivery_Radius;
                re.StoreLogo = store_SignUpModel.Shop_logo;

                context.SignUps.InsertOnSubmit(re);
                context.SubmitChanges();
                return "Data Saved Successfully";
            }

        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var result = (from SignUp in context.SignUps
                          where SignUp.EmailId == loginModel.EmailId && SignUp.Password == loginModel.Password
                          select SignUp).ToList();
            if (result.Count() == 1)
            {

                var authclaims = new List<Claim>
                 {
                new Claim(ClaimTypes.Name,loginModel.EmailId),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                 };
                var authsignkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: authclaims,
                    signingCredentials: new SigningCredentials(authsignkey, SecurityAlgorithms.HmacSha256Signature)
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
                return "Enter Proper Details";

        }


    }

      
}
                    