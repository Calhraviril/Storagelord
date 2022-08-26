using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Storagelord
{
    public class Tuote
    {
        [Key]
        public int? ID { get; set; }
        public string? TUOTENIMI { get; set; }
        public float? TUOTEHINTA { get; set; }
        public int? VARASTOSALDO { get; set; }
    }
}
