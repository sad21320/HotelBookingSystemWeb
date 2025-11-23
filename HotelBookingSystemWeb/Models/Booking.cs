using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Подтверждено, Отменено
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int GuestID { get; set; }
        public Guest Guest { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}