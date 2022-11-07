using Microsoft.EntityFrameworkCore;
using CustomersManagement.Models;

namespace CustomersManagement.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new DataContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<DataContext>>()))
      {
        if (context.Customers.Any())
        {
          return;
        }

        context.Customers.AddRange(
            new Customer
            {
              Cpf = "12345678901",
              Name = "Usuário",
              Birthday = DateTime.Parse("1996-5-27"),
              Cep = "12235181",
              Address = "Rua Iraci Gonçalves Ferreira",
              City = "São José dos Campos",
              State = "São Paulo",
              Genre = "Masculino",
            },

            new Customer
            {
              Cpf = "98765432109",
              Name = "Usuário_2",
              Birthday = DateTime.Parse("1988-7-02"),
              Cep = "12233540",
              Address = "Rua Teófilo Otoni",
              City = "São José dos Campos",
              State = "São Paulo",
              Genre = "Feminino",
            }
        );
        context.SaveChanges();
      }
    }
  }
}