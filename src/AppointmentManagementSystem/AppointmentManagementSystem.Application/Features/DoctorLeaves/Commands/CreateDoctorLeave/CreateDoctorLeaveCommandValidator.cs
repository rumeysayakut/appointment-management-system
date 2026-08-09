using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.CreateDoctorLeave;

public class CreateDoctorLeaveCommandValidator
    : AbstractValidator<CreateDoctorLeaveCommand>
{
    public CreateDoctorLeaveCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty()
            .WithMessage("Doctor is required.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.");

        RuleFor(x => x)
            .Must(x => x.StartDate.Date <= x.EndDate.Date)
            .WithMessage("Leave start date cannot be after end date.");
    }
}