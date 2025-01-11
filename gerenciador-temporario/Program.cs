using System;
using System.Collections.Generic;
using System.Linq;

class Contrato
{
  public string Nome { get; set; }
  public string Departamento { get; set; }
  public int Dias { get; set; }
  public decimal ValorDiaria { get; set; }
}

class Program
{
  static void Main(string[] args)
  {
    try
    {
      // Solicitar o orçamento
      Console.Write("Informe o orçamento total: ");
      if (!decimal.TryParse(Console.ReadLine(), out decimal orcamento))
      {
        Console.WriteLine("Orçamento inválido. Insira um valor numérico.");
        return;
      }

      // Iniciar coleta de contratos
      List<Contrato> listaContratos = new();
      Console.WriteLine("Adicione os contratos. Para finalizar, deixe o nome em branco e pressione Enter.");

      while (true)
      {
        Console.Write("Nome do contrato (ou Enter para finalizar): ");
        string nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome)) break;

        Console.Write("Departamento: ");
        string departamento = Console.ReadLine();

        Console.Write("Dias de contrato: ");
        if (!int.TryParse(Console.ReadLine(), out int dias))
        {
          Console.WriteLine("Número de dias inválido. Tente novamente.");
          continue;
        }

        Console.Write("Valor diário: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valorDiaria))
        {
          Console.WriteLine("Valor diário inválido. Tente novamente.");
          continue;
        }

        // Adicionar contrato à lista
        listaContratos.Add(new Contrato
        {
          Nome = nome,
          Departamento = departamento,
          Dias = dias,
          ValorDiaria = valorDiaria
        });

        Console.WriteLine("Contrato adicionado com sucesso!\n");
      }

      // Processar e exibir os resultados
      decimal custoTotal = listaContratos.Sum(c => c.Dias * c.ValorDiaria);
      Console.WriteLine($"\nCusto total dos contratos: {custoTotal:F2}");
      Console.WriteLine(custoTotal > orcamento ? "Orçamento excedido!" : "Dentro do orçamento!");

      var custoPorDepartamento = listaContratos
        .GroupBy(c => c.Departamento)
        .Select(g => new
        {
          Departamento = g.Key,
          Custo = g.Sum(c => c.Dias * c.ValorDiaria)
        })
        .OrderByDescending(g => g.Custo)
        .FirstOrDefault();

      if (custoPorDepartamento != null)
      {
        Console.WriteLine($"Departamento com maior custo: {custoPorDepartamento.Departamento}");
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
  }
}
