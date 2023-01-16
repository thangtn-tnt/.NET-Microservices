using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformResponseDto>();
            CreateMap<PlatformRequestDto, Platform>();
        }

    }
}