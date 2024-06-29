
using JwtLogin.Repository.Repository;  
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Repo.Repository.USP_Customer;
using Repo.Repository.Repositories.Interfaces;
namespace Repo.Web
{
    public class ModOneController : Controller
    {

        public IConfiguration Configuration;
        private readonly IModOneRepository _ModOneRepository;
        private IWebHostEnvironment _hostingEnvironment;
        public ModOneController(IConfiguration configuration, IModOneRepository ModOneRepository, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _ModOneRepository = ModOneRepository;

            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult USP_Customer()
{
    var validUser = JWTloginRepository.ValidateToken(HttpContext.Session.GetString("JWToken"));
    if (validUser != "")
    {
        return View();
    }
    else
    {
        return RedirectToAction("JWTLogin", "JwtLogin");
    }
    }
        [HttpPost]
        public IActionResult USP_Customer(USP_Customer_Model TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                              .SelectMany(v => v.Errors)
                              .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.P_CustID == 0 || TBL.P_CustID == null)
                {
                    var data = _ModOneRepository.I_USP_Customer(TBL);
                    return Json(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });

                }
                else
                {
                    var data = _ModOneRepository.U_USP_Customer(TBL);
                    return Json(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });

                }
            }
        }
        [HttpGet]
        public IActionResult ViewUSP_Customer()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_USP_Customer()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<VUSP_Customer> lst = await _ModOneRepository.V_USP_Customer(new USP_Customer_Model());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Json(jsonres);

            }

        }

        [HttpDelete]

        public async Task<JsonResult> Delete_USP_Customer(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                USP_Customer_Model ob = new USP_Customer_Model();
                ob.P_CustID = Id;

                var data = await _ModOneRepository.D_USP_Customer(ob);
                return Json(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }
        [HttpGet]

        public async Task<JsonResult> E_USP_Customer(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {

                USP_Customer_Model ob = new USP_Customer_Model();
                ob.P_CustID = Id;
                List<EUSP_Customer> lst = await _ModOneRepository.E_USP_Customer(ob);
                var jsonres = JsonConvert.SerializeObject(lst?.FirstOrDefault());
                return Json(jsonres);
            }

        }

    }
}