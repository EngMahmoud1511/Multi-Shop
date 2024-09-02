using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multi_Shop.Data.DTO;
using Multi_Shop.Service.Services.Sevices.Class;

namespace Multi_Shop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _service;
        private readonly CloudinaryService _cloudinary;

        public ItemsController( ItemService service,CloudinaryService cloudinary)
        {
            _service = service;
            _cloudinary = cloudinary;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        { 
            

          return Ok(_service.GetItems());
        }
        [HttpPost("Add")]
        public async Task< IActionResult> Add([FromForm] ItemDTO item ,IFormFile file )
        { 
            var result=await _cloudinary.UploadPhotoAsync(file);
            if (result ==null )
            {
                return BadRequest();
            }
            item.ImagePath=result.SecureUrl.ToString();
            _service.Add(item);
            return Ok(item);    

        } 


    }
}
