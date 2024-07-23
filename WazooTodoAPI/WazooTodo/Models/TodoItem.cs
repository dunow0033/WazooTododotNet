using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace WazooTodo.Models
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public String Description { get; set; }

        //public bool isComplete { get; set; }

        //public DateTimeOffset CreatedAt { get; set; }

        //public DateTimeOffset UpdatedAt { get; set; }
    }
}
