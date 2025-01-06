using System;

class Program
{
  static void Main(string[] args)
  {
    try
    {
      // Solicita e valida a entrada das notas
      Console.WriteLine("Digite as notas separadas por vírgula (produtividade, qualidade, pontualidade):");
      string entrada = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(entrada))
      {
        Console.WriteLine("Erro: A entrada não pode estar vazia.");
        return;
      }

      // Processa as notas
      int[] notas = ProcessarNotas(entrada);
      if (notas == null)
      {
        Console.WriteLine("Erro: Insira três números separados por vírgula.");
        return;
      }

      // Calcula a média
      double media = CalcularMedia(notas);

      // Determina a elegibilidade para bonificação
      string elegivelParaBonus = media >= 7 ? "Sim" : "Não";

      // Exibe os resultados
      Console.WriteLine($"Média: {media:F2}");
      Console.WriteLine($"Elegível para bonificação: {elegivelParaBonus}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro inesperado: {ex.Message}");
    }
  }

  static int[] ProcessarNotas(string entrada)
  {
    string[] notasString = entrada.Split(',');
    if (notasString.Length != 3)
      return null;

    int[] notas = new int[3];
    for (int i = 0; i < notasString.Length; i++)
    {
      if (!int.TryParse(notasString[i].Trim(), out notas[i]))
        return null;
    }
    return notas;
  }

  static double CalcularMedia(int[] notas)
  {
    return (notas[0] + notas[1] + notas[2]) / 3.0;
  }
}
