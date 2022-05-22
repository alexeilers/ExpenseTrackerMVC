using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than 0")]
        public double Amount { get; set; }

        [DisplayName("Due Date")]
        [Required]
        public int DueDate { get; set; }
    }
}
