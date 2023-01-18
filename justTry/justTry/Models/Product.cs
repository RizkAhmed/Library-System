namespace justTry.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("production.products")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            stocks = new HashSet<stock>();
        }

        [Key]
        public int product_id { get; set; }

        [Required]
        [StringLength(255)]
        public string product_name { get; set; }

        public int brand_id { get; set; }

        public int category_id { get; set; }

        public short model_year { get; set; }

        public decimal list_price { get; set; }

        public string product_new_name { get; set; }

        public virtual brand brand { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stock> stocks { get; set; }
    }
}
