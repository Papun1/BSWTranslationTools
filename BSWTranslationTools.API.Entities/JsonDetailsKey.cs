using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSWTranslationTools.API.Entities
{
    [Table("tblJsonDetailsKey")]
    public class JsonDetailsKey
    {
        [Key]
        public int JsonKeyID { get; set; }
        public int ProjectId { get; set; }
        public string Keys { get; set; }
        public string KeyValues1 { get; set; }
        public string KeyValues2 { get; set; }
        public string Status { get; set; }
      
    }
}
