using CharlieBackend.Core.DTO.Schedule;
using CharlieBackend.Core.Entities;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBackend.Api.SwaggerExamples.SchedulesController
{
    internal class GetAllSchedulesResponse : IExamplesProvider<List<ScheduleDto>>
    {
        public List<ScheduleDto> GetExamples()
        {
            return new List<ScheduleDto>()
            {
                new ScheduleDto
                {
                    Id = 11,
                    StudentGroupId = 24,
                    LessonStart = new TimeSpan(10, 15, 00),
                    LessonEnd = new TimeSpan(11, 00, 00),
                    DayNumber = 3,
                    RepeatRate = RepeatRate.Daily
                },
                new ScheduleDto
                {
                    Id = 12,
                    StudentGroupId = 31,
                    LessonStart = new TimeSpan(9, 15, 00),
                    LessonEnd = new TimeSpan(10, 00, 00),
                    DayNumber = 2,
                    RepeatRate = RepeatRate.Weekly
                }
            };
        }
    }
}
