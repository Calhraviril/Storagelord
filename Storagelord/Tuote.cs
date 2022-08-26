using System.ComponentModel.DataAnnotations;

namespace Storagelord
{
    public class Tuote
    {
        [Key]
        public int? ID { get; set; }
        public string? TUOTENIMI { get; set; }
        public double? TUOTEHINTA { get; set; }
        public int? VARASTOSALDO { get; set; }
    }
}
