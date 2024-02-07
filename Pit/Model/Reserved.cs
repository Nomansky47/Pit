namespace Pit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserved")]
    public partial class Reserved
    {
        [Key]
        public int ReserveID { get; set; }

        public int VisitorID { get; set; }

        public int Row { get; set; }

        public int Seat { get; set; }

        public int Price { get; set; }

        public DateTime ReserveStart { get; set; }

        public DateTime? ReserveEnd { get; set; }

        public virtual Visitors Visitors { get; set; }
    }
}
