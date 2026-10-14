using System.ComponentModel.DataAnnotations;

namespace MES.Models.Models
{
    public class ROLE_INFO : BaseEntity
    {
        [MaxLength(50)]
        public string ROLE_NAME { get; set; }

        [MaxLength(200)]
        public string DESCRIPTION { get; set; }
    }
}
