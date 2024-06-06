using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Validators;

using FluentValidation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z ]*$");
        RuleFor(customer => customer.LastName)
            .NotNull()
            .NotEmpty()
            .Matches("^[a-zA-Z ]*$");
        RuleFor(customer => customer.Email)
            .NotEmpty()
            .NotNull()
            .Matches("[a-zA-Z0-9]+\\.[a-zA-Z0-9]+@[a-z]\\.com");
    }
}