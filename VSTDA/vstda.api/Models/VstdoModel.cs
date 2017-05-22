using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vstda.api.Models
{
    public class VstdoModel
    {
        [Key]
        public int KeyID { get; set; }
        public string Text { get; set; }
        public int Priority { get; set; }
        public DateTime CreationDate { get; set; }
    }
}