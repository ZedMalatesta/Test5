namespace Project5E.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleInfo")]
    public partial class SaleInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SaleInfoID { get; set; }

        public int ManagerID { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(50)]
        public string Product { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Cost { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
