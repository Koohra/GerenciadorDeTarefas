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