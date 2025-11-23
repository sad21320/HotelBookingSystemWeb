using HotelBookingSystemWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemWeb.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Room> Rooms { get; set; }
    }
}