namespace bookshop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bookshopdb.genre")]
    public partial class genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GenreId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public List<book> book { get; set; }
    }
}
