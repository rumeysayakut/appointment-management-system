using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.DoctorWorkingHours.Commands.CreateDoctorWorkingHour;

public class CreateDoctorWorkingHourCommandValidator : AbstractValidator<CreateDoctorWorkingHourCommand>
{
    public CreateDoctorWorkingHourCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty();

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Start time must be earlier than end time.");
    }
}