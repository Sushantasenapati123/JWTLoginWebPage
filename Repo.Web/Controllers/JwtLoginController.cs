using Microsoft.AspNetCore.Mvc;
using JwtloginModel.Model.LoginEntity;
using JwtLogin.Repository.Repositories.Interfaces;
using JwtLogin.Repository.Repository;

namespace Repo.Web
{
    public class JwtLoginController : Controller
    {
        private readonly IJwtRepository _user;
        public JwtLoginController(IJwtRepository user)
        {
            _user = user;
        }
        public IActionResult JWTLogin()
        {
            return View();
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("JWTLogin", "JwtLogin");
        }
        public async Task<ActionResult> UserLogin(LoginEntity viewModel)
        {
            var jsonres = "";
            var validUserName = "";
            List<LoginEntity> lst = new List<LoginEntity>();
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return View("Index", viewModel);
                //}
                if (viewModel.UserName != null && viewModel.Password != null)
                {
                    var user = Authenticate(viewModel.UserName);
                    if (user.Result.Count != 0)
                    {
                        var roles = new string[] { "superAdmin", "Admin" };
                        var jwtSecurityToken = JWTloginRepository.GenerateJwtToken(viewModel.UserName, roles.ToList());
                        HttpContext.Session.SetString("JWToken", jwtSecurityToken);
                        validUserName = JWTloginRepository.ValidateToken(jwtSecurityToken);

                        if (validUserName != "")
                        {
                            TempData["uname"] = validUserName;
                        }
                        else
                        {
                            return Json(new { data = validUserName });
                        }
                    }
                    else
                    {
                        return Json(new { data = "Error" });
                    }
                }
                return Json(new { data = validUserName });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<List<LoginEntity>> Authenticate(string user)
        {
            List<LoginEntity> Udtl = await _user.GetByUserIdAsync(user);
            return Udtl;
        }
    }
}

