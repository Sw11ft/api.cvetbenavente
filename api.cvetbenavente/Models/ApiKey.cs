using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.cvetbenavente.Models
{
    public class ApiKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ApplicationUserId { get; set; }

        [Required]
        public string Key { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser;
    }
}
