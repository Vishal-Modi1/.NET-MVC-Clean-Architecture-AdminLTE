namespace MyEhealth.Domain.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        public bool IsActive { get; set; }
    }
}
