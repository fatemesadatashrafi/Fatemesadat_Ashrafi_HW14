namespace HW14.Models
{
    public class UserInformationViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public int BootcampCode { get; set; }
        public Gender Gender { get; set; }

    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
