using System.Text.RegularExpressions;

public class Eldoria
{
    // Extracts hidden secrets from scroll content using the {* ... *} pattern
    public static List<string> ExtractSecrets(string scrollContent)
    {
        Regex secretsPattern = new Regex(@"\{\*(.*?)\*\}");
        MatchCollection matches = secretsPattern.Matches(scrollContent);
        return matches.Select(m => m.Groups[1].Value).ToList();
    }

    private static async Task FetchAndDecipherScroll(string url)
    {
        Console.WriteLine($"Fetching scroll from {url}");
        try
        {
            using (var httpClient = new HttpClient())
            {
                string scrollContent = await httpClient.GetStringAsync(url);

                // Extract and display the secrets
                foreach (var secret in ExtractSecrets(scrollContent))
                {
                    Console.WriteLine(secret);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static void Run()
    {
        string url = "https://raw.githubusercontent.com/microsoft/CopilotAdventures/main/Data/scrolls.txt";
        FetchAndDecipherScroll(url).Wait();
    }
}
