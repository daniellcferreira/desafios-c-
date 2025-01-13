using System;

class Program
{
  static void Main()
  {
    // Solicita o número de ativos
    Console.WriteLine("Digite o número de ativos:");
    if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
    {
      Console.WriteLine("Número de ativos inválido."); // Valida se o número de ativos é um inteiro positivo
      return;
    }

    // Solicita os valores de mercado de cada ativo
    Console.WriteLine("Digite os valores de mercado separados por vírgula:");
    double[] valoresMercado = LerArrayDouble(N);

    // Solicita o valor total a ser investido
    Console.WriteLine("Digite o valor total investido:");
    if (!double.TryParse(Console.ReadLine(), out double valorTotalInvestido) || valorTotalInvestido <= 0)
    {
      Console.WriteLine("Valor total investido inválido."); // Valida se o valor investido é positivo
      return;
    }

    // Solicita os limites mínimos de alocação
    Console.WriteLine("Digite as alocações mínimas separadas por vírgula:");
    double[] alocacoesMinimas = LerArrayDouble(N);

    // Solicita os limites máximos de alocação
    Console.WriteLine("Digite as alocações máximas separadas por vírgula:");
    double[] alocacoesMaximas = LerArrayDouble(N);

    // Calcula as alocações ajustadas com base nos valores de mercado e limites
    double[] alocacoes = CalcularAlocacoes(N, valoresMercado, valorTotalInvestido, alocacoesMinimas, alocacoesMaximas);

    // Exibe as alocações calculadas com duas casas decimais
    Console.WriteLine("Alocações calculadas:");
    foreach (double alocacao in alocacoes)
    {
      Console.WriteLine($"{alocacao:F2}");
    }
  }

  // Método para ler e converter um array de strings em um array de doubles
  static double[] LerArrayDouble(int tamanho)
  {
    string[] entrada = Console.ReadLine().Split(',');
    if (entrada.Length != tamanho)
    {
      Console.WriteLine("Número de valores inválido."); // Verifica se o número de valores corresponde ao número de ativos
      Environment.Exit(1); // Finaliza o programa em caso de erro
    }

    try
    {
      return Array.ConvertAll(entrada, double.Parse); // Converte os valores para double
    }
    catch
    {
      Console.WriteLine("Entrada inválida. Certifique-se de digitar números válidos separados por vírgula.");
      Environment.Exit(1); // Finaliza o programa em caso de erro de conversão
      return null; // Retorno apenas para satisfazer o compilador, nunca será executado
    }
  }

  // Método para calcular as alocações ajustadas com base nos limites
  static double[] CalcularAlocacoes(int N, double[] valoresMercado, double valorTotalInvestido, double[] alocacoesMinimas, double[] alocacoesMaximas)
  {
    double totalMercado = 0;

    // Calcula o valor total de mercado somando os valores individuais
    foreach (double valor in valoresMercado)
    {
      totalMercado += valor;
    }

    double[] alocacoes = new double[N];
    for (int i = 0; i < N; i++)
    {
      // Calcula a alocação proporcional baseada no valor de mercado
      double proporcional = (valoresMercado[i] / totalMercado) * valorTotalInvestido;

      // Ajusta a alocação aos limites mínimo e máximo
      alocacoes[i] = Math.Max(alocacoesMinimas[i], Math.Min(alocacoesMaximas[i], proporcional));
    }

    return alocacoes; // Retorna o array de alocações ajustadas
  }
}
