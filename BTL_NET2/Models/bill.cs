namespace BTL_NET2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            billdetail = new HashSet<billdetail>();
        }

        public int id { get; set; }

        public int accountId { get; set; }

        public int total { get; set; }

        public int status { get; set; }

        [Column(TypeName = "date")]
        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<billdetail> billdetail { get; set; }
    }
}
