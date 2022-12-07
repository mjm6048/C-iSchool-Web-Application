using System.Net.Http.Headers;

namespace iSchoolWebApp.Services
{
    public class DataRetrieval
    {
        public async Task<string> GetData(string d)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                //before adding the using Headers at the top
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //after adding it
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try {
                    HttpResponseMessage response = await client.GetAsync(d, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    // go read it in, all we have at the moment is pointers
                    var data = await response.Content.ReadAsStringAsync();
                    //this is just a string
                    return data;
                }
                catch (HttpRequestException hre)
                {
                    return "HttpRequest: " + hre.Message;
                }
                catch (Exception e)
                {
                    return "Exception: " + e.Message;
                }
            }
        }
    }
}
