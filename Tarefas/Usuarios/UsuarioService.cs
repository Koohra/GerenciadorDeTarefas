using Newtonsoft.Json;
using Sistema.Tarefas1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Usuarios
{
    public class UsuarioService
    {
        public string? Caminho {  get; set; }
        

        public UsuarioService(string arquivoJson = "Usuarios.json")
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoUsuarios = Path.Combine(baseDirectory, "Usuarios", arquivoJson);
            Caminho = caminhoUsuarios.Replace("InterfaceInicial\\bin\\Debug\\net8.0", "Tarefas");
        }

        public List<Usuario>? LerJsonUsuario()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Usuario>? usuario = JsonConvert.DeserializeObject<List<Usuario>>(conteudoJson);
                    return usuario;
                }

                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Usuario>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Tarefas: {e}");
                return new List<Usuario>();
            }
        }
        public void SalvarJsonUsuario(List<Usuario> usuario)
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    string json = JsonConvert.SerializeObject(usuario, Formatting.Indented);
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
    }
}
