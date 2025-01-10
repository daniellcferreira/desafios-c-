using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main()
  {
    Console.WriteLine("Insira as informações no formato: Nome, HH:mm-HH:mm (uma linha por candidato). Pressione Enter para encerrar.");

    List<string> entradas = new List<string>();
    string entrada;

    while (!string.IsNullOrEmpty(entrada = Console.ReadLine()))
    {
      entradas.Add(entrada);
    }

    if (entradas.Count == 0)
    {
      Console.WriteLine("Nenhuma entrada fornecida. O programa será encerrado.");
      return;
    }

    try
    {
      var listaCandidatos = entradas.Select(entradaAtual =>
      {
        var partes = entradaAtual.Split(',');
        if (partes.Length != 2) throw new FormatException("Entrada inválida.");

        var nomeCandidato = partes[0].Trim();
        var intervaloHorarios = partes[1].Trim().Split('-');
        if (intervaloHorarios.Length != 2) throw new FormatException("Formato de horário inválido.");

        var horarioInicio = TimeSpan.Parse(intervaloHorarios[0]);
        var horarioFim = TimeSpan.Parse(intervaloHorarios[1]);
        if (horarioFim <= horarioInicio) throw new FormatException("Horário de fim deve ser maior que o horário de início.");

        return (nomeCandidato, horarioInicio, horarioFim);
      }).ToList();

      var agendaAjustada = ReagendarHorarios(listaCandidatos);

      Console.WriteLine("\nAgenda ajustada:");
      foreach (var candidato in agendaAjustada)
      {
        Console.WriteLine($"{candidato.nomeCandidato}, {candidato.horarioInicio:hh\\:mm}-{candidato.horarioFim:hh\\:mm}");
      }
    }
    catch (FormatException ex)
    {
      Console.WriteLine($"Erro: {ex.Message}");
    }
  }

  static List<(string nomeCandidato, TimeSpan horarioInicio, TimeSpan horarioFim)> ReagendarHorarios(
    List<(string nomeCandidato, TimeSpan horarioInicio, TimeSpan horarioFim)> listaCandidatos)
  {
    var candidatosOrdenados = listaCandidatos.OrderBy(c => c.horarioInicio).ToList();
    var agendaAjustada = new List<(string nomeCandidato, TimeSpan horarioInicio, TimeSpan horarioFim)>();
    TimeSpan horarioAtual = candidatosOrdenados[0].horarioInicio;

    foreach (var candidato in candidatosOrdenados)
    {
      if (candidato.horarioInicio >= horarioAtual)
      {
        agendaAjustada.Add(candidato);
        horarioAtual = candidato.horarioFim;
      }
      else
      {
        var duracao = candidato.horarioFim - candidato.horarioInicio;
        var novoHorarioFim = horarioAtual + duracao;

        agendaAjustada.Add((candidato.nomeCandidato, horarioAtual, novoHorarioFim));
        horarioAtual = novoHorarioFim;
      }
    }

    return agendaAjustada;
  }
}
