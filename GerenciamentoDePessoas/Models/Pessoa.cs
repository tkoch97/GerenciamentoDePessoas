using GerenciamentoDePessoas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDePessoas.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            
        }

        public Pessoa(int id, string nome, string sobrenome, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(10, MinimumLength = 2, ErrorMessage ="O nome deve ter no mínimo 2 caracteres e no máximo 10.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "O sobrenome deve ter no mínimo 2 caracteres e no máximo 40.")]
        public string Sobrenome { get; set; } = string.Empty;

        [CustomValidation(typeof(Pessoa), "ValidarDataNascimento")]
        [Required(ErrorMessage = "Por favor, informa sua data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 dígitos sem caracteres especiais")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        public ETipoSanguineo TipoSanguineo { get; set; }

        public static ValidationResult ValidarDataNascimento(DateTime dataNascimento)
        {
            if(dataNascimento.Date >= DateTime.Today)
            {
                return new ValidationResult("A data de nascimento não pode ser igual ou maior que a data atual.");
            }
            return ValidationResult.Success!;
        }
    }
}
