using System;
using System.Linq;

class Program
{
  static void Main()
  {
    try
    {
      // Leitura de entrada
      Console.WriteLine("Digite os valores na ordem: salário base, horas extras, valor hora extra, descontos IR, descontos INSS (separados por vírgula):");
      string entrada = Console.ReadLine();

      // Processa a entrada e valida
      decimal[] valores = ProcessarEntrada(entrada);
      if (valores == null || valores.Length != 5)
      {
        Console.WriteLine("Erro: Entrada inválida. Certifique-se de informar cinco valores separados por vírgula.");
        return;
      }

      // Atribui os valores às variáveis
      decimal salarioBase = valores[0];
      int horasExtras = (int)valores[1];
      decimal valorHoraExtra = valores[2];
      decimal descontosIR = valores[3];
      decimal descontosINSS = valores[4];

      // Calcula o salário líquido
      decimal salarioLiquido = CalcularSalarioLiquido(salarioBase, horasExtras, valorHoraExtra, descontosIR, descontosINSS);

      // Exibe o resultado formatado
      Console.WriteLine($"Salário líquido: {salarioLiquido:C}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Erro inesperado: {ex.Message}");
    }
  }

  static decimal[] ProcessarEntrada(string entrada)
  {
    try
    {
      return entrada.Split(',').Select(valor =>
      {
        if (decimal.TryParse(valor.Trim(), out decimal numero))
        {
          return numero;
        }
        throw new FormatException("Um ou mais valores não são numéricos.");
      }).ToArray();
    }
    catch
    {
      return null;
    }
  }

  static decimal CalcularSalarioLiquido(decimal salarioBase, int horasExtras, decimal valorHoraExtra, decimal descontosIR, decimal descontosINSS)
  {
    return salarioBase + (horasExtras * valorHoraExtra) - descontosIR - descontosINSS;
  }
}
