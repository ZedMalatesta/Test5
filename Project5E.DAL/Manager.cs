namespace Project5E.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manager")]
    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            SaleInfo = new HashSet<SaleInfo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ManagerID { get; set; }

        [Required]
        [StringLength(50)]
        public string ManagerName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleInfo> SaleInfo { get; set; }
    }
}
