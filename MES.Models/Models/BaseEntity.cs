using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MES.Models.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            IS_ACTIVE = 1;
            IS_DELETE = 0;
            CREATED_DATE = DateTime.Now;
            UPDATED_DATE = DateTime.Now;
            REMARKS = "";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int ID { get; set; }
        public virtual int IS_ACTIVE { get; set; }
        public virtual int IS_DELETE { get; set; }
        public virtual DateTime CREATED_DATE { get; set; }
        public virtual DateTime? UPDATED_DATE { get; set; }
        public virtual int CREATED_BY { get; set; }
        public virtual int UPDATED_BY { get; set; }
        [MaxLength(500)]
        public virtual string REMARKS { get; set; }
    }
}
