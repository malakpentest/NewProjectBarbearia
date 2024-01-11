using System;
using System.Collections.Generic;
using System.Linq;

namespace NewProjectBarbearia2._0.models
{
    public class Agenda
    {
        private Dictionary<DateTime, Cliente> horariosAgendados;

        public Agenda()
        {
            horariosAgendados = new Dictionary<DateTime, Cliente>();
            InicializarHorarios();
        }

        private void InicializarHorarios()
        {
            // Inicializa todos os horários disponíveis de terça a domingo das 8h às 11h e das 13h às 17h
            DateTime inicio = DateTime.Now.Date.AddDays(1 - (int)DateTime.Now.DayOfWeek); // Próxima terça-feira
            for (int i = 0; i < 6; i++) // De terça a domingo
            {
                DateTime dia = inicio.AddDays(i);
                for (int hora = 8; hora <= 10; hora++)
                {
                    horariosAgendados.Add(new DateTime(dia.Year, dia.Month, dia.Day, hora, 0, 0), null);
                }
                for (int hora = 13; hora <= 16; hora++)
                {
                    horariosAgendados.Add(new DateTime(dia.Year, dia.Month, dia.Day, hora, 0, 0), null);
                }
            }
        }

        public List<DateTime> ObterDiasDisponiveis()
        {
            return horariosAgendados
                .Where(h => h.Value == null)
                .Select(h => h.Key.Date)
                .Distinct()
                .ToList();
        }

        public List<DateTime> ObterHorariosDisponiveisNoDia(DateTime dia)
        {
            return horariosAgendados
                .Where(h => h.Key.Date == dia.Date && h.Value == null)
                .Select(h => h.Key)
                .ToList();
        }

        public bool AgendarHorario(DateTime horario, Cliente cliente)
        {
            if (horariosAgendados.ContainsKey(horario) && horariosAgendados[horario] == null)
            {
                horariosAgendados[horario] = cliente;
                return true;
            }
            return false;
        }
    }
}
