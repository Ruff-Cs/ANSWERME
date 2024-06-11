using System.Text.Json;

namespace ANSWER_ME.Models
{
    public class ApiCalls
    {
        /*
        public static async Task<Category> GetCategories()
        {
            Category Items = new();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://opentdb.com/api_category.php");
            request.Headers.Add("Cookie", "PHPSESSID=72cdadf27d54abd59dc94d160725eb64");
            var response = await client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();
                Items = JsonSerializer.Deserialize<Category>(content.Result);
                return Items;
            }
            return null;
        }
        */

        public static async Task<Trivia> GetTrivia(string url)
        {
            try
            {
                Trivia Items = new();
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"{url}");
                request.Headers.Add("Cookie", "PHPSESSID=058c23f1dc133e7f8d075f5c8af9fdb3");
                var response = await client.SendAsync(request).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<Trivia>(content.Result);
                    return Items;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
