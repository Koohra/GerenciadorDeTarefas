using Sistema.Tarefas1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Usuarios
{
    public class TechLeader : Usuario
    {
        public List<Tarefa> Tarefas { get; private set; }

        public TechLeader(string nome, string email, Cargos cargos, string chaveAcesso, string nomeUsuario) : base(nome, email, cargos, chaveAcesso, nomeUsuario)
        {
            Tarefas = new List<Tarefa>();
        }
    }
}
    //    public void CriarTarefa(string titulo, string descricao, Usuario responsavel)
    //    {
    //        Tarefa novaTarefa = new Tarefa(titulo, descricao, responsavel); 
    //        Tarefas.Add(novaTarefa); // Adiciona a nova tarefa à lista de tarefas do TechLeader
    //        Console.WriteLine("Tarefa criada com sucesso pelo TechLeader.");
    //    }

    //    public void AssumirTarefa(Tarefa tarefa)
    //    {
    //        if (tarefa.Responsavel != this)
    //        {
    //            tarefa.Responsavel = this;
    //            Console.WriteLine($"Você assumiu a tarefa '{tarefa.Titulo}' com sucesso.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Você já é o responsável por esta tarefa.");
    //        }
    //    }
    //    public void VerTarefasParaAprovar()
    //    {
    //        TarefaService tarefaService = new TarefaService(); 
    //        List<Tarefa> tarefasAprovacaoInicio = tarefaService.BuscarTarefasAprovacaoInicio();

    //        if (tarefasAprovacaoInicio.Count > 0)
    //        {
    //            Console.WriteLine("Tarefas com status 'AprovacaoInicio':\n");
    //            foreach (var tarefa in tarefasAprovacaoInicio)
    //            {
    //                Console.WriteLine($"Título: {tarefa.Titulo}");
    //                Console.WriteLine($"Descrição: {tarefa.Descricao}");
    //                Console.WriteLine($"Responsável: {tarefa.Responsavel.Nome}");
    //                Console.WriteLine($"Status: {tarefa.Status}");
    //                Console.WriteLine("-------------------------------");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine("Não há tarefas com status 'AprovacaoInicio'.");
    //        }
    //    }

    //    public void AprovarTarefa(Tarefa tarefa)
    //    {
    //        tarefa.Aprovada = true;
    //        tarefa.Status = StatusTarefa.Pendente;
    //        Console.WriteLine($"A tarefa '{tarefa.Titulo}' foi aprovada com sucesso.");
    //    }
    //    public void ExibirTarefas()
    //    {
    //        GerenciarTarefa gerenciarTarefa = new GerenciarTarefa();
    //        List<Tarefa> tarefas = gerenciarTarefa.ReceberTarefas();
    //        Console.WriteLine("Lista de Tarefas:\n");

    //        foreach (var tarefa in tarefas)
    //        {
    //            Console.WriteLine($"Título: {tarefa.Titulo}");
    //            Console.WriteLine($"Descrição: {tarefa.Descricao}");
    //            Console.WriteLine($"Responsável: {tarefa.Responsavel}");
    //            Console.WriteLine($"Status: {tarefa.Status}");
    //            Console.WriteLine($"Aprovada: {(tarefa.Aprovada ? "Sim" : "Não")}");
    //            Console.WriteLine("-------------------------------");
    //        }
    //    }
    //}


