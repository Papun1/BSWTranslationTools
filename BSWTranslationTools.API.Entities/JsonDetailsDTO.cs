using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BSWTranslationTools.API.Entities
{
    
    public class JsonDetailsDTO
    {
        [Key]
        public int JsonID { get; set; }
        public int ProjectId { get; set; }
        public int LangId { get; set; }
        public string Keys { get; set; }
        public string KeyValues { get; set; }
        public string Status { get; set; }

    }
    public class JsonDetailsNewDTO
    {
        [Key]
        public int JsonID { get; set; }
        public string Keys { get; set; }
        public string KeyValues1 { get; set; }
        public string KeyValues2 { get; set; }
        public string Status { get; set; }

    }
    public class JsonDetailsCreatedDTO
    {
        [Key]
        public int ProjectId { get; set; }
        public int LangId { get; set; }
        public string Keys { get; set; }
        public string KeyValues { get; set; }
    

    }
    public class JsonDetailsUpdatedDTO
    {
        [Key]
        public int JsonID { get; set; }
        public int ProjectId { get; set; }
        public int LangId { get; set; }
        public string Keys { get; set; }
        public string KeyValues { get; set; }
 

    }

}
