using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        [DisplayName("Due Date")]
        public int DueDate { get; set; }
    }
}
