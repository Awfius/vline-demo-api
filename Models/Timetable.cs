using System;

namespace VLine.API.Models
{
    public class Timetable
    {
        public string Id { get; set; }

        public string DepartStation { get; set; }

        public string ArrivalStation { get; set; }

        public DateTime DepartDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }
    }
}
