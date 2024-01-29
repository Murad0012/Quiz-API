using FluentValidation;

namespace WebApplication1.DTOs.Account
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("UserName cannot be empty").MinimumLength(4).WithMessage("Minimum length is 5 chars!");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password cannot be empty").MinimumLength(4).WithMessage("Minimum length is 5 chars!");
        }
    }
}
