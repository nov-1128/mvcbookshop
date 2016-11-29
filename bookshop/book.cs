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
        [DisplayName("�鼮����")]
        public int GenreId { get; set; }
        [DisplayName("����")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage ="������������")]
        [DisplayName("����")]
        [StringLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "�������뵥��")]
        [Range(1.00,100.00,ErrorMessage ="�����޶���1-100Ԫ֮��")]
        [DisplayName("����")]
        public decimal Price { get; set; }
        public virtual genre genre { get; set; }
        public virtual author author { get; set; }
    }
}
