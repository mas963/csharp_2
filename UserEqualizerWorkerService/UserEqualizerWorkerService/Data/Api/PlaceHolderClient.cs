using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEqualizerWorkerService.Models.PlaceHolder;

namespace UserEqualizerWorkerService.Data.Api;

public class PlaceHolderClient
{
    private readonly HttpClient _httpClient;

    public PlaceHolderClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PlaceHolderUser>> GetPlaceHolderUsers()
    {
        var uri = "/users";
        var responseString = await _httpClient.GetStringAsync(uri);
        var placeHolderUsers = JsonConvert.DeserializeObject<List<PlaceHolderUser>>(responseString);
        return placeHolderUsers ?? new List<PlaceHolderUser>();
    }
}
