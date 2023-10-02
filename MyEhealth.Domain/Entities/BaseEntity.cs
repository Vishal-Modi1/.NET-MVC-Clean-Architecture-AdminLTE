namespace MyEhealth.Domain.Entities
{
    public class BaseEntity
    {
        public string? CreatedBy { get; set; }

        public long? CreatedOn { get; set; }
        
        public string? UpdatedBy { get; set; }

        public long? UpdatedOn { get; set; }
    }
}
