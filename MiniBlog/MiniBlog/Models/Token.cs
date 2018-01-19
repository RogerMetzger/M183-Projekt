using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniBlog.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }       
        public int UserId { get; set; }
        public int TokenNr { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime? DeletedOn { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}