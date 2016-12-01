using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace bookshop
{
    [Table("bookshopdb.orderdetails")]
    public class orderdetail
    {
        [Key]
        public int ODetailId { get; set; }
        public int OrderId { get; set; }
        public  int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public  virtual book book { get; set; }
        public virtual order order { get; set; }
    }
}