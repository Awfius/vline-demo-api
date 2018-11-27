using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VLine.API.DB;
using VLine.API.Models;

namespace VLine.API.Repositories
{
    public interface ITimetablesRepository
    {
        IEnumerable<Timetable> GetTimetables();
        Timetable GetTimetableById(string id);
        Timetable CreateTimetable(Timetable timetable);
        Timetable UpdateTimetable(Timetable timetable);
        bool DeleteTimetable(string id);
    }

    public class TimetablesRepository : ITimetablesRepository
    {
        private readonly DatabaseContext _dbContext;

        public TimetablesRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            return _dbContext.Timetables.AsEnumerable();
        }

        public Timetable GetTimetableById(string id)
        {
            var foundTimetable = _dbContext.Timetables.FirstOrDefault(x => x.Id == id);
            return foundTimetable;
        }

        public Timetable CreateTimetable(Timetable timetable)
        {
            try
            {
                _dbContext.Timetables.Add(timetable);
                var successRecords = _dbContext.SaveChanges();
                if (successRecords > 0)
                {
                    return timetable;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Timetable UpdateTimetable(Timetable timetable)
        {
            try
            {
                _dbContext.Update(timetable);
                var successRecords = _dbContext.SaveChanges();
                if (successRecords > 0)
                {
                    return timetable;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool DeleteTimetable(string id)
        {
            try
            {
                var timetable = _dbContext.Timetables.AsNoTracking().SingleOrDefault(x => x.Id== id);
                _dbContext.Timetables.Remove(timetable);
                var successRecords = _dbContext.SaveChanges();
                if (successRecords > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
