using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OpenAiService
{
    private readonly HttpClient _httpClient;
    // כאן היה openAiKey

    public OpenAiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetLessonFromOpenAiAsync(string category , string subCategory)
    {
        var prompt = $"תחזיר לי רק את השיעור, בלי שום הסבר או תגובה נוספת. תחזיר לי שיעור מעניין בנושא {category} עם התמקדות ב-{subCategory}";
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api.openai.com/v1/chat/completions"),
            Headers =
            {
                //{ "Authorization", $"Bearer {_apiKey}" }
            },
            Content = new StringContent(JsonSerializer.Serialize(new
            {
                model = "gpt-4",  // או gpt-3.5-turbo
                messages = new[]
                {
                    new { role = "system", content = "אתה מורה שמסביר שיעור בצורה ידידותית." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            }), Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        // לשלוף את התוכן של ההשלמה מתוך ה-JSON:
        using var doc = JsonDocument.Parse(body);
        var result = doc.RootElement
                        .GetProperty("choices")[0]
                        .GetProperty("message")
                        .GetProperty("content")
                        .GetString();

        return result!;
    }
}

