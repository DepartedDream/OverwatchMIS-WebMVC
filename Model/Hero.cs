namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hero")]
    public partial class Hero
    {
        public Hero(string pHeroId, string pHeroName, string pHeroType)
        {
            this.HeroId = pHeroId;
            this.HeroName = pHeroName;
            this.HeroType = pHeroType;
        }

        public Hero()
        {

        }

        [StringLength(4)]
        public string HeroId { get; set; }

        [StringLength(10)]
        public string HeroName { get; set; }

        [StringLength(4)]
        public string HeroType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skill { get; set; }
    }
}
