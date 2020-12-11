using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardApi.Models
{
    public class Jobs
    {
        [Key]
        public int Job { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Description length can't be more than 8.")]
        public string  JobTitle { get; set; }
        [Required()]
        [StringLength(250, ErrorMessage = "Description length can't be more than 250.")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpiresAt { get; set; }    
    }
}
