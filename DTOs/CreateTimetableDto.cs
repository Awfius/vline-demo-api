using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace VLine.API.DTOs
{
    public class CreateTimetableDto
    {
        [Required]
        public string DepartStation { get; set; }

        [Required]
        public string ArrivalStation { get; set; }

        public DateTime DepartDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }
    }
}
