using Newtonsoft.Json;
using Sistema.Tarefas1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Usuarios
{
    public class GerenciarUsuario
    {
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        UsuarioService usuarioService = new UsuarioService();
        public List<Usuario> ReceberUsuarios()
        {
            return Usuarios = usuarioService.LerJsonUsuario()!;
        }
        public static void SalvarUsuarios(List<Usuario> usuario)
        {
            string json = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            File.WriteAllText("Tarefas.json", json);
        }
        public void ExibirUsuarios()
        {
            foreach (var usuario in Usuarios)
            {
                Console.WriteLine($"Nome: {usuario.Nome}");
                Console.WriteLine($"Nome de Usuarios: {usuario.NomeUsuario}");
                Console.WriteLine($"Email: {usuario.Email} ");
                Console.WriteLine($"Cargo: {usuario.Cargo}");
                Console.WriteLine();
            }
        }

    }
}
