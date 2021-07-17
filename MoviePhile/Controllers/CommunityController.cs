﻿using Application.Common.Interfaces.Auth;
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

        /**
        [HttpGet("{name}")]
        public async Task<ActionResult> GetByName(string name)
        {
            var comunitie = await _communityService.GetCommunityByName(name);
            return Ok(_mapper.Map<CommunityDto>(comunitie));
        }
        **/       

        [HttpGet("{nameCommunity}")]
        public async Task<ActionResult> GetAllByName(string nameCommunity)
        {
            var communities = await _communityService.GetCommunitiesName(nameCommunity);
            return Ok(_mapper.Map<IEnumerable<CommunityDto>>(communities));
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
        [Route("RegisterUser")]
        public async Task<IActionResult> DeleteUser([FromBody] CommunityUserDto communityUserDto)
        {
            return Ok(await _communityService.SetDeleteUser(communityUserDto));
        }
    }
    
}
