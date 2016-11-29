namespace bookshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    [Table("bookshopdb.book")]
    [Bind(Exclude = "Id")]
    public partial class book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("书籍种类")]
        public int GenreId { get; set; }
        [DisplayName("作者")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="必须输入书名")]
        [DisplayName("书名")]
        [StringLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "必须输入单价")]
        [Range(1.00,100.00,ErrorMessage ="单价限定在1-100元之间")]
        [DisplayName("单价")]
        public decimal Price { get; set; }
        public virtual genre genre { get; set; }
        public virtual author author { get; set; }
    }
}
