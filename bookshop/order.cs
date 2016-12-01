using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace bookshop
{
    [Table("bookshopdb.order")]
    [Bind(Exclude="OrderId")]
    public class order
    {
       [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage ="必须填写姓名")]
        [DisplayName("姓名")]
        [StringLength(20)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "必须填写收货地址")]
        [DisplayName("收货地址")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "必须填写联系电话")]  
        [DisplayName("联系电话")]
        [StringLength(11)]
        public  string Phone { get; set; }
        [Required(ErrorMessage = "必须填写邮编")]
        [DisplayName("联系邮编")]
        [StringLength(6)]
        public string PostalCode { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        public List<orderdetail> orderdetail { get; set; }
    }
}