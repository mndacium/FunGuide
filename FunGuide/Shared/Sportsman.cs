using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGuide.Shared   
{
    public class Sportsman : BaseEntity
    {
        [Required(ErrorMessage = "The first name must be provided")]
        [RegularExpression(@"[a-zA-Z'А-ЩЬЮЯҐЄІЇа-щьюяґєії ыЫ]{2,20}$", ErrorMessage = "Characters are not allowed.")]
        [StringLength(20, ErrorMessage = "length of First Name must be between {2} and {1}.", MinimumLength = 2)]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "The first name must be provided")]
        [RegularExpression(@"[a-zA-Z'А-ЩЬЮЯҐЄІЇа-щьюяґєії ыЫ]{2,20}$", ErrorMessage = "Characters are not allowed.")]
        [StringLength(20, ErrorMessage = "{0} length of Second name must be between {2} and {1}.", MinimumLength = 2)]
        public string LastName { get; set; }= String.Empty;

        [DataType(DataType.Date)]
        
        [Range(typeof(DateTime), "1/1/1942", "1/1/2008",ErrorMessage = "Date must be between {1} and {2}")]
        public DateTime? BirthDate { get; set; }

        [Range(14,80,ErrorMessage ="Age must be between {1} and {2}")]
        public int Age { get;set;
        }

        [Range(1.40, 2.40, ErrorMessage = "Height must be between {1} and {2} metres")]
        public double Height { get; set; }

        [Range(35, 200, ErrorMessage = "Weight must be between {1} and {2} kilos")]
        public double Weight { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,20}$", ErrorMessage = "Characters are not allowed.")]
        public Citizenship? Citizenship { get; set; }
        public int CitizenshipId { get; set; }

        [Required(ErrorMessage ="Sport must me required")]
        public Sport? Sport { get; set; }
        public int SportId { get; set; }

        [StringLength(20, ErrorMessage = "Length of Team Name must be less than {1}.")]
        public string? Team { get; set;}

    }
}
