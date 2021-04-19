namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Map")]
    public partial class Map
    {
        public Map(string pMapId, string pMapName, string pMapType)
        {
            this.MapId = pMapId;
            this.MapName = pMapName;
            this.MapType = pMapType;
        }

        public Map()
        {

        }

        [StringLength(4)]
        public string MapId { get; set; }

        [Required]
        [StringLength(20)]
        public string MapName { get; set; }

        [StringLength(10)]
        public string MapType { get; set; }

    }
}
