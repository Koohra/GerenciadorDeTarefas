using Sistema.Tarefas1;
using Sistema.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Menu
{
    internal class Interface
    {
        public static void MenuTechLeader(Usuario techLeader)
        {
            GerenciarTarefa gerenciarTarefa = new GerenciarTarefa();
            Console.Clear();
            Console.WriteLine("\nSelecione a ação desejada:");
            Console.WriteLine("1-Criar uma tarefa \n2-Ver tarefas para aprovar \n3-Aprovar tarefa " +
                "\n4-Exibir todas as tarefas \n5-Assumir tarefa \n6-Adicionar prazo na tarefa");
            int acao;
            while (!int.TryParse(Console.ReadLine(), out acao))
            {
                Console.Write("Digite o número correspondente a ação");
            }
            switch (acao) 
            {
                case 1:
                    gerenciarTarefa.CriarTarefaTechLeader();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;

                case 2:
                    gerenciarTarefa.VerTarefasParaAprovar();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;

                case 3:
                    Console.WriteLine("Insira o ID da tarefa que deseja aprovar:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        gerenciarTarefa.AprovarTarefaPorId(id);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Digite um número válido para o ID da tarefa.");
                    }
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;

                case 4:
                    gerenciarTarefa.ExibirTarefas();
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;

                case 5:
                    Console.WriteLine("Insira o ID da tarefa que deseja assumir:");
                    if (int.TryParse(Console.ReadLine(), out int TarefaId))
                    {
                        Console.WriteLine("Insira o nome do novo responsável:");
                        string novoResponsavel = Console.ReadLine() ?? "";

                        gerenciarTarefa.AssumirTarefaPorId(TarefaId, novoResponsavel);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Digite um número válido para o ID da tarefa.");
                    }
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;

                case 6:
                    Console.WriteLine("Insira o ID da tarefa que deseja adicionar um prazo:");
                    if (int.TryParse(Console.ReadLine(), out int prazoId))
                    {
                        Console.WriteLine("Insira a data final da tarefa (no formato dd/mm/aaaa):");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime dataPrazo))
                        {
                            gerenciarTarefa.AdicionarPrazoTarefaPorId(prazoId, dataPrazo);
                        }
                        else
                        {
                            Console.WriteLine("Data inválida. Insira uma data no formato correto (dd/mm/aaaa).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido. Digite um número válido para o ID da tarefa.");
                    }
                    Console.WriteLine($"\nPrecione [ENTER] para voltar");
                    Console.ReadLine();
                    MenuTechLeader(techLeader);
                    return;
            }

        }
    }
}
