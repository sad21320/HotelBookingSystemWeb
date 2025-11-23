using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class AdditionalService
    {
        [Key]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<InvoiceService> InvoiceServices { get; set; }
    }
}