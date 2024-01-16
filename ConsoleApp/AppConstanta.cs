namespace ConsoleApp
{
    public static class AppConstanta
    {

      public  const string apiUrl = "http://localhost:45100/api/person";



        public static string GenerateRandomName()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";

            string randomString = new string(Enumerable.Repeat(chars, random.Next(6,12))
              .Select(s => s[random.Next(s.Length)]).ToArray());

            randomString = char.ToUpper(randomString[0]) + randomString.Substring(1);

            return randomString;
        }
    }
}
