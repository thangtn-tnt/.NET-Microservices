using System.Text;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.DTOs;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public HttpCommandDataClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformResponseDto plat)
        {
            var content = new StringContent(
              JsonSerializer.Serialize(plat),
              Encoding.UTF8,
              "application/json"
            );

            Console.WriteLine(_configuration["CommandService"]);

            var response = await _client.PostAsync($"{_configuration["CommandService"]}/api/c/Platforms", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync Post to Command");
            }
            else
            {
                Console.WriteLine("Not Sync Post to Command");
            }
        }
    }
}