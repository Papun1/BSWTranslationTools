using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSWTranslationTools.API.Entities
{
    [Table("tblJsonDetails")]
    public class JsonDetails
    {
        [Key]
        public int JsonID { get; set; }
        public int ProjectId { get; set; }
        public int LangId { get; set; }
        public string Keys { get; set; }
        public string KeyValues { get; set; }
        public string Status { get; set; }

    }
}
