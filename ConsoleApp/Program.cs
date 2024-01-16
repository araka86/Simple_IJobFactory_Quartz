using ConsoleApp;

class Program
{
    static async Task Main()
    {

        ApiService apiService = new ApiService(AppConstanta.apiUrl);
        await apiService.CreatePersonAsync();
        await apiService.GetAllPersons();


        Console.ReadKey();
    }
}
