using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {

        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }


        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ser maior que 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser nulo");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser nulo");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser nulo");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataNascimento)} não pode ser nulo");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser nulo");

            RuleFor(x => x.DataContratacao)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.DataContratacao)} não pode ser nulo");

            RuleFor(x => x.ComissaoPercentual)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} não pode ser nulo")
                .LessThanOrEqualTo(100).WithMessage(x => $"O campo {nameof(x.ComissaoPercentual)} deve ter valor até 100%");

            RuleFor(x => x.MetaMensal)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.MetaMensal)} não pode ser nulo")
                .GreaterThan(0).WithMessage(x => $"O campo {nameof(x.MetaMensal)} deve possuir valor maior que zero");

        }
    }
}
