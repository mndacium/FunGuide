using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGuide.Shared
{
    public class SportsmanSearchModel
    {
        [RegularExpression(@"[a-zA-Z'А-ЩЬЮЯҐЄІЇа-щьюяґєії ыЫ]{2,20}$", ErrorMessage = "Characters are not allowed.")]
        public string? Name { get; set; }
        [Range(1942, 2008, ErrorMessage = "Year must be between {1} and {2}")]
        public int? BirthYear { get; set; }
        [Range(14, 80, ErrorMessage = "Age must be between {1} and {2}")]
        public int? Age { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightTo { get; set; }


        public double? WeightFrom { get; set; }

        public double? WeightTo { get; set; }
        public int? CitizenshipId { get; set; }
        public string? Team { get; set; }

        public int? SportId { get; set; }
    }
}
