using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.UpdateDoctorWorkingHour;

public class UpdateDoctorWorkingHourCommandValidator
    : AbstractValidator<UpdateDoctorWorkingHourCommand>
{
    public UpdateDoctorWorkingHourCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty();

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Start time must be earlier than end time.");
    }
}