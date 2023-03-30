using System.ComponentModel.DataAnnotations;

namespace ODataRedisCaching.Models
{
    //DIstrict model for database
    [Serializable]
    public class District
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int STCode { get; set; } = 24;

        [Required]
        [MaxLength(100)]
        public string StateName { get; set; }

        [Required]
        [Range(400,500,ErrorMessage ="Negative values of district code are not allowed")]
        public int DTCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string DistrictName { get; set; }

        [Required]
        [Range(3500, 4000, ErrorMessage ="Negative values of subdistrict code are not allowed")]
        public int SDTCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubDistrictName { get; set; }

        [Required]
        [Range(800000, 850000, ErrorMessage = "Negative values of town code are not allowed")]
        public int TownCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string AreaName { get; set;}
    }
}
