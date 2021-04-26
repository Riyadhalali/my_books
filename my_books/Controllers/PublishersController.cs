using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        // inject author service

        private PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }



        // Add Author 
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM author)
        {
            _publishersService.AddPublisher(author);
            return Ok();
        }
    }
}
