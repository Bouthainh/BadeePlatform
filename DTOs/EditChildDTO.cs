using System.ComponentModel.DataAnnotations;

namespace BadeePlatform.DTOs
{
    public class EditChildDTO
    {

        [Required(ErrorMessage = "اسم الطفل مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يتجاوز 100 حرف")]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]+$", ErrorMessage = "الاسم يجب أن يحتوي على حروف فقط")]

        public string ChildName { get; set; }

        [Required(ErrorMessage = "الجنس مطلوب")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "العمر مطلوب")]
        [Range(4, 8, ErrorMessage = "العمر يجب أن يكون بين 4 و 8 سنوات")]
        public int Age { get; set; }

        [Required(ErrorMessage = "يجب اختيار المدينة")]
        public string City { get; set; }

        [Required(ErrorMessage = "يجب اختيار المدرسة")]
        public Guid SchoolId { get; set; }

        [Required(ErrorMessage = "يجب اختيار المرحلة الدراسية")]
        public Guid GradeId { get; set; }

        [Required(ErrorMessage = "يجب اختيار الفصل")]
        public Guid ClassId { get; set; }

    }
}
