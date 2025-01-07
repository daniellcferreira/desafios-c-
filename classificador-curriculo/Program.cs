using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    try
    {
      // Leitura e validação da entrada do usuário
      List<int> anosExperiencia = LerEntradaDoUsuario();

      // Classificação dos currículos
      List<string> classificacao = ClassificarCurriculos(anosExperiencia);

      // Formatação e exibição do resultado
      ExibirResultado(classificacao);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
    }
  }

  static List<int> LerEntradaDoUsuario()
  {
    Console.WriteLine("Digite os anos de experiência separados por vírgula:");
    string input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
      throw new ArgumentException("A entrada não pode estar vazia.");

    try
    {
      return input.Split(',')
                  .Select(x => int.Parse(x.Trim()))
                  .ToList();
    }
    catch
    {
      throw new FormatException("A entrada deve conter apenas números inteiros separados por vírgula.");
    }
  }

  static List<string> ClassificarCurriculos(List<int> anosExperiencia)
  {
    return anosExperiencia.Select(anos =>
        anos <= 3 ? "Junior" :
        anos <= 5 ? "Pleno" : "Senior"
    ).ToList();
  }

  static void ExibirResultado(List<string> classificacao)
  {
    string resultado = string.Join(",", classificacao);
    Console.WriteLine($"Classificação: {resultado}");
  }
}
