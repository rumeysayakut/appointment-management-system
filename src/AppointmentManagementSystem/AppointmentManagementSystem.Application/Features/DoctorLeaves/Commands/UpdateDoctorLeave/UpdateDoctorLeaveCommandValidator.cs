using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.DoctorLeaves.Commands.UpdateDoctorLeave;

public class UpdateDoctorLeaveCommandValidator
    : AbstractValidator<UpdateDoctorLeaveCommand>
{
    public UpdateDoctorLeaveCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Doctor leave id is required.");

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