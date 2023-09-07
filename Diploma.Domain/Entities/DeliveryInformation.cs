using System.ComponentModel.DataAnnotations.Schema;

namespace Diploma.Domain.Entities
{
    public class DeliveryInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public List<int?> OrderIds { get; set; } = new List<int?>();
        [NotMapped]
        public bool? IsLinkedToOrder { get; set; } = false;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
