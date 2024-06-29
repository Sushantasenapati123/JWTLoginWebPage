
using JwtLogin.Repository.Repository;  
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using  System.Text;
using Repo.Repository.USP_DIST_NoUpdate;
using Repo.Repository.Repositories.Interfaces;
namespace Repo.Web
{
 public class ModTwoController : Controller
 {
 	 
		public IConfiguration Configuration;
		private readonly IModTwoRepository _ModTwoRepository;
        private IWebHostEnvironment _hostingEnvironment;
		public ModTwoController(IConfiguration configuration,IModTwoRepository ModTwoRepository,IWebHostEnvironment hostingEnvironment)
		{
		Configuration = configuration;
	_ModTwoRepository = ModTwoRepository;
		
            _hostingEnvironment = hostingEnvironment;}
		[HttpGet]
		public IActionResult USP_DIST_NoUpdate()
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
  public IActionResult USP_DIST_NoUpdate(USP_DIST_NoUpdate_Model TBL)
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
                if (TBL.P_DistId == 0 || TBL.P_DistId == null)
                {
                    var data = _ModTwoRepository.I_USP_DIST_NoUpdate(TBL);
                    return Json(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });

                }
                else
                {
                    var data = _ModTwoRepository.I_USP_DIST_NoUpdate(TBL);
                    return Json(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });

                }
            }
        }
		[HttpGet]
		public IActionResult ViewUSP_DIST_NoUpdate()
		{
		return View();
		}
		[HttpGet]
		public async Task<JsonResult> Get_USP_DIST_NoUpdate()
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
			List<VUSP_DIST_NoUpdate>			 lst =await 			 _ModTwoRepository.V_USP_DIST_NoUpdate(new USP_DIST_NoUpdate_Model());
		var jsonres = JsonConvert.SerializeObject(lst);
		
		return Json(jsonres);
		
}
		
}[HttpPost]
        public async Task<IActionResult> Search_USP_DIST_NoUpdate([FromBody]USP_DIST_NoUpdate_Model BL)
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
                List<SUSP_DIST_NoUpdate> lst = await _ModTwoRepository.S_USP_DIST_NoUpdate(BL);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Json(jsonres);

            }

        }   

   [HttpDelete]
       
        public async Task<JsonResult>Delete_USP_DIST_NoUpdate(int Id)
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
                 USP_DIST_NoUpdate_Model ob = new USP_DIST_NoUpdate_Model();
                ob.P_DistId = Id;

                var data =await _ModTwoRepository.D_USP_DIST_NoUpdate(ob);
                return Json(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }        [HttpGet]

        public async Task<JsonResult>E_USP_DIST_NoUpdate(int Id)
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

             USP_DIST_NoUpdate_Model ob = new USP_DIST_NoUpdate_Model();
                ob.P_DistId = Id;
                List<EUSP_DIST_NoUpdate> lst = await _ModTwoRepository.E_USP_DIST_NoUpdate(ob);
                var jsonres = JsonConvert.SerializeObject(lst?.FirstOrDefault());
                return Json(jsonres);
            }

        }
 
}
}