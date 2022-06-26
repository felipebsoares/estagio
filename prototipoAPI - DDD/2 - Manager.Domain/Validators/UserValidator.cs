using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entidade não pode estar vazia")

                .NotNull()
                .WithMessage("Entidade não pode estar nula");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome não pode estar vazio")

                .NotNull()
                .WithMessage("Nome não pode estar nulo")

                .MinimumLength(6)
                .WithMessage("Nome deve ter no mínimo 6 caracteres")

                .MaximumLength(80)
                .WithMessage("Nome deve ter no máximo 80 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha não pode estar vazia")

                .NotNull()
                .WithMessage("Senha não pode estar nula")

                .MinimumLength(6)
                .WithMessage("Senha deve ter no mínimo 6 caracteres")

                .MaximumLength(80)
                .WithMessage("Senha deve ter no máximo 80 caracteres");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email não pode estar vazio")

                .NotNull()
                .WithMessage("Email não pode estar nulo")

                .MinimumLength(10)
                .WithMessage("Email deve ter no mínimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("Email deve ter no máximo 180 caracteres")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Email informado não é válido");

        }
    }
}