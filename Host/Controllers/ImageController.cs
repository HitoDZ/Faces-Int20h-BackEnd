using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Persistance;
using Host.Constants;
using Host.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route(RouteConstants.Base)]
    public class ImageController : ControllerBase
    {
        private readonly ImageRepository _repository;

        public ImageController(ImageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(RouteConstants.Images)]
        public async Task<ActionResult<IReadOnlyCollection<DBPhotoModel>>> Get(
            [FromQuery] int? offset = null, [FromQuery] int? count = null)
        {
            return await _repository.GetAsync(offset, count);
        }
    }
}