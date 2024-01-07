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
        private TarefaService tarefaService;

        public EstatisticasTarefas()
        {
            tarefaService = new TarefaService();
            tarefas = tarefaService.LerJsonTarefas();
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
        public void ExibirPorcentagemPorStatus()
        {
            Console.WriteLine("Porcentagem de Tarefas por Status:\n");

            int totalTarefas = tarefas.Count;

            foreach (StatusTarefa status in Enum.GetValues(typeof(StatusTarefa)))
            {
                int quantidadeTarefasStatus = tarefas.Count(tarefa => tarefa.Status == status);
                double porcentagem = (double)quantidadeTarefasStatus / totalTarefas * 100;

                Console.WriteLine($"Status: {status}, Porcentagem: {porcentagem:N2}%");
            }
        }
    }

}
