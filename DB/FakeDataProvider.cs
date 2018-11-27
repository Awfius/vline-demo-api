using System;
using VLine.API.Models;
using VLine.API.Repositories;

namespace VLine.API.DB
{
    public static class FakeDataProvider
    {
        public static void AddTimetables(DatabaseContext context)
        {
            var fakeTimetable1 = new Timetable
            {
                Id = "0ad64db7-ce0b-4aff-a862-0af8953f567f",
                DepartStation = "Southern Cross",
                ArrivalStation = "Deer Park",
                DepartDateTime = DateTime.UtcNow.AddDays(1),
                ArrivalDateTime = DateTime.UtcNow.AddMinutes(20),
            };
            context.Timetables.Add(fakeTimetable1);

            var fakeTimetable2 = new Timetable
            {
                Id = "8c4714c1-f853-4532-9e46-f89746f4d5e8",
                DepartStation = "Southern Cross",
                ArrivalStation = "Ballarat",
                DepartDateTime = DateTime.UtcNow.AddDays(2),
                ArrivalDateTime = DateTime.UtcNow.AddMinutes(30),
            };

            context.Timetables.Add(fakeTimetable2);

            context.SaveChanges();
        }
    }
}
