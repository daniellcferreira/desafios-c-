using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    // Solicita o orçamento do usuário
    Console.Write("Insira o orçamento: ");
    int budget;
    if (!int.TryParse(Console.ReadLine(), out budget) || budget < 0)
    {
      Console.WriteLine("Orçamento inválido.");
      return;
    }

    // Solicita os custos dos treinamentos
    Console.Write("Insira os custos dos treinamentos (separados por vírgula): ");
    var trainingCosts = Console.ReadLine()
                                .Split(',')
                                .Select(x =>
                                {
                                  int cost;
                                  return int.TryParse(x, out cost) ? cost : -1;
                                })
                                .Where(x => x >= 0)
                                .OrderBy(x => x)
                                .ToList();

    // Verifica se não há custos válidos
    if (trainingCosts.Count == 0)
    {
      Console.WriteLine("Nenhum custo válido foi fornecido.");
      return;
    }

    // Inicializa a lista de treinamentos selecionados
    List<int> selectedTrainings = new List<int>();
    int totalCost = 0;

    // Itera sobre os custos de treinamento
    foreach (var cost in trainingCosts)
    {
      // Verifica se o custo do treinamento é menor ou igual ao orçamento
      if (totalCost + cost <= budget)
      {
        // Adiciona o treinamento à lista de treinamentos selecionados
        selectedTrainings.Add(cost);
        totalCost += cost;
      }
      else
      {
        break; // Interrompe a iteração
      }
    }

    // Exibe os treinamentos selecionados
    Console.WriteLine("Treinamentos selecionados: " + string.Join(", ", selectedTrainings));
  }
}
