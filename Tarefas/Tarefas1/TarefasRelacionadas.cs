using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{
    internal class TarefasRelacionadas
    {
        public void RelacionarTarefas(Tarefa tarefaPrincipal, List<Tarefa> tarefasRelacionadas)
        {
            foreach (var tarefaRelacionada in tarefasRelacionadas)
            {
                tarefaPrincipal.TarefasRelacionadasIds.Add(tarefaRelacionada.Id);
                tarefaRelacionada.TarefasRelacionadasIds.Add(tarefaPrincipal.Id);
            }
        }
    }
}
