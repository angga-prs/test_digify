using DigifyMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigifyMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CompanyController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(CompanyFormModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            using var client = _httpClientFactory.CreateClient();
            using var content = new MultipartFormDataContent();
            var apiBaseUrl = _configuration["ApiSettings:BaseUrl"];

            content.Add(new StringContent(model.CompanyName), "CompanyName");
            content.Add(new StringContent(model.NPWP), "NPWP");
            content.Add(new StringContent(model.DirectorName), "DirectorName");
            content.Add(new StringContent(model.PICName), "PICName");
            content.Add(new StringContent(model.Email), "Email");
            content.Add(new StringContent(model.PhoneNumber), "PhoneNumber");

            content.Add(new StringContent(model.IsInvitationAccessAllowed.ToString().ToLower()), "IsInvitationAccessAllowed");

            content.Add(new StreamContent(model.NPWPFile.OpenReadStream()), "NPWPFile", model.NPWPFile.FileName);
            content.Add(new StreamContent(model.PowerOfAttorneyFile.OpenReadStream()), "PowerOfAttorneyFile", model.PowerOfAttorneyFile.FileName);

            var response = await client.PostAsync($"{apiBaseUrl}/api/CompanyRegistration", content);
            var abc = response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Data submitted successfully!";
                TempData["MessageType"] = "success";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = "Failed to submit data.";
                TempData["MessageType"] = "error";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
