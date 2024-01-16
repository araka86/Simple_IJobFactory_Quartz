using Newtonsoft.Json;
using System.Text;
using Test_Task.Models;

namespace ConsoleApp
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _apiUrl;

        public ApiService(string apiUrl)
        {
            _apiUrl = apiUrl;
            _client = new HttpClient();
        }

        public async Task CreatePersonAsync()
        {
            try
            {
                Person newPerson = new Person
                {
                    Id = Guid.NewGuid(),
                    FirstName = AppConstanta.GenerateRandomName(),
                    LastName = AppConstanta.GenerateRandomName(),
                };

                string jsonPerson = JsonConvert.SerializeObject(newPerson);

                await PostDataAsync(jsonPerson);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task PostDataAsync(string jsonPerson)
        {
            Thread.Sleep(2000);
            using (StringContent content = new StringContent(jsonPerson, Encoding.UTF8, "application/json"))
            {

                HttpResponseMessage postResponse = await _client.PostAsync(_apiUrl, content);

                if (postResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("A new person has been successfully created");
                }
                else
                {
                    Console.WriteLine($"Error when creating a person. Status code: {postResponse.StatusCode}");
                }
            }
        }

        public async Task GetAllPersons()
        {
            Thread.Sleep(2000);

            HttpResponseMessage getResponse = await _client.GetAsync(_apiUrl);

            if (getResponse.IsSuccessStatusCode)
            {
                string responseBody = await getResponse.Content.ReadAsStringAsync();

                List<Person>? listOfPeople = JsonConvert.DeserializeObject<List<Person>>(responseBody);
                if (listOfPeople != null)
                {
                    Console.WriteLine("List of people:\n" + string.Join("\n", listOfPeople));
                }
                else
                {
                    Console.WriteLine("There is no list of the people");
                }
            }
            else
            {
                Console.WriteLine($"API request error: {getResponse.StatusCode}");
            }
        }
    }
}
