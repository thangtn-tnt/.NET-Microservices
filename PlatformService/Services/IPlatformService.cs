using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Services
{
    public interface IPlatformService
    {
        bool SaveChange();
        IEnumerable<Platform> GetPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);
    }
}