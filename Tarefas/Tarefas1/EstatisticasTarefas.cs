using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{
    public class EstatisticasTarefas
    {
        private List<Tarefa> tarefas;

        public EstatisticasTarefas()
        {
            GerenciarTarefa gerenciarTarefa = new GerenciarTarefa();
            tarefas = gerenciarTarefa.ReceberTarefas();
        }

        public void ExibirEstatisticasPorStatus()
        {
            Console.WriteLine("Estatísticas de Tarefas por Status:\n");

            foreach (StatusTarefa status in Enum.GetValues(typeof(StatusTarefa)))
            {
                int quantidadeTarefas = tarefas.Count(tarefa => tarefa.Status == status);
                Console.WriteLine($"Status: {status}, Quantidade de Tarefas: {quantidadeTarefas}");
            }
        }
        public void BuscarEExibirTarefasPorStatus(StatusTarefa status)
        {
            TarefaService tarefaService = new TarefaService(); // Seu serviço de manipulação de tarefas
            List<Tarefa> tarefas = tarefaService.LerJsonTarefas(); // Carrega as tarefas do JSON

            List<Tarefa> tarefasPorStatus = tarefas.Where(t => t.Status == status).ToList();

            Console.WriteLine($"Tarefas Encontradas ({tarefasPorStatus.Count}) com o Status '{status}':\n");

            foreach (var tarefa in tarefasPorStatus)
            {
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Responsável: {tarefa.Responsavel}");
                Console.WriteLine($"Status: {tarefa.Status}");
                Console.WriteLine($"Aprovada: {(tarefa.Aprovada ? "Sim" : "Não")}");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
