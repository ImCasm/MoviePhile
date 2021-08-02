using Application.Common.Interfaces.Auth;
using Application.Common.Interfaces.Services;
using Application.Dto;
using Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return Ok(_mapper.Map<IEnumerable<CommunityDto>>(communities));
        }

        
        
             

        [HttpGet]
        [Route("AllComunity")]
        public async Task<IActionResult> GetAllCommunity(string nameCommunity)
        {
            var communities = await _communityService.GetCommunitiesName(nameCommunity);
            return Ok(_mapper.Map<IEnumerable<CommunityDto>>(communities));
            
        }

        [HttpGet]
        [Route("InformationCommunity")]
        public async Task<ActionResult> GetInformationCommunity(int IdCommunity)
        {
            var informationCommunity = await _communityService.GetInformationCommunityid(IdCommunity);
            return Ok(_mapper.Map<CommunityDto>(informationCommunity));
        }


        [HttpPost]
        [Route("RegisterCommunity")]
        public async Task<IActionResult> RegisterCommunity([FromBody] Community community)
        {
            return Ok(await _communityService.SetCommunity(community));
        }




        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] CommunityUserDto communityUserDto)
        {
            return Ok( await _communityService.SetRegisterUser(communityUserDto));
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] CommunityUserDto communityUserDto)
        {
            return Ok(await _communityService.SetDeleteUser(communityUserDto));
        }

        [HttpGet]
        [Route("GetUserId")]
        public async Task<IActionResult> GetUserId(int communityId, string userId)
        {
            var newRegisterUsert = new CommunityUser() { CommunityId = communityId, UserId = userId };

            return Ok(await _communityService.UserExistInCommunity(newRegisterUsert));
        }
        
    }
    
}
