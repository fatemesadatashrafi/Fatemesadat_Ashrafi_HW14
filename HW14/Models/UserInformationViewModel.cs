using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HW14.Models
{
    public class UserInformationViewModel
    {
        [Required(ErrorMessage = "وارد کردن نام الزامی می باشد.")]
        [MinLength(3, ErrorMessage = "طول نام نمی تواند کمتر از سه کاراکتر باشد.")]
        [MaxLength(30, ErrorMessage = "طول نام نمی تواند بیشتر از سی کاراکتر باشد.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی می باشد.")]
        [MinLength(3, ErrorMessage = "طول نام خانوادگی نمی تواند کمتر از سه کاراکتر باشد.")]
        [MaxLength(30, ErrorMessage = "طول نام خانوادگی نمی تواند بیشتر از سی کاراکتر باشد.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "وارد کردن شماره همراه الزامی می باشد.")]
        [RegularExpression(@"^09\d{9}", ErrorMessage = "شماره را اشتباه وارد کرده اید.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "وارد کردن تاریخ تولد الزامی می باشد.")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "وارد کردن کد دوره الزامی می باشد.")]
        [RegularExpression(@"^[2468]\d{2}$", ErrorMessage = "کد دوره را اشتباه وارد کرده اید.")]
        public int? BootcampCode { get; set; }
        [EnumDataType(typeof(Gender), ErrorMessage = "انتخاب جنسیت الزامی می باشد.")]
        public Gender Gender { get; set; }
        //[Range(typeof(bool), "true", "true", ErrorMessage = "قوانین سایت رو نمی پذیری؟")]
        [JsonIgnore]
        public bool AcceptingRules { get; set; }

    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
