using Newtonsoft.Json;
using Sistema.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{
    public class GerenciarTarefa
    {

        public  List<Tarefa> Tarefa { get; set; } = new List<Tarefa>();
        TarefaService tarefaService = new TarefaService();
        //public List<Tarefa> ReceberTarefas()
        //{
        //    Tarefa = tarefaService.LerJsonTarefas()!;
        //    return Tarefa;
        //}
        public List<Tarefa> ReceberTarefas()
        {
            Tarefa = tarefaService.LerJsonTarefas()!;
            return Tarefa;
        }

        public void VerTarefasParaAprovar()
        {
            TarefaService tarefaService = new TarefaService();
            List<Tarefa> tarefasAprovacaoInicio = tarefaService.BuscarTarefasAprovacaoInicio();

            if (tarefasAprovacaoInicio.Count > 0)
            {
                Console.WriteLine("Tarefas com status 'AprovacaoInicio':\n");
                foreach (var tarefa in tarefasAprovacaoInicio)
                {
                    Console.WriteLine($"Título: {tarefa.Titulo}");
                    Console.WriteLine($"Descrição: {tarefa.Descricao}");
                    Console.WriteLine($"Responsável: {tarefa.Responsavel}");
                    Console.WriteLine($"Status: {tarefa.Status}");
                    Console.WriteLine("-------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Não há tarefas com status 'AprovacaoInicio'.");
            }
        }
        public void AprovarTarefa(Tarefa tarefa)
        {
            tarefa.Aprovada = true;
            tarefa.Status = StatusTarefa.Pendente;
            Console.WriteLine($"A tarefa '{tarefa.Titulo}' foi aprovada com sucesso.");
        }
        public void AprovarTarefaPorId(int idTarefa)
        {
            ReceberTarefas();
            Tarefa tarefa = Tarefa.FirstOrDefault(t => t.Id == idTarefa)!;

            if (tarefa != null)
            {
                tarefa.Aprovada = true;
                tarefa.Status = StatusTarefa.Pendente;
                Console.WriteLine($"A tarefa '{tarefa.Titulo}' foi aprovada com sucesso.");
                tarefaService.SalvarJsonTarefa(Tarefa);
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada. Verifique o ID informado.");
            }
        }
    
        public void ExibirTarefas()
        {
            GerenciarTarefa gerenciarTarefa = new GerenciarTarefa();
            List<Tarefa> tarefas = gerenciarTarefa.ReceberTarefas();
            Console.WriteLine("Lista de Tarefas:\n");

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"Título: {tarefa.Titulo}");
                Console.WriteLine($"Descrição: {tarefa.Descricao}");
                Console.WriteLine($"Responsável: {tarefa.Responsavel}");
                Console.WriteLine($"Status: {tarefa.Status}");
                Console.WriteLine($"Aprovada: {(tarefa.Aprovada ? "Sim" : "Não")}");
                Console.WriteLine("-------------------------------");
            }
        }
        public void CriarTarefaTechLeader()
        {
            ReceberTarefas();
            Console.WriteLine("Titulo da Tarefa: ");
            string titulo = Console.ReadLine()!;
            Console.WriteLine("Descrição da Tarefa: ");
            string descricao = Console.ReadLine()!;
            Console.WriteLine("Escolha um responsavel pela tarefa: ");
            string responsavel = Console.ReadLine()!;
            Console.WriteLine("Escreva a data limite para concluir a tarefa no formato dd/mm/aaaa:");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime prazo))
            {
                Tarefa novaTarefa = new Tarefa(titulo, descricao, responsavel, prazo);
                Tarefa.Add(novaTarefa);
                Console.WriteLine("Tarefa criada com sucesso pelo TechLeader.");
                tarefaService.SalvarJsonTarefa(Tarefa);
            }
            else 
            { 
                Console.WriteLine("Formato de data inválido. Tente novamente"); 
            }
        }


        public void CriarTarefa(string titulo, string descricao, string responsavel, DateTime prazo)
        {
            Tarefa novaTarefa = new Tarefa(titulo, descricao, responsavel, prazo);
            Tarefa.Add(novaTarefa); // Adiciona a nova tarefa à lista de tarefas do TechLeader
            Console.WriteLine("Tarefa criada com sucesso pelo TechLeader.");
        }

        public void AssumirTarefa(Tarefa tarefa, string novoResposavel)
        {
            if (tarefa.Responsavel != novoResposavel)
            {
                tarefa.Responsavel = novoResposavel;
                Console.WriteLine($"Você assumiu a tarefa '{tarefa.Titulo}' com sucesso.");
            }
            else
            {
                Console.WriteLine("Você já é o responsável por esta tarefa.");
            }
        }
        public void AssumirTarefaPorId(int idTarefa, string novoResponsavel)
        {

            List<Tarefa> listaDeTarefas = ReceberTarefas();
            Tarefa tarefa = listaDeTarefas.FirstOrDefault(t => t.Id == idTarefa)!;

            if (tarefa != null)
            {
                if (tarefa.Responsavel != novoResponsavel)
                {
                    tarefa.Responsavel = novoResponsavel;
                    Console.WriteLine($"Você assumiu a tarefa '{tarefa.Titulo}' com sucesso.");
                }
                else
                {
                    Console.WriteLine("Você já é o responsável por esta tarefa.");
                }
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada. Verifique o ID informado.");
            }
        }

        public void AdicionarPrazoTarefa(Tarefa tarefa, DateTime prazo)
        {
            if (tarefa.Status == StatusTarefa.Concluida || tarefa.Prazo != DateTime.MinValue)
            {
                Console.WriteLine("Não é possível adicionar um prazo a uma tarefa já concluída ou que já possui um prazo definido.");
                return;
            }
            tarefa.Prazo = prazo;

            Console.WriteLine($"Prazo adicionado com sucesso para a tarefa '{tarefa.Titulo}' - Novo prazo: {prazo}");
        }
        public void AdicionarPrazoTarefaPorId(int idTarefa, DateTime prazo)
        {
            List<Tarefa> listaDeTarefas = ReceberTarefas();
            Tarefa tarefa = listaDeTarefas.FirstOrDefault(t => t.Id == idTarefa)!;

            if (tarefa != null)
            {
                if (tarefa.Status == StatusTarefa.Concluida || tarefa.Prazo != DateTime.MinValue)
                {
                    Console.WriteLine("Não é possível adicionar um prazo a uma tarefa já concluída ou que já possui um prazo definido.");
                    return;
                }
                tarefa.Prazo = prazo;

                Console.WriteLine($"Prazo adicionado com sucesso para a tarefa '{tarefa.Titulo}' - Novo prazo: {prazo}");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada. Verifique o ID informado.");
            }
        }


    }
}

