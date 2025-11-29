using System.ComponentModel.DataAnnotations;

namespace BadeePlatform.DTOs
{
    public class AddChildDTO
    {
        [Required(ErrorMessage = "رقم هوية الطفل مطلوب")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "رقم الهوية يجب أن يتكون من 10 أرقام")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "رقم الهوية يجب أن يحتوي على أرقام فقط")]
        public string ChildId { get; set; }

        [Required(ErrorMessage = "اسم الطفل مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يتجاوز 100 حرف")]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط")]

        public string? ChildName { get; set; }

        [Required(ErrorMessage = "الجنس مطلوب")]
        public string? Gender { get; set; } 

        [Required(ErrorMessage = "العمر مطلوب")]
        [Range(4, 8, ErrorMessage = "العمر يجب أن يكون بين 4 و 8 سنوات")]
        public int? Age { get; set; }

        [StringLength(20)]
        public string? RelationshipType { get; set; }

        [Required(ErrorMessage = "يجب اختيار المدينة")]
        public string? City { get; set; } 

        [Required(ErrorMessage = "يجب اختيار المدرسة")]
        public Guid SchoolId { get; set; }

        [Required(ErrorMessage = "يجب اختيار المرحلة الدراسية")]
        public Guid GradeId { get; set; }

        [Required(ErrorMessage = "يجب اختيار الفصل")]
        public Guid ClassId { get; set; }

        public bool AllowEducatorAccess { get; set; } = false;
    }
}