﻿using PlatformService.Dtos;

using System.Text;
using System.Text.Json;

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

        public async Task SendPlatformToCommand(PlatformReadDTO platform)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platform),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _client.PostAsync("http://localhost:7013/api/c/platforms/", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(" --> Sync Post to Command Service was Ok");
            }
            else
            {
                Console.WriteLine(" --> Sync Post to Command Service was NOT Ok");
            }



        }
    }
}