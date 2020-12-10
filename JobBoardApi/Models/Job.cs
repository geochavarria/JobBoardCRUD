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
        public string Job { get; set; } = Guid.NewGuid().ToString();
        public string  JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime CretedAt { get; set; }
        public DateTime ExpiresAt { get; set; }    
    }
}
