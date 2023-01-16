using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly ApplicationDbContext _context;
        public PlatformService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform platform)
        {
            if (platform is null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}