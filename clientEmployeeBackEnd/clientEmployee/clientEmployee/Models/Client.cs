using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Siret { get; set; }
       
    }
}
