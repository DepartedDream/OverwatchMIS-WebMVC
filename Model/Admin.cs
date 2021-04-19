namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public Admin(string pAdminName, string pAdminPwd)
        {
            this.AdminName = pAdminName;
            this.AdminPwd = pAdminPwd;
        }

        public Admin()
        {

        }

        [StringLength(10)]
        public string AdminName { get; set; }

        [Key]
        [StringLength(10)]
        public string AdminPwd { get; set; }
    }
}
