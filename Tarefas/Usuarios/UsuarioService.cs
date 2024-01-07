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
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(usuario, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
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

        //public UsuarioService(string arquivoJson = "Usuarios.json")
        //{
        //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //    string caminhoUsuarios = Path.Combine(baseDirectory, "Usuarios", arquivoJson);
        //    Caminho = caminhoUsuarios.Replace("InterfaceInicial\\bin\\Debug\\net8.0", "Tarefas");
        //    listaDesenvolvedores = InicializarUsuarios().Item1;
        //    listaTechLeaders = InicializarUsuarios().Item2;
        //}

        //private(List<Desenvolvedor>, List<TechLeader>) InicializarUsuarios()
        //{
        //    try
        //    {
        //        string json = File.ReadAllText(Caminho);
        //        Desenvolvedor[] arrayUsuarios = JsonConvert.DeserializeObject<Desenvolvedor[]>(json);
        //        List<Desenvolvedor> ListaDesenvolvedores = arrayUsuarios.Where(usuario => usuario.Cargo == Cargo.Desenvolvedor).ToList();

        //        TechLeader[] arrayUsuarios2 = JsonConvert.DeserializeObject<TechLeader[]>(json);
        //        List<TechLeader> ListaTechLeaders = arrayUsuarios2.Where(techleader => techleader.Cargo == Cargo.TechLeader).ToList();

        //        return (ListaDesenvolvedores, ListaTechLeaders);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
        //        return (null, null);
        //    }
        //}
        //    public void LerTodosDesenvolvedores()
        //    {
        //        try
        //        {
        //            foreach (var desenvolvedor in listaDesenvolvedores)
        //            {
        //                desenvolvedor.ExibirInformacoes();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
        //        }
        //    }

        //    public void LerTodosTechLeaders()
        //    {
        //        try
        //        {
        //            foreach (var techLeader in listaTechLeaders)
        //            {
        //                techLeader.ExibirInformacoes();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Ocorreu um erro ao exibir os detalhes dos funcionários: " + ex.Message);
        //        }
        //    }

//public LerUsuarioCSV()
//{
//    Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "GerenciadorDeTarefas");
//    listaDesenvolvedores = InicializarUsuarios2().Item1;
//    listaTechLeaders = InicializarUsuarios2().Item2;
//}
//internal class UsuarioService
//{
//    private string Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios", "Usuarios.json");
//    private (List<Desenvolvedor>, List<TechLeader>) listaUsuario;

//    public UsuarioService()
//    {
//        Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "Sistema");
//        listaUsuario = InicializarUsuarios();
//    }

//    private (List<Desenvolvedor>, List<TechLeader>) InicializarUsuarios()
//    {
//        try
//        {
//            string json = File.ReadAllText(Caminho);
//            Desenvolvedor[] arrayUsuarios = JsonConvert.DeserializeObject<Desenvolvedor[]>(json);
//            List<Desenvolvedor> ListaDesenvolvedores = arrayUsuarios.Where(usuario => usuario.Cargo == Cargo.Desenvolvedor).ToList();

//            TechLeader[] arrayUsuarios2 = JsonConvert.DeserializeObject<TechLeader[]>(json);
//            List<TechLeader> ListaTechLeaders = arrayUsuarios2.Where(techleader => techleader.Cargo == Cargo.TechLeader).ToList();

//            return (ListaDesenvolvedores, ListaTechLeaders);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Ocorreu um erro na inicialização dos usuários: " + ex.Message);
//            return (null, null);
//        }
//    }
//}
//    private List<Usuarios> InicializarUsuario()
//    {
//        try
//        {
//            string json = File.ReadAllText(Caminho);
//            Usuarios[] arrayFuncionarios = JsonConvert.DeserializeObject<Usuarios[]>(json);
//            return new List<Usuarios>(arrayFuncionarios);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("Ocorreu um erro na inicialização dos funcionários: " + ex.Message);
//            return new List<Usuarios>();
//        }
//    }
//}
//internal List<Usuarios> RetornarLista()
//{
//    listaFuncionarios = InicializarFuncionarios();
//    return listaFuncionarios;
//}