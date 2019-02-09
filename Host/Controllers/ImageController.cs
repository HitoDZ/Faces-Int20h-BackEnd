using System.Threading.Tasks;
using Domain.Persistance;
using Host.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly ImageRepository _repository;

        public ImageController(ImageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(RouteConstants.Images)]
        public async Task<IActionResult> GetAll()
        {
            return Ok( await _repository.GetAll());
        }

    }
}