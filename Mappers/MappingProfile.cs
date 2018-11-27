using AutoMapper;

namespace VLine.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTOs to Models
            CreateMap<DTOs.TimetableDto, Models.Timetable>();
            CreateMap<DTOs.CreateTimetableDto, Models.Timetable>();

            // Models to DTOs
            CreateMap<Models.Timetable, DTOs.TimetableDto>();
            CreateMap<Models.Timetable, DTOs.CreateTimetableDto>();
        }
    }
}
