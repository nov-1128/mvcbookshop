
namespace bookshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookshopdb.author")]
    public class author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
}