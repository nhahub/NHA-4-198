using Center_Education_Management.view_models;
using Microsoft.AspNetCore.Mvc;

namespace Center_Education_Management.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new HomeIndexVM
            {
                Stats = new List<StatItem>
                {
                    new() { Icon = "building-2", Value = "+250", Label = "سنتر يستخدم المنصة" },
                    new() { Icon = "users", Value = "+50K", Label = "طالب مسجل" },
                    new() { Icon = "calendar", Value = "+1200", Label = "مدرس نشط" },
                    new() { Icon = "smile", Value = "98%", Label = "رضا العملاء" },
                    new() { Icon = "headphones", Value = "24/7", Label = "دعم فني متواصل" },
                },
                Features = new List<IconTextItem>
                {
                    new() { Icon = "users-round", Title = "إدارة الطلاب", Description = "إضافة وإدارة بيانات الطلاب ومتابعة مستواهم" },
                    new() { Icon = "user-cog", Title = "إدارة المدرسين", Description = "تنظيم بيانات المدرسين والصلاحيات" },
                    new() { Icon = "book-marked", Title = "المحتويات والفصول", Description = "إدارة محتوى الفصول بمنصة سهلة" },
                    new() { Icon = "calendar-check", Title = "الحضور والغياب", Description = "تسجيل الحضور باستخدام QR Code أو يدويًا" },
                    new() { Icon = "clipboard-list", Title = "الامتحانات", Description = "إنشاء امتحانات إلكترونية وتصحيح تلقائي" },
                    new() { Icon = "book-open", Title = "الواجبات", Description = "إرسال واجبات ومتابعة تسليمها" },
                    new() { Icon = "dollar-sign", Title = "المدفوعات", Description = "متابعة الرسوم والمدفوعات والفواتير الشهرية" },
                    new() { Icon = "bar-chart-3", Title = "التقارير والإحصائيات", Description = "تقارير تفصيلية تساعدك في اتخاذ القرارات" },
                },
                Steps = new List<IconTextItem>
                {
                    new() { Icon = "user-plus", Title = "سجل حسابك", Description = "أنشئ حسابًا جديدًا بسهولة" },
                    new() { Icon = "users-round", Title = "أضف المدرسين والطلاب", Description = "أدخل البيانات والصلاحيات والفصول" },
                    new() { Icon = "user-cog", Title = "أضف بيانات السنتر", Description = "أضف معلومات السنتر والإعدادات" },
                    new() { Icon = "rocket", Title = "ابدأ تشغيل النظام", Description = "استمتع بإدارة السنتر بسهولة" },
                },
                ForWho = new List<RoleItem>
                {
                    new() { ImageUrl = "/assets/person-owner.jpg", Title = "أصحاب السناتر", Description = "إدارة شاملة للسنتر: متابعة الربح، التقارير، والمدفوعات من أي مكان." },
                    new() { ImageUrl = "/assets/person-teacher.jpg", Title = "المدرسون", Description = "إنشاء المحتوى، إعداد الامتحانات، ومتابعة أداء الطلاب بسهولة." },
                    new() { ImageUrl = "/assets/person-student.jpg", Title = "الطلاب", Description = "حضور، امتحانات، واجبات، درجات، ومتابعة كل شيء بتطبيق واحد." },
                    new() { ImageUrl = "/assets/person-parent.jpg", Title = "أولياء الأمور", Description = "متابعة الأبناء، الحضور، الدرجات، والمدفوعات أولًا بأول." },
                },
                Why = new List<IconTextItem>
                {
                    new() { Icon = "shield-check", Title = "آمن وموثوق", Description = "حماية عالية للبيانات ونسخ احتياطية دورية لكل معلوماتك." },
                    new() { Icon = "smartphone", Title = "سهل الاستخدام", Description = "واجهة عربية بسيطة تعمل على الكمبيوتر والجوال بلا تعقيد." },
                    new() { Icon = "headphones", Title = "دعم فني متميز", Description = "فريق دعم جاهز لمساعدتك 24/7 عبر الشات والهاتف والبريد." },
                    new() { Icon = "refresh-cw", Title = "تحديثات مستمرة", Description = "يتطور النظام باستمرار بناءً على احتياجات السناتر الحقيقية." },
                    new() { Icon = "file-text", Title = "تقارير ذكية", Description = "تقارير تفصيلية ودقيقة تساعدك على اتخاذ قرارات أفضل لسنترك." },
                    new() { Icon = "monitor-smartphone", Title = "متوافق مع جميع الأجهزة", Description = "يعمل بسلاسة على الكمبيوتر والتابلت والموبايل بدون تنصيب." },
                },
                Faqs = new List<FaqItem>
                {
                    new() { Question = "هل يناسب النظام جميع المراحل الدراسية؟", Answer = "نعم، يدعم النظام كل المراحل من الابتدائي إلى الجامعي." },
                    new() { Question = "هل يمكن استخدام النظام على الجوال؟", Answer = "نعم، النظام متوافق مع جميع الأجهزة والهواتف." },
                    new() { Question = "هل بياناتي آمنة؟", Answer = "نستخدم تشفيرًا متقدمًا ونسخًا احتياطية دورية." },
                    new() { Question = "هل يوجد دعم فني؟", Answer = "نعم، دعم فني 24/7 عبر الشات والهاتف والبريد." },
                    new() { Question = "ما هي طرق الدفع المتاحة؟", Answer = "فيزا، ماستر كارد، تحويل بنكي، ومحافظ إلكترونية." },
                    new() { Question = "هل يوجد نسخة تجريبية؟", Answer = "نعم، نوفر نسخة تجريبية مجانية لمدة 14 يومًا." },
                },
                Team = new List<TeamMemberItem>
                {
                    new() { ImageUrl = "/assets/af.jpg", Name = "Ali Fathy", Role = "Backend Developer (.NET)" },
                    new() { ImageUrl = "/assets/am.jpg", Name = "Ahmed El-Meligy", Role = "Team Leader & Backend Developer (.NET)" },
                    new() { ImageUrl = "/assets/ag.jpg", Name = "Ahmed Gomaa", Role = "Frontend Developer" },
                    new() { ImageUrl = "/assets/aa.jpg", Name = "Ahmed Ashraf", Role = "Frontend Developer" },
                    new() { ImageUrl = "/assets/me.jpg", Name = "Mohamed Abo-Al ezz", Role = "Database Developer" },
                    new() { ImageUrl = "/assets/ma.jpg", Name = "Mohamed Abo-Shanab", Role = "Database Developer" },
                },
            };

            return View(vm);
        }
    }
}
