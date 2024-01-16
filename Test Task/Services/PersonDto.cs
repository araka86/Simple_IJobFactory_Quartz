using System.ComponentModel.DataAnnotations;

namespace Test_Task.Services
{
    public class PersonDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
