using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    // Mensagens iniciais para o usuário
    Console.WriteLine("Bem-vindo ao filtro de currículos!");
    Console.WriteLine("Por favor, insira os currículos e palavras-chave no formato:");
    Console.WriteLine("'curriculo1,curriculo2; palavra1,palavra2'");
    Console.Write("Entrada: ");

    try
    {
      // Leitura da entrada do usuário
      string input = Console.ReadLine();

      // Validação básica da entrada (verifica se possui o delimitador esperado)
      if (string.IsNullOrWhiteSpace(input) || !input.Contains(";"))
      {
        Console.WriteLine("Erro: Entrada inválida. Formato esperado: 'curriculo1,curriculo2; palavra1,palavra2'");
        return;
      }

      // Separação da entrada em currículos e palavras-chave
      var entradaSeparada = input.Split(';').Select(p => p.Trim()).ToArray();

      // Verifica se a entrada foi corretamente dividida em duas partes
      if (entradaSeparada.Length != 2)
      {
        Console.WriteLine("Erro: Formato incorreto de entrada.");
        return;
      }

      // Extração e processamento das listas de currículos e palavras-chave
      List<string> curriculos = entradaSeparada[0].Split(',').Select(c => c.Trim()).ToList();
      List<string> palavrasChave = entradaSeparada[1].Split(',').Select(p => p.Trim()).ToList();

      // Verifica se foram fornecidos currículos e palavras-chave
      if (!curriculos.Any() || !palavrasChave.Any())
      {
        Console.WriteLine("Erro: Nenhum currículo ou palavra-chave fornecida.");
        return;
      }

      // Filtra os currículos com base nas palavras-chave
      List<string> curriculosRelevantes = FiltrarCurriculosPorPalavrasChave(curriculos, palavrasChave);

      // Verifica o resultado da filtragem e apresenta ao usuário
      if (curriculosRelevantes.Count == 0)
      {
        Console.WriteLine("Nenhum currículo relevante encontrado.");
      }
      else
      {
        Console.WriteLine("Currículos relevantes encontrados:");
        Console.WriteLine(string.Join("; ", curriculosRelevantes));
      }
    }
    catch (Exception ex)
    {
      // Captura e exibe erros inesperados
      Console.WriteLine($"Erro inesperado: {ex.Message}");
    }
  }

  // Método para filtrar currículos com base em palavras-chave
  static List<string> FiltrarCurriculosPorPalavrasChave(List<string> curriculos, List<string> palavrasChave)
  {
    // Converte as palavras-chave em um HashSet para melhorar a eficiência de busca
    var palavrasChaveSet = new HashSet<string>(palavrasChave, StringComparer.OrdinalIgnoreCase);

    // Retorna currículos que contenham todas as palavras-chave, ignorando diferenças de maiúsculas/minúsculas
    return curriculos.Where(c => palavrasChaveSet.All(p =>
      c.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
  }
}
