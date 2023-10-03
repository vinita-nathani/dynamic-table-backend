using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dynamic_table_backend.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace dynamic_table_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateTimetableController : ControllerBase
    {
        private readonly generateTimetableService _timetableService;

        public GenerateTimetableController(generateTimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpPost]
        public IActionResult GenerateTimeTable( Form request)
        {
            try
            {
                var result = _timetableService.GenerateTimeTable(request);

                var jsonResult = JsonSerializer.Serialize(result);

                // Return the JSON response with an OK status code (200) for success
                return Ok(jsonResult);
                //return result; // Return OK for success
            }
            catch (Exception ex)
            {
                // Log the exception
                return null; // Return BadRequest for errors
            }
        }
    }
}
