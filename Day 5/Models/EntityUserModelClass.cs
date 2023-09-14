using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employeeproject.Models
{
    public class Usser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    
}
