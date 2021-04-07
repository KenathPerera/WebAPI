using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TaskDetail
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string TaskName { get; set; }
        [Required]
        public int Progress { get; set; }
        [Required]

        [Column(TypeName = "varchar(10)")]
        public string DueDate { get; set; }
    }
}
