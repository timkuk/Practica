using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Booking.Domain.Interfaces;

namespace Booking.Prepopulator.Parsers
{
    public static class EntitiesParser
    {
        public static async Task<IEnumerable<T>> ParseEntitiesAsync<T>(string path) where T : IDocument
        {
            using var reader = new StreamReader(path);
            var jsonString = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<T>>(jsonString);
        }
    }
}