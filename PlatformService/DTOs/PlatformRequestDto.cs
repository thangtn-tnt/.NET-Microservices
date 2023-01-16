using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.DTOs
{
    public class PlatformRequestDto
    {        
        public int Id { get; set; }     
        public string Name { get; set; }        
        public string Publisher { get; set; }        
        public string Cost { get; set; }
    }
}