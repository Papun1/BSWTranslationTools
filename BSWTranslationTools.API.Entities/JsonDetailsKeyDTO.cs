using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BSWTranslationTools.API.Entities
{
    public class JsonDetailsKeyDTO
    {
        [Key]
        public int JsonKeyID { get; set; }
        public int ProjectId { get; set; }
        public string Keys { get; set; }
        public string KeyValues1 { get; set; }
        public string KeyValues2 { get; set; }
        public string Status { get; set; }

    }
    public class JsonDetailsKeyCreateDTO
    {
        [Key]
        
        public int ProjectId { get; set; }
        public string Keys { get; set; }
        public string KeyValues1 { get; set; }
        public string KeyValues2 { get; set; }
        public string Status { get; set; }

    }
    public class JsonDetailsKeyUpdateDTO
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
