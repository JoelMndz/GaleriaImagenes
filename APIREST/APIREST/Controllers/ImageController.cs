using Aplicacion.Caracteristicas;
using Aplicacion.Dominio;
using Aplicacion.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using APIREST.Models;

namespace APIREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private Contexto contexto;

        public ImageController(ILogger<WeatherForecastController> logger, Contexto contexto)
        {
            _logger = logger;
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<Image>> GetAll()
        {
            _logger.LogInformation("Obteniendo imagenes");
            return await contexto.Images.ToArrayAsync(); ;
        }

        [HttpPost]
        public async Task<Image> Create(ImageRequet request)
        {
            var image = new Image() { Name = request.Name };
            //Cloudinary
            image.URL = await Upload(request.Base64);
            _logger.LogInformation(image.Id+"");
            await contexto.Images.AddAsync(image);
            await contexto.SaveChangesAsync();
            _logger.LogInformation(image.Id + "");
            return image;
        }

        private async Task<string> Upload(string base64)
        {
            // Es esta parte deben poner sus credenciales de Cloudinary: username, api_key, api_secret
            var cloudinary = new Cloudinary(new Account("dtim15nqh", "648621655632133", "mBWAvenJC_KiKKVHFZASHYcQDh4"));
            cloudinary.Api.Secure = true;
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), new MemoryStream(Convert.FromBase64String(base64)))
            };
            var respuesta = await cloudinary.UploadAsync(uploadParams);
            return respuesta.SecureUrl.AbsoluteUri;
        }
    }
}
