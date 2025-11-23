using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class InvoiceService
    {
        [Key]
        public int InvoiceServiceID { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public int ServiceID { get; set; }
        public AdditionalService AdditionalService { get; set; }
    }
}