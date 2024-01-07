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
        public GerenciarUsuario()
        {
            Usuarios = usuarioService.LerJsonUsuario()!;
        }
        public List<Usuario> ReceberUsuarios()
        {
            return Usuarios = usuarioService.LerJsonUsuario()!;
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
        public void CriarUsuario()
        {
            Console.WriteLine("Criando novo usuário...");

            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Nome de Usuário: ");
            string nomeUsuario = Console.ReadLine()!;

            Console.WriteLine("Cargo (digite o número correspondente):\n 1 - Desenvolvedor\n 2 - TechLeader");
            if (Enum.TryParse(Console.ReadLine(), out Cargos cargo))
            {
                Console.Write("Senha: ");
                string senha = Console.ReadLine()!;

                Usuario novoUsuario = new Usuario(nome, email, cargo,nomeUsuario, senha);
                Usuarios.Add(novoUsuario);
                Console.WriteLine("Usuario criado com sucesso pelo TechLeader.");
                usuarioService.SalvarJsonUsuario(Usuarios);
            }
            else
            {
                Console.WriteLine("Opção de cargo inválida.");
            }
        }

    }
}
