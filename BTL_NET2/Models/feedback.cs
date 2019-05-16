namespace BTL_NET2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("feedback")]
    public partial class feedback
    {
        public int id { get; set; }

        public int productid { get; set; }

        public int accountid { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public virtual account account { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
