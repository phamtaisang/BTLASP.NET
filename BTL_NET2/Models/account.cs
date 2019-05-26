namespace BTL_NET2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account()
        {
            bill = new HashSet<bill>();
            feedback = new HashSet<feedback>();
        }

        public int id { get; set; }

        [Display(Name = "Họ Và Tên : ")]
        [Required(ErrorMessage ="{0} Không được để trống nhé ! ")]
        [StringLength(255)]
        public string name { get; set; }

        [Display(Name = "Đia chỉ Email:")]
        [Required(ErrorMessage = "Không được để trống nhé ! ")]
        [StringLength(255)]
        public string email { get; set; }

        [Display(Name = "Mật khẩu : ")]
        [Required(ErrorMessage = "Không được để trống nhé ! ")]
        [StringLength(255)]
        public string password { get; set; }

        [Display(Name = "Địa chỉ : ")]
        [Required(ErrorMessage = "Không được để trống nhé ! ")]
        [StringLength(255)]
        public string address { get; set; }

        [Display(Name = "Số điện thoại : ")]
        [Required(ErrorMessage = "Không được để trống nhé ! ")]
        [StringLength(15)]
        public string phone { get; set; }

        public byte role { get; set; }

        public byte status { get; set; }

        public DateTime created_at { get; set; }

        public DateTime update_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedback { get; set; }
    }
}
