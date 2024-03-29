﻿using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Location
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly HttpClient _httpClient;

        public GeoLocationService()
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        public async Task<GeoInfoDto> GetGeoInfo()
        {
            {
                //I have already created this function under GeoInfoProvider class.
                var ipAddress = await GetIPAddress();
                // When geting ipaddress, call this function and pass ipaddress as given below
                var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + "?access_key=<your key>");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<GeoInfoDto>(json);
                    return model;
                }
                return null;
            }
        }

        private async Task<string> GetIPAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }
    }
}
