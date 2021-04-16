using Application.Common.Interfaces.Services;
using Application.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviePhile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {

        private readonly ICommunityService _communityService;
        private readonly IMapper _mapper;

        public CommunityController(ICommunityService communityService, IMapper mapper)
        {
            _communityService = communityService;
            _mapper = mapper;
        }

        // GET: api/<CommunityController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var communities = await _communityService.GetCommunities();
            return Ok(_mapper.Map<IEnumerable<CommunityDTO>>(communities));
        }

        // GET api/<CommunityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommunityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommunityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommunityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
