namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skill")]
    public partial class Skill
    {
        public Skill(string pSkillId, string pSkillName, string pSkillDetail, string pHeroId)
        {
            this.SkillId = pSkillId;
            this.SkillName = pSkillName;
            this.SkillDetail = pSkillDetail;
            this.HeroId = pHeroId;
        }

        public Skill()
        {

        }

        [StringLength(5)]
        public string SkillId { get; set; }

        [StringLength(20)]
        public string SkillName { get; set; }

        [Required]
        [StringLength(500)]
        public string SkillDetail { get; set; }

        [StringLength(4)]
        public string HeroId { get; set; }
    }
}
