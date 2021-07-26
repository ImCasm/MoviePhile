using Application.Common.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MoviePhile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        private readonly IAdvertisingService _advertisingService;

        public AdvertisingController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdvertising(Advertising advertising)
        {
            return Ok(await _advertisingService.CreateAdvertising(advertising));
        }
    }
}
