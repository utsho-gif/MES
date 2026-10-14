namespace MES.Models.Models
{
    public class ROLE_FORMS : BaseEntity
    {
        public int ROLE_ID { get; set; }
        public int FORM_ID { get; set; }
        public bool CAN_VIEW { get; set; } = true;
        public bool CAN_CREATE { get; set; } = false;
        public bool CAN_EDIT { get; set; } = false;
        public bool CAN_DELETE { get; set; } = false;
    }
}
