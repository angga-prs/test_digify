using DigifyAPI.Data;
using DigifyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyRegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CompanyRegistrationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> PostCompany([FromForm] CompanyRegistration form)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = new CompanyRegistration
            {
                CompanyName = form.CompanyName,
                NPWP = form.NPWP,
                DirectorName = form.DirectorName,
                PICName = form.PICName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                IsInvitationAccessAllowed = form.IsInvitationAccessAllowed
            };

            var uploadPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            if (form.NPWPFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(form.NPWPFile.FileName);
                var path = Path.Combine(uploadPath, fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await form.NPWPFile.CopyToAsync(stream);
                model.NPWPFilePath = $"/uploads/{fileName}";
            }

            if (form.PowerOfAttorneyFile != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(form.PowerOfAttorneyFile.FileName);
                var path = Path.Combine(uploadPath, fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await form.PowerOfAttorneyFile.CopyToAsync(stream);
                model.PowerOfAttorneyFilePath = $"/uploads/{fileName}";
            }

            _context.CompanyRegistration.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Company created successfully", model });
        }
    }
}
