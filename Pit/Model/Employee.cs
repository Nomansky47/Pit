namespace Pit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(255)]
        public string Login { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public bool isAdmin { get; set; }

        [StringLength(255)]
        public string Surname { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Patronymic { get; set; }
    }
}
