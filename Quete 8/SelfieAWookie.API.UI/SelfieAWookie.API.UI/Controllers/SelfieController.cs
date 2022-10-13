using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.API.UI.Application.DTOs;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookie.API.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfieController : ControllerBase
    {
        private readonly ISelfieRepository repository = null;
        private readonly IWebHostEnvironment hostEnvironment = null;
        public SelfieController(ISelfieRepository slf, IWebHostEnvironment host)
        {
            repository = slf;
            hostEnvironment = host;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]int? wookieId = 0)
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
            var param = this.Request.Query["wookieId"];
            var model = this.repository.GetAll(wookieId);

            var res = model.Select(item =>
            new SelfieResumeDTO() { Title = item.Title, WookieId = item.Wookie.Id, nbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) })
                .ToList();


            return this.Ok(res);
        }

        [HttpPost]
        public IActionResult AddOne(SelfieDTO item)
        {
            IActionResult res = this.BadRequest();

            Selfie addedSelfie = this.repository.AddOne(new Selfie()
            {
                ImagePath = item.ImagePath,
                Title = item.Title
            });

            this.repository.UnitOfWork.SaveChanges();
            if(addedSelfie != null)
            {
                item.Id = addedSelfie.Id;
                res = this.Ok(item);
            }
            
            
            return res;
        }

        //[Route("photos")]
        //[HttpPost]
        //public async Task<IActionResult> AddPicture()
        //{
        //    using var stream = new StreamReader(this.Request.Body) ;
        //    var content = await stream.ReadToEndAsync();

        //    return this.Ok();
        //}

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile file)
        {
            string filePath = Path.Combine(hostEnvironment.ContentRootPath, @"images\selfies");
            
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, file.FileName);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);

            try
            {
                var itemFile = repository.AddOne(filePath);
                repository.UnitOfWork.SaveChanges();
                return this.Ok(itemFile);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return this.Ok();


        }
    }
}
