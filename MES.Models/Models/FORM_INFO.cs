using System.ComponentModel.DataAnnotations;

namespace MES.Models.Models
{
    public class FORM_INFO : BaseEntity
    {
        [MaxLength(100)]
        public string FORM_NAME { get; set; }

        [MaxLength(200)]
        public string URL { get; set; }

        public int PARENT_ID { get; set; } = 0;
        public int ORDER_INDEX { get; set; } = 0;
        [MaxLength(50)]
        public string ICON { get; set; }
    }
}
