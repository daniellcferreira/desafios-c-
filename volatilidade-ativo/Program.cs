using System;
using System.Globalization;
using System.Linq;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Digite os preços de fechamento separados por vírgula:");

    // Lê a string de entrada
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
      Console.WriteLine("Entrada inválida. Por favor, forneça os preços.");
      return;
    }

    try
    {
      // Converte os preços usando InvariantCulture
      double[] precos = input
        .Split(',')
        .Select(preco => double.Parse(preco.Trim(), CultureInfo.InvariantCulture))
        .ToArray();

      if (precos.Length == 0)
      {
        Console.WriteLine("Nenhum preço válido foi fornecido.");
        return;
      }

      // Calcula a volatilidade histórica
      double volatilidade = CalcularVolatilidade(precos);

      // Exibe o resultado com separador decimal em ponto
      Console.WriteLine($"Volatilidade histórica: {volatilidade.ToString("F3", CultureInfo.InvariantCulture)}");
    }
    catch (FormatException)
    {
      Console.WriteLine("Erro: Certifique-se de inserir apenas números separados por vírgulas.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
  }

  public static double CalcularVolatilidade(double[] precos)
  {
    double media = CalcularMedia(precos);
    double variancia = precos.Select(preco => Math.Pow(preco - media, 2)).Sum() / precos.Length;
    return Math.Sqrt(variancia);
  }

  public static double CalcularMedia(double[] precos)
  {
    return precos.Average();
  }
}
