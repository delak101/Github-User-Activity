class Program
{
    static void Main(string[] args)
    {
        string username = args[0];
        string url = $"https://api.github.com/users/{username}/events";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            try {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            } catch (HttpRequestException e) {
                Console.WriteLine($"Request failed: {e.Message}");
            }

        }
    }
}