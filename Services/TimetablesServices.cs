using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VLine.API.DTOs;
using VLine.API.Models;
using VLine.API.Repositories;

namespace VLine.API.Services
{
    public interface ITimetablesService
    {
        IEnumerable<Timetable> GetTimetables();
        Timetable GetTimetableById(string id);
        CreateTimetableDto CreateTimetable(CreateTimetableDto timetable);
        Timetable UpdateTimetable(TimetableDto timetable);
        bool DeleteTimetable(string id);
    }

    public class TimetablesService : ITimetablesService
    {
        private readonly IMapper _mapper;
        private readonly ITimetablesRepository _timetablesRepository;

        public TimetablesService(IMapper mapper, ITimetablesRepository timetablesRepository)
        {
            _mapper = mapper;
            _timetablesRepository = timetablesRepository;
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            return _timetablesRepository.GetTimetables();
        }

        public Timetable GetTimetableById(string id)
        {
            return _timetablesRepository.GetTimetableById(id);
        }

        public CreateTimetableDto CreateTimetable(CreateTimetableDto createTimetableDto)
        {
            var timetable = _mapper.Map<Timetable>(createTimetableDto);
            timetable.Id = Guid.NewGuid().ToString();

            var timetableCreated = _timetablesRepository.CreateTimetable(timetable);

            return timetableCreated != null ? _mapper.Map<CreateTimetableDto>(timetableCreated) : null;
        }

        public Timetable UpdateTimetable(TimetableDto timetableDto)
        {
            var timetableFound = GetTimetableById(timetableDto.Id);
            if (timetableFound == null) throw new Exception($"{timetableFound.Id} not found");

            timetableFound.DepartStation = timetableDto.DepartStation;
            timetableFound.DepartDateTime = timetableDto.DepartDateTime;
            timetableFound.ArrivalStation = timetableDto.ArrivalStation;
            timetableFound.ArrivalDateTime = timetableDto.ArrivalDateTime;
            return _timetablesRepository.UpdateTimetable(timetableFound);
        }
        public bool DeleteTimetable(string id)
        {
            var deleteSuccess = _timetablesRepository.DeleteTimetable(id);
            if (!deleteSuccess) throw new Exception($"{ id } cannot be deleted");
            return deleteSuccess;
        }

    }
}
