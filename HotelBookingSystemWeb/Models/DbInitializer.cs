using HotelBookingSystemWeb.Models;

namespace HotelBookingSystem
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext db)
        {
            db.Database.EnsureCreated();

            if (db.RoomTypes.Any()) return;

            Random rand = new Random();

            // 1. Типы номеров
            var types = new RoomType[]
            {
                new RoomType{TypeName="Стандарт", Description="Обычный", Capacity=2, BasePrice=3000},
                new RoomType{TypeName="Люкс", Description="Крутой", Capacity=4, BasePrice=8000}
            };
            db.RoomTypes.AddRange(types);
            db.SaveChanges();

            // 2. Номера
            for (int i = 1; i <= 20; i++)
            {
                db.Rooms.Add(new Room
                {
                    RoomNumber = (100 + i).ToString(),
                    Floor = 1,
                    Status = "Свободен",
                    RoomTypeID = types[rand.Next(types.Length)].RoomTypeID
                });
            }
            db.SaveChanges();

            // 3. Гости
            var guests = new Guest[]
            {
                new Guest{FirstName="Иван", LastName="Иванов", PassportSeries="1234", PassportNumber="567890", PhoneNumber="999", Email="ivan@mail.ru"},
                new Guest{FirstName="Петр", LastName="Петров", PassportSeries="4321", PassportNumber="098765", PhoneNumber="888", Email="petr@mail.ru"}
            };
            db.Guests.AddRange(guests);
            db.SaveChanges();

            // 4. Сотрудники
            var employee = new Employee
            {
                FirstName = "Анна",
                LastName = "Сидорова",
                Position = "Администратор",
                PhoneNumber = "111",
                Email = "admin@hotel.com",
                HireDate = DateTime.Now.AddYears(-1),
                Salary = 50000
            };
            db.Employees.Add(employee);
            db.SaveChanges();

            // 5. Услуги
            var service = new AdditionalService { ServiceName = "Завтрак", Description = "Шведский стол", Price = 500 };
            db.AdditionalServices.Add(service);
            db.SaveChanges();

            // 6. Бронирование
            var roomList = db.Rooms.ToList();
            db.Bookings.Add(new Booking
            {
                GuestID = guests[0].GuestID,
                RoomID = roomList[0].RoomID,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddDays(2),
                TotalPrice = 6000,
                Status = "Подтверждено"
            });
            db.SaveChanges();
        }
    }
}