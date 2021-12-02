namespace mvc_btl.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TACGIA")]
    public partial class TACGIA
    {
        [Key]
        public int MaTG { get; set; }

        
        [StringLength(50)]
        [Required(ErrorMessage = "Tên tác giả không để trống!")]
        [DisplayName("Tên tác giả")]
        public string TenTG { get; set; }

        [StringLength(1000)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Ngày sinh không để trống!")]
        [DisplayName("Ngày sinh")]
        public string Ngaysinh { get; set; }

        [StringLength(100)]
        [DisplayName("Quê quán ")]
        [Required(ErrorMessage = "Quê quán không để trống!")]
        public string Quequan { get; set; }

        [StringLength(1000)]
        [DisplayName("Tiểu sử ")]
        public string Tieusu { get; set; }
    }
}
