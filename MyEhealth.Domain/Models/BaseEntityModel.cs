namespace MyEhealth.Domain.Models
{
    public class BaseEntityModel
    {
        public string? CreatedBy { get; set; }

        public long? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public long? UpdatedOn { get; set; }
    }
}
