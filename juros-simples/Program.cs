using System;

public class Program
{
  public static void Main()
  {
    // Solicita ao usuário inserir os valores com mensagens claras
    Console.WriteLine("Insira o capital inicial (P):");
    double capital = LerDouble();

    Console.WriteLine("Insira a taxa de juros (i) em decimal (exemplo: 0.05 para 5%):");
    double taxaDeJuros = LerDouble();

    Console.WriteLine("Insira o tempo em anos (n):");
    int tempo = LerInt();

    // Calcula o montante final utilizando a fórmula de juros simples
    double montanteFinal = CalcularJurosSimples(capital, taxaDeJuros, tempo);

    // Exibe o montante final formatado
    Console.WriteLine($"O montante final é: {montanteFinal:F2}");
  }

  public static double CalcularJurosSimples(double capital, double taxaDeJuros, int tempo)
  {
    return capital * (1 + taxaDeJuros * tempo);
  }

  public static double LerDouble()
  {
    while (true)
    {
      if (double.TryParse(Console.ReadLine(), out double valor))
        return valor;

      Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
    }
  }

  public static int LerInt()
  {
    while (true)
    {
      if (int.TryParse(Console.ReadLine(), out int valor))
        return valor;

      Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro válido.");
    }
  }
}