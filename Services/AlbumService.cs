using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services
{
    public class AlbumService : ICRUD<Album>
    {
        private readonly HttpClient http;

        public AlbumService(HttpClient client)
        {
            http = client;
        }

        public async Task delete(string id)
        {
            try
            {
                await http.DeleteAsync($"album/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<IEnumerable<Album>> getAll()
        {
            try
            {
                return JsonSerializer.Deserialize<IEnumerable<Album>>(
                    await http.GetStringAsync($"album"));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Album> getById(string id)
        {
            try
            {
                return JsonSerializer.Deserialize<Album>(
                    await http.GetStringAsync($"album/{id}"));
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task save(Album entity)
        {
            try
            {
                var json = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");
                await http.PostAsync("album", json);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task update(Album entity)
        {
            try
            {
                var json = new StringContent(JsonSerializer.Serialize(entity),
               Encoding.UTF8, "application/json");
                await http.PutAsync($"album/{entity.idAlbum}", json);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
