using HotelBookingSystemWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Status { get; set; } // Свободен, Занят
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int RoomTypeID { get; set; }
        public RoomType RoomType { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}