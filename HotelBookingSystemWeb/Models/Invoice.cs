using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int BookingID { get; set; }
        public Booking Booking { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public ICollection<InvoiceService> InvoiceServices { get; set; }
    }
}