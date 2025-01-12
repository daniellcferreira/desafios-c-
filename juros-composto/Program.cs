using System;

public class Program
{
  public static void Main()
  {
    try
    {
      // Solicita ao usuário inserir os valores com mensagens claras
      Console.WriteLine("Insira o valor principal (P):");
      double P = Convert.ToDouble(Console.ReadLine());

      Console.WriteLine("Insira a taxa de juros (i) como um número decimal (por exemplo, 0.05 para 5%):");
      double i = Convert.ToDouble(Console.ReadLine());

      Console.WriteLine("Insira o número de períodos (n):");
      int n = Convert.ToInt32(Console.ReadLine());

      // Calcula o montante final 
      double montanteFinal = CalcularJurosComposto(P, i, n);

      // Exibe o montante final formatado
      Console.WriteLine($"O montante final é: {montanteFinal:F2}");
    }
    catch (FormatException)
    {
      Console.WriteLine("Entrada inválida. Por favor, insira valores numéricos corretamente.");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
  }

  public static double CalcularJurosComposto(double P, double i, int n)
  {
    // Calcula o montante final com juros compostos
    return P * Math.Pow(1 + i, n);
  }
}
