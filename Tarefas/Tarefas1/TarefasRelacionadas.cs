using Sistema.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{
    internal class TarefasRelacionadas
    {
        public List<Tarefa> ListaTarefasRelacionadas { get; set; } = new List<Tarefa>();
        TarefaService tarefaService = new TarefaService();

        public TarefasRelacionadas()
        {
            ListaTarefasRelacionadas = tarefaService.LerJsonTarefas() ?? new List<Tarefa>();
        }

        public void AdicionarTarefaRelacionada(int idTarefaPrincipal, int idTarefaRelacionada)
        {
            Tarefa tarefaPrincipal = ListaTarefasRelacionadas.FirstOrDefault(tarefa => tarefa.Id == idTarefaPrincipal);
            Tarefa tarefaRelacionada = ListaTarefasRelacionadas.FirstOrDefault(tarefa => tarefa.Id == idTarefaRelacionada);

            if (tarefaPrincipal != null && tarefaRelacionada != null)
            {
                if (tarefaPrincipal.TarefasRelacionadasIds == null)
                {
                    tarefaPrincipal.TarefasRelacionadasIds = new List<int>();
                }

                tarefaPrincipal.TarefasRelacionadasIds.Add(tarefaRelacionada.Id);
                Console.WriteLine($"Tarefa {idTarefaRelacionada} adicionada como relacionada à Tarefa {idTarefaPrincipal}.");
                tarefaService.SalvarJsonTarefa(ListaTarefasRelacionadas);
            }
            else
            {
                Console.WriteLine("Tarefa principal ou tarefa relacionada não encontrada. Verifique os IDs informados.");
            }
        }

        public List<Tarefa> ObterTarefasPorDesenvolvedor(Usuario desenvolvedor)
        {
            var tarefasDiretasDoDesenvolvedor = ListaTarefasRelacionadas
                .Where(tarefa => tarefa.Responsavel == desenvolvedor.Nome).ToList();

            var tarefasRelacionadasAoDesenvolvedor = ListaTarefasRelacionadas
                .Where(tarefa => tarefa.TarefasRelacionadasIds != null &&
                                 tarefa.TarefasRelacionadasIds.Contains(tarefa.Id))
                .ToList();

            return tarefasDiretasDoDesenvolvedor.Union(tarefasRelacionadasAoDesenvolvedor).ToList();
        }
        public void ExibirTarefasPorDesenvolvedorNoTerminal(Usuario desenvolvedor)
        {
            var tarefasDoDesenvolvedor = ObterTarefasPorDesenvolvedor(desenvolvedor);

            if (tarefasDoDesenvolvedor.Any())
            {
                foreach (var tarefa in tarefasDoDesenvolvedor)
                {
                    Console.WriteLine($"ID: {tarefa.Id}");
                    Console.WriteLine($"Título: {tarefa.Titulo}");
                    Console.WriteLine($"Descrição: {tarefa.Descricao}");
                    Console.WriteLine($"Responsável: {tarefa.Responsavel}");
                    Console.WriteLine($"Prazo: {tarefa.Prazo}");
                    Console.WriteLine($"Status: {tarefa.Status}");
                    Console.WriteLine($"Aprovada: {(tarefa.Aprovada ? "Sim" : "Não")}");
                    Console.WriteLine("-------------------------------");
                    if (tarefa.TarefasRelacionadasIds.Any())
                    {
                        var tarefasRelacionadas = ListaTarefasRelacionadas
                            .Where(tr => tarefa.TarefasRelacionadasIds.Contains(tr.Id))
                            .ToList();
                        foreach (var tarefaRelacionada in tarefasRelacionadas)
                        {
                            Console.WriteLine($"ID: {tarefaRelacionada.Id}");
                            Console.WriteLine($"Título: {tarefaRelacionada.Titulo}");
                            Console.WriteLine($"Descrição: {tarefaRelacionada.Descricao}");
                            Console.WriteLine($"Responsável: {tarefaRelacionada.Responsavel}");
                            Console.WriteLine($"Prazo: {tarefaRelacionada.Prazo}");
                            Console.WriteLine($"Status: {tarefaRelacionada.Status}");
                            Console.WriteLine($"Aprovada: {(tarefaRelacionada.Aprovada ? "Sim" : "Não")}");
                            Console.WriteLine("-------------------------------");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Não há tarefas para o desenvolvedor '{desenvolvedor.Nome}'.");
            }
        }
    }
}
