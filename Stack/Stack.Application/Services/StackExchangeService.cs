using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stack.Application.Services;

public sealed class StackExchangeService
{
    private readonly HttpClient _httpClient;

    public StackExchangeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Wrapper<Tag>?> GetTagsAsync(string url)
    {
        var tagsResponse = await _httpClient.GetAsync(url);
        if (tagsResponse.Content.Headers.ContentEncoding.Contains("gzip"))
        {
            using (var decompressedStream = new GZipStream(await tagsResponse.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
            using (var decompressedReader = new StreamReader(decompressedStream))
            {

                var result = await decompressedReader.ReadToEndAsync();
                // Deserializacja JSON do obiektu
                var response = JsonSerializer.Deserialize<Wrapper<Tag>>(result);
                return response;
            }
        }
        throw new Exception();

    }
}
