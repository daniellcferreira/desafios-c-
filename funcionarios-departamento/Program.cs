using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    // Mensagem para orientar o usuário
    Console.WriteLine("Digite os departamentos separados por vírgulas (exemplo: TI, RH, Financeiro):");

    // Leitura da entrada do usuário
    string input = Console.ReadLine();

    // Validação de entrada
    if (string.IsNullOrWhiteSpace(input))
    {
      Console.WriteLine("Entrada inválida. Por favor, insira uma lista de departamentos separada por vírgulas.");
      return;
    }

    // Processamento da entrada
    var departamentos = input.Split(',')
                             .Select(d => d.Trim().ToLower())
                             .ToList();

    // Contagem de funcionários por departamento
    var contagemDepartamentos = ContarFuncionariosPorDepartamento(departamentos);

    // Formatação da saída
    var resultado = string.Join(Environment.NewLine,
        contagemDepartamentos.OrderBy(depto => depto.Key)
                             .Select(depto => $"{depto.Key}: {depto.Value}"));

    Console.WriteLine("\nContagem de funcionários por departamento:");
    Console.WriteLine(resultado);
  }

  // Método que conta o número de funcionários em cada departamento usando LINQ.
  static Dictionary<string, int> ContarFuncionariosPorDepartamento(List<string> departamentos)
  {
    return departamentos
        .GroupBy(d => d)
        .ToDictionary(g => g.Key, g => g.Count());
  }
}
