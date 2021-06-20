namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string UsereName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
