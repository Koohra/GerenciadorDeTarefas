using Newtonsoft.Json;
using Sistema.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{


    public class Tarefa
    {
        public int Id { get; set; }
        public DateTime Prazo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public StatusTarefa Status { get; set; }
        public bool Aprovada { get; set; }
        public List<int> TarefasRelacionadasIds { get; set; }

        public Tarefa()
        {
            TarefasRelacionadasIds = new List<int>();
        }
        public Tarefa(int id, string titulo, string descricao, string responsavel, DateTime prazo)
        {
            Id = id;
            Titulo = titulo;
            Prazo = prazo;  
            Descricao = descricao;
            Responsavel = responsavel;
            Status = StatusTarefa.AprovacaoInicio;
            Aprovada = false;
            TarefasRelacionadasIds = new List<int>();
        }
    }
}

