using System.ComponentModel.DataAnnotations;

namespace WebApi_01_DataWithEntityFramework_CodeFirst.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
    }
}
