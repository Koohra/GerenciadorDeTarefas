using Sistema.Tarefas1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Usuarios
{
    internal class Desenvolvedor : Usuario
    {
        
       public List<Tarefa> Tarefas { get; private set; }

        public Desenvolvedor(string nome, string email, Cargos cargos, string chaveAcesso, string nomeUsuario) : base(nome, email, cargos, chaveAcesso, nomeUsuario)
        {
            Tarefas = new List<Tarefa>();
        }

        //public void CriarTarefa(string titulo, string descricao)
        //{
        //    Tarefa novaTarefa = new Tarefa(titulo, descricao, this);
        //    Tarefas.Add(novaTarefa);
        //    Console.WriteLine("Tarefa criada com sucesso pelo Desenvolvedor.");
        //}


    }
}
    

