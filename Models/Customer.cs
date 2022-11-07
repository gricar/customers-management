using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.Models
{
  public class Customer
  {
    public int Id { get; set; }

    [Display(Name = "CPF")]
    [StringLength(14, MinimumLength = 11)]
    [Required]
    public string Cpf { get; set; }

    [Display(Name = "Nome")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Data de Nascimento")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime Birthday { get; set; }

    [Display(Name = "Sexo")]
    [Required]
    public string Genre { get; set; }

    [MaxLength(9)]
    [Display(Name = "CEP")]
    [Required]
    public string Cep { get; set; }

    [Display(Name = "Endereço")]
    public string? Address { get; set; }

    [Display(Name = "Estado")]
    public string? State { get; set; }

    [Display(Name = "Cidade")]
    public string? City { get; set; }
  }
}