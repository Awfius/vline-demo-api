using Microsoft.AspNetCore.Mvc;
using VLine.API.DTOs;
using VLine.API.Services;

namespace VLine.API.Controllers
{
    [Route("api/[controller]")]
    public class TimetablesController : Controller
    {
        private ITimetablesService _timetablesService;

        public TimetablesController(ITimetablesService timetablesService)
        {
            _timetablesService = timetablesService;
        }

        // GET api/timetables
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_timetablesService.GetTimetables());
        }

        // GET api/timetables/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/timetables
        [HttpPost]
        public IActionResult Post([FromBody] CreateTimetableDto createTimeTableDto)
        {
            if (ModelState.IsValid)
            {
                var createTimetable = _timetablesService.CreateTimetable(createTimeTableDto);
                if (createTimetable != null)
                {
                    return Ok(createTimetable);
                }
            }
            return BadRequest();
        }

        // PUT api/timetables/:id
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TimetableDto timetable)
        {
            if (ModelState.IsValid)
            {
                if (id == timetable.Id)
                {
                    var updatedTimetable = _timetablesService.UpdateTimetable(timetable);
                    return Ok(updatedTimetable);
                }
            }
            return BadRequest();
        }

        // DELETE api/timetables/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var deletedSuccess = _timetablesService.DeleteTimetable(id);
            return deletedSuccess ? (IActionResult)Ok() : BadRequest();
        }
    }
}
