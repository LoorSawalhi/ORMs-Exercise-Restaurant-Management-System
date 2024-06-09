using FluentValidation;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Validators;

public class EmployeeValidator: AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(employee => employee.FirstName)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z ]*$");
        RuleFor(employee => employee.LastName)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z ]*$");
        RuleFor(employee => employee.Position)
            .NotEmpty()
            .NotNull()
            .Matches("^[a-zA-Z ]*$");
    }
}