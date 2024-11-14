using IoT.Models;
using IoT.Services;
using IoT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IoTDataController : ControllerBase
    {
        private readonly IIoTDataService _iotDataService;

        public IoTDataController(IIoTDataService iotDataService)
        {
            _iotDataService = iotDataService;
        }

        [HttpGet("daily-average")]
        public IActionResult GetDailyAverage()
        {
            var dailyAverages = _iotDataService.GetDailyAverages();
            return Ok(dailyAverages);
        }

        [HttpGet("weekly-average")]
        public IActionResult GetWeeklyAverage()
        {
            var weeklyAverage = _iotDataService.GetWeeklyAverage();
            return Ok(new { WeeklyAverage = weeklyAverage });
        }

        [HttpGet("custom-average")]
        public IActionResult GetCustomAverage(DateTime startDate, DateTime endDate)
        {
            try
            {
                var average = _iotDataService.GetCustomAverage(startDate, endDate);
                return Ok(new { StartDate = startDate, EndDate = endDate, Average = average });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
