using Sistema.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Usuarios
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public Cargos Cargo { get; set; }
        public string Senha { get; set; }

        public Usuario(string nome, string email, Cargos cargos, string nomeUsuario, string senha )
        {

            Nome = nome;
            Email = email;
            NomeUsuario = nomeUsuario;
            Cargo = cargos;
            Senha = senha;
        }
        private static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return senha;
        }
        public static void FazerLogin()
        {
            GerenciarUsuario gerenciaUsuarios = new GerenciarUsuario();
            List<Usuario> usuarios = gerenciaUsuarios.ReceberUsuarios();

            while (true)
            {
                string? nomeUsuario;
                string? senhaUsuario;

                do
                {
                    Console.WriteLine("BEM-VINDO AO SISTEMA!");
                    Console.WriteLine("_____________________");
                    Console.Write("Digite seu nome de usuário: ");
                    nomeUsuario = Console.ReadLine();


                    if (string.IsNullOrEmpty(nomeUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(nomeUsuario));
                do
                {
                    Console.Write("Digite sua senha: ");
                    senhaUsuario = LerSenha();

                    if (string.IsNullOrEmpty(senhaUsuario))
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                } while (string.IsNullOrEmpty(senhaUsuario));

                Usuario? usuario = usuarios.FirstOrDefault(predicate: u => u.NomeUsuario == nomeUsuario);
                if (usuario != null && usuario.Senha == senhaUsuario)
                {
                    Console.WriteLine($"Login bem-sucedido! Bem-vindo, {usuario.Nome}.");
                    if (usuario.Cargo == Cargos.TechLeader)
                    {
                        Thread.Sleep(1500);
                        Console.Clear();
                        Interface.MenuTechLeader(usuario);
                    }
                    else
                    {
                        Thread.Sleep(1500);
                        Console.Clear();
                        Interface.MenuDesenvolvedor(usuario);
                    }
                }
                else
                {
                    Console.WriteLine("Nome de usuário ou a senha incorreto.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
        public void Logout()
        {
            Console.Clear();
            Console.WriteLine($"{Cargo} desconectado.");
        }
    }

}



