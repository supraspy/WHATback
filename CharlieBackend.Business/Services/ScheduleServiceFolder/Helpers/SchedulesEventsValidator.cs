﻿using System.Text;
using System.Threading.Tasks;
using CharlieBackend.Core.DTO.Schedule;
using CharlieBackend.Data.Repositories.Impl.Interfaces;

namespace CharlieBackend.Business.Services.ScheduleServiceFolder.Helpers
{
    public class SchedulesEventsValidator : ISchedulesEventsValidator
    {
        private readonly IUnitOfWork _unitOfWork;

        public SchedulesEventsValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> ValidateCreateScheduleRequestAsync(CreateScheduleDto request)
        {
            StringBuilder error = new StringBuilder(string.Empty);

            if (!await _unitOfWork.StudentGroupRepository.IsEntityExistAsync(request.Context.GroupID))
            {
                error.Append(" Group does not exist");
            }

            if (request.Context.MentorID.HasValue && !await _unitOfWork.MentorRepository.IsEntityExistAsync(request.Context.MentorID.Value))
            {
                error.Append(" Mentor does not exist");
            }

            if (request.Context.ThemeID.HasValue && !await _unitOfWork.ThemeRepository.IsEntityExistAsync(request.Context.ThemeID.Value))
            {
                error.Append(" Theme does not exist");
            }

            return error.Length > 0 ? error.ToString() : null;
        }

        public async Task<string> ValidateEventOccuranceId(long id)
        {
            string result = null;

            if (!await _unitOfWork.EventOccurrenceRepository.IsEntityExistAsync(id))
            {
                result = $"EventOccurance id={id} does not exist";
            }

            return result;
        }

        public async Task<string> ValidateGetEventsFilteredRequest(ScheduledEventFilterRequestDTO request)
        {
            StringBuilder error = new StringBuilder(string.Empty);

            if (request.CourseID.HasValue && !await _unitOfWork.CourseRepository.IsEntityExistAsync(request.CourseID.Value))
            {
                error.Append(" Course does not exist");
            }

            if (request.GroupID.HasValue && !await _unitOfWork.StudentGroupRepository.IsEntityExistAsync(request.GroupID.Value))
            {
                error.Append(" Group does not exist");
            }

            if (request.MentorID.HasValue && !await _unitOfWork.MentorRepository.IsEntityExistAsync(request.MentorID.Value))
            {
                error.Append(" Mentor does not exist");
            }

            if (request.StudentAccountID.HasValue && !await _unitOfWork.StudentRepository.IsEntityExistAsync(request.StudentAccountID.Value))
            {
                error.Append(" Student does not exist");
            }

            if (request.ThemeID.HasValue && !await _unitOfWork.ThemeRepository.IsEntityExistAsync(request.ThemeID.Value))
            {
                error.Append(" Theme does not exist");
            }

            return error.Length > 0 ? error.ToString() : null;
        }

        public async Task<string> ValidateScheduledEventId(long id)
        {
            string result = null;

            if (!await _unitOfWork.ScheduledEventRepository.IsEntityExistAsync(id))
            {
                result = $"ScheduledEvent id={id} does not exist";
            }

            return result;
        }
    }
}
