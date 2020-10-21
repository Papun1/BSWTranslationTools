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
        [Required(ErrorMessage = "Please enter Keys")]
        public string Keys { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues1")]
        public string KeyValues1 { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues2")]
        public string KeyValues2 { get; set; }
      

    }
    public class JsonDetailsKeyCreateDTO
    {
        [Key]
        
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Please enter Keys")]
        public string Keys { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues1")]
        public string KeyValues1 { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues2")]
        public string KeyValues2 { get; set; }


    }
    public class JsonDetailsKeyUpdateDTO
    {
        [Key]
        public int JsonKeyID { get; set; }
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Please enter Keys")]
        public string Keys { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues1")]
        public string KeyValues1 { get; set; }
        [Required(ErrorMessage = "Please enter KeyValues2")]
        public string KeyValues2 { get; set; }


    }
}
