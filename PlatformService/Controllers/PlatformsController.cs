using System.Net.NetworkInformation;
using System;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Services;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _service;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandClient;

        public PlatformsController(IPlatformService service,
        IMapper mapper,
        ICommandDataClient commandClient)
        {
            _service = service;
            _mapper = mapper;
            _commandClient = commandClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformResponseDto>> GetPlatforms()
        {
            Console.WriteLine("Getting platforms.........");

            var platforms = _service.GetPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformResponseDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformResponseDto> GetPlatformById(int id)
        {
            Console.WriteLine("Getting platforms " + id);

            var platform = _service.GetPlatformById(id);

            if (platform is not null)
            {
                return Ok(_mapper.Map<PlatformResponseDto>(platform));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformRequestDto>> CreatePlatformAsync(PlatformRequestDto platformRequestDto)
        {
            var platform = _mapper.Map<Platform>(platformRequestDto);
            
            _service.CreatePlatform(platform);
            _service.SaveChange();

            var platformResponseDto = _mapper.Map<PlatformResponseDto>(platform);

            try
            {
                await _commandClient.SendPlatformToCommand(platformResponseDto);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Could not send sync: {ex.Message}");
            }

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformResponseDto.Id }, platformResponseDto);
        }

    }
}