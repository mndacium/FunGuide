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
        public string Name { get; set; } = String.Empty;
        public int SportId { get; set; }
    }
}
