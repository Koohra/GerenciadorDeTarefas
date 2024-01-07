using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema.Tarefas1
{
    public class TarefaService
    {


        public string? Caminho { get; set; }
        public TarefaService(string arquivoJson = "Tarefas.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, arquivoJson);
            Caminho = Caminho.Replace("InterfaceInicial\\bin\\Debug\\net8.0", "Tarefas\\Tarefas1");
        }
        
        public List<Tarefa>? LerJsonTarefas()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Tarefa>? tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(conteudoJson);
                    return tarefas;
                }

                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Tarefa>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Tarefas: {e}");
                return new List<Tarefa>();
            }
        }
        public void SalvarJsonTarefa(List<Tarefa> tarefas)
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    string json = JsonConvert.SerializeObject(tarefas, Formatting.Indented);
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + e.Message);
            }
        }
        public List<Tarefa> BuscarTarefasAprovacaoInicio()
        {
            List<Tarefa> tarefasAprovacaoInicio = new List<Tarefa>();
            List<Tarefa> todasTarefas = LerJsonTarefas();

            foreach (var tarefa in todasTarefas)
            {
                if (tarefa.Status == StatusTarefa.AprovacaoInicio)
                {
                    tarefasAprovacaoInicio.Add(tarefa);
                }
            }

            return tarefasAprovacaoInicio;
        }
    }
}
