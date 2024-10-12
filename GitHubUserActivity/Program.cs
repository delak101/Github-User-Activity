//disable
using System.Text.Json;


class Program
{
    static async Task Main(string[] args)
    {
        string username = args[0];
        string url = $"https://api.github.com/users/{username}/events";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            try {
                // get request to the GitHub API
                HttpResponseMessage response = await client.GetAsync(url);

                // check if the request was successful
                response.EnsureSuccessStatusCode();

                // read the response body as a string
                string jsonData = await response.Content.ReadAsStringAsync();

                // parse the JSON data into a JsonElement to access the data easily
                var events = JsonSerializer.Deserialize<JsonElement>(jsonData);

                Console.WriteLine($"@{username}'s Recent Activity: \n");
                
                
                // the events are stored in an array, so we use EnumerateArray to iterate over them and access the properties of each event using the indexer
                foreach (var e in events.EnumerateArray())
                {
                    string ?eventType = e.GetProperty("type").GetString();
                    string ?repoName = e.GetProperty("repo").GetProperty("name").GetString();
                    string ?createdAt = e.GetProperty("created_at").GetString();

                    if (eventType == "PushEvent")
                    {
                        Console.WriteLine($"Pushed to {repoName} at {createdAt}");

                    } else if (eventType == "PullRequestEvent") {
                        string ?action = e.GetProperty("payload").GetProperty("action").GetString();
                        string ?prTitle = e.GetProperty("payload").GetProperty("pull_request").GetProperty("title").GetString();
                        Console.WriteLine($"{action} pull request '{prTitle}' in {repoName} at {createdAt}");
                    
                    } else if (eventType == "CreateEvent") {
                    
                        string ?refType = e.GetProperty("payload").GetProperty("ref_type").GetString();
                        Console.WriteLine($"Created a {refType} in {repoName} at {createdAt}");
                    
                    } else if (eventType == "IssuesEvent") {
                        string ?action = e.GetProperty("payload").GetProperty("action").GetString();
                        string ?issueTitle = e.GetProperty("payload").GetProperty("issue").GetProperty("title").GetString();
                        Console.WriteLine($"{action} issue '{issueTitle}' in {repoName} at {createdAt}");
                    }
                }

            } catch (HttpRequestException e) {
                Console.WriteLine($"Request failed: {e.Message}");
            }

        }
    }
}