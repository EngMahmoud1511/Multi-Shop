using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;

namespace Multi_Shop.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public AuthController( UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CustomerDTO customerDTO)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = customerDTO.Email;
            user.PhoneNumber=customerDTO.Phone;
            user.UserName = customerDTO.FirstName;
            await userManager.CreateAsync(user,customerDTO.Password);
            return Ok(customerDTO);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(CustomerDTO customerDTO)
        {
            ApplicationUser user= await userManager.FindByNameAsync(customerDTO.FirstName);
            return Ok(user);    
        }

    }
}
