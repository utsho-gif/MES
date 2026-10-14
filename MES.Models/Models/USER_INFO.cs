using System.ComponentModel.DataAnnotations;

namespace MES.Models.Models
{
    public class USER_INFO : BaseEntity
    {
        [MaxLength(50)]
        public string NAME { get; set; }

        [MaxLength(50)]
        public string USER_NAME { get; set; }

        public int CHANNEL_ID { get; set; }

        [MaxLength(50)]
        public string EMPLOYEE_ID { get; set; }

        [MaxLength(100)]
        public string EMAIL { get; set; }

        [MaxLength(20)]
        public string MSISDN { get; set; }

        [MaxLength(50)]
        public string PASSWORD { get; set; }

        public int APPROVED_BY { get; set; }
        public int BRANCH_ID { get; set; }
        public bool IS_APPROVED { get; set; }
        public int ROLE_ID { get; set; }
        public bool HAS_APPROVER { get; set; } = false;
        public int APPROVER_TYPE { get; set; }
    }
}
