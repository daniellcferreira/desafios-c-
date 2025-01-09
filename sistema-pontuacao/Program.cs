using System;
using System.Linq;

class Program
{
  static void Main()
  {
    // Solicitar e ler os pesos dos critérios
    Console.WriteLine("Digite os pesos dos critérios separados por vírgula:");
    var weights = Console.ReadLine().Split(',').Select(double.Parse).ToArray();

    // Solicitar e ler a quantidade de candidatos
    Console.WriteLine("Digite a quantidade de candidatos:");
    int numberOfCandidates = int.Parse(Console.ReadLine());

    // Inicializar variáveis para armazenar o nome do candidato com a maior pontuação e pontuação máxima
    string topCandidate = "";
    double maxScore = double.MinValue;

    // Processar cada candidato
    for (int i = 0; i < numberOfCandidates; i++)
    {
      Console.WriteLine($"Digite o nome do candidato {i + 1} e suas pontuações separadas por vírgula:");
      var input = Console.ReadLine().Split(',');

      // Extrair nome e pontuações do candidato
      string name = input[0];
      var scores = input.Skip(1).Select(double.Parse).ToArray();

      // Verificar se o número de pontuações corresponde ao número de pesos
      if (scores.Length != weights.Length)
      {
        Console.WriteLine("Erro: O número de pontuações não corresponde ao número de pesos. Tente novamente.");
        i--;
        continue;
      }

      // Calcular a pontuação total do candidato
      double totalScore = scores.Select((score, index) => score * weights[index]).Sum();

      // Verificar se este candidato tem a maior pontuação
      if (totalScore > maxScore)
      {
        topCandidate = name;
        maxScore = totalScore;
      }
    }

    // Imprimir o nome do candidato com a maior pontuação
    Console.WriteLine($"O candidato com a maior pontuação foi {topCandidate} com {maxScore:F2} pontos.");
  }
}
