
using ExtensionMethodsForWorkingWithAsyncOperations;
try
{
    string url = "https://jsonplaceholder.typicode.com/posts";
    string data = await FetchDataAsync(url).WithTimeout(2000);
    Console.WriteLine(data);
}
catch (TimeoutException ex)
{
    Console.WriteLine($"Timeout error: {ex.Message}");
}


async Task<string> FetchDataAsync(string url)
{
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseData = await response.Content.ReadAsStringAsync();
        return responseData;
    }
}