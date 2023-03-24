using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataRedisCaching.Models
{
    public class GujaratStates
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int STCode { get; set; }
        public string StateName { get; set; }
        public int DTCode { get; set; }
        public string DistrictName { get; set; }
        public int SDTCode { get; set; }
        public string SubDistrictName { get; set; }
        public int TownCode { get; set; }
        public string AreaName { get; set; }
    }
}
