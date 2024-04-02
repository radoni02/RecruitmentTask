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
    private readonly HttpClient _httpClient;

    public StackExchangeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Wrapper<T>?> GetTagsAsync<T>(string url)
        where T : class, IStackMarker
    {
        var tagsResponse = await _httpClient.GetAsync(url);
        if (tagsResponse.Content.Headers.ContentEncoding.Contains("gzip"))
        {
            using (var decompressedStream = new GZipStream(await tagsResponse.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
            using (var decompressedReader = new StreamReader(decompressedStream))
            {

                var result = await decompressedReader.ReadToEndAsync();
                var response = JsonSerializer.Deserialize<Wrapper<T>>(result);
                return response;
            }
        }
        throw new Exception();

    }
}
