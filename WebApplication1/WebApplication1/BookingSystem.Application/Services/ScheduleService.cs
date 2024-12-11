using BookingSystem.BookingSystem.Application.Interfaces;
using BookingSystem.BookingSystem.Infrastructure.Repositories;

namespace BookingSystem.BookingSystem.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<Schedule> CreateScheduleAsync(CreateScheduleRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var schedule = new Schedule
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                CreatedDate = DateTime.Now
            };

            var createdSchedule = await _scheduleRepository.AddAsync(schedule);
            return createdSchedule;
        }

        public async Task<Schedule> GetScheduleByIdAsync(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found.");

            return schedule;
        }

        
        public async Task<Schedule> UpdateScheduleAsync(Guid scheduleId, UpdateScheduleRequest request)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found.");

            schedule.Title = request.Title ?? schedule.Title;
            schedule.Description = request.Description ?? schedule.Description;
            schedule.StartDate = request.StartDate ?? schedule.StartDate;
            schedule.EndDate = request.EndDate ?? schedule.EndDate;
            schedule.Location = request.Location ?? schedule.Location;
            schedule.ModifiedDate = DateTime.Now;

            var updatedSchedule = await _scheduleRepository.UpdateAsync(schedule);
            return updatedSchedule;
        }

        
        public async Task<bool> DeleteScheduleAsync(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found.");

            var isDeleted = await _scheduleRepository.DeleteAsync(scheduleId);
            return isDeleted;
        }

        // Get all schedules
        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            return schedules;
        }

        // Get schedules by date range (optional)
        public async Task<IEnumerable<Schedule>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var schedules = await _scheduleRepository.GetByDateRangeAsync(startDate, endDate);
            return schedules;
        }
    }
}