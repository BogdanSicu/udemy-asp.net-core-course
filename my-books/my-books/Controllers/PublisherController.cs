using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.DTOs;
using my_books.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherDTO publisherDTO)
        {
            _publisherService.AddPublisher(publisherDTO);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            return Ok(_publisherService.GetAllPublishers());
        }

        [HttpDelete("{publisherId}")]
        public IActionResult DeletePublisherById(int publisherId)
        {
            _publisherService.DeletePublisherById(publisherId);
            return Ok();
        }
    }
}
