using System.ComponentModel.DataAnnotations;

namespace Center_Education_Management.view_models
{
    // خطوة 1: بيانات الطالب الأساسية (الفورم الأول في الصفحة الرئيسية)
    public class StudentLeadStep1VM
    {
        [Required(ErrorMessage = "الاسم مطلوب")]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم التلفون مطلوب")]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(150)]
        [EmailAddress(ErrorMessage = "بريد إلكتروني غير صحيح")]
        public string? Email { get; set; }

        // لازم يطابق حرفيًا اسم صف في جدول EducationalStage
        [Required(ErrorMessage = "السنة الدراسية مطلوبة")]
        public string Grade { get; set; } = string.Empty;
    }

    // خطوة 2: بعد اختيار السنتر، بنفس بيانات الخطوة 1 + الـ CenterId
    public class StudentLeadWizardVM : StudentLeadStep1VM
    {
        [Required]
        public int CenterId { get; set; }
    }

    // خطوة 3 (النهائية): بعد اختيار المدرس، كل البيانات + TeacherId
    public class StudentLeadFinalVM : StudentLeadWizardVM
    {
        [Required(ErrorMessage = "اختيار المدرس مطلوب")]
        public int TeacherId { get; set; }
    }
}
