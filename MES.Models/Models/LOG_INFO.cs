using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Models.Models
{
    public class LOG_INFO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string REQUEST_ID { get; set; }

        [MaxLength(50)]
        public string IP { get; set; }

        [MaxLength(100)]
        public string SERVICE_NAME { get; set; }

        [MaxLength(100)]
        public string METHOD_NAME { get; set; }

        public string REQUEST_BODY { get; set; }
        public string RESPONSE_MODEL { get; set; }
        public string MESSAGE { get; set; }

        [MaxLength(100)]
        public string USER_INFO { get; set; }

        [MaxLength(50)]
        public string STATUS { get; set; }

        public DateTime CREATED_DATE { get; set; } = DateTime.Now;
    }
}
