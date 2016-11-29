namespace bookshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookshopdb.user")]
    public partial class user
    {
        [Key]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [Required]
        [StringLength(5)]
        public string permission { get; set; }
    }
}
