using Microsoft.Extensions.Logging;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stack.Infrastructure.SeedData;

public sealed class StackExchangeService
{
    private readonly ILogger<StackExchangeService> _logger;
    private readonly HttpClient _httpClient;

    public StackExchangeService(HttpClient httpClient,ILogger<StackExchangeService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Wrapper<T>?> GetTagsAsync<T>(string url)
        where T : class, IStackMarker
    {
        try
        {
            var tagsResponse = await _httpClient.GetAsync(url);
            if (tagsResponse.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                using (var decompressedStream = new GZipStream(await tagsResponse.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                using (var decompressedReader = new StreamReader(decompressedStream))
                {

                    var result = await decompressedReader.ReadToEndAsync();
                    var response = JsonSerializer.Deserialize<Wrapper<T>>(result);
                    _logger.LogInformation("Data fetched successfully.");
                    return response;
                }
            }
            return null;
        }
        catch (Exception ex) 
        {
            _logger.LogError(ex, $"Unable to fetch data from StackExchange api from {url}");
            throw new Exception();
        }
        

    }
}
