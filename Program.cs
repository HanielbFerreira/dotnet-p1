using Intraday.Models;
using System;

namespace Intraday
{
    class Program
    {
        static OperationManagement operationManagement = new OperationManagement();
        static void Main(string[] args)
        {

            ShowMenu();
            int option = ReadInteger();
            while (option != 3)
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        RegisterNewOperationDate(operationManagement);
                        break;
                    case 2:
                        ShowTotalBalanceByDay();
                        break;
                    default:
                        Console.WriteLine("Opcão Inválida, por favor, selecione outra opcão.");
                        break;
                }

                ShowMenu();
                option = ReadInteger();
            }
            Console.WriteLine("Programa Finalizado.");
        }
        private static int ReadInteger()
        {
            string line = Console.ReadLine();
            int number;
            bool couldConvert = Int32.TryParse(line, out number);
            if (!couldConvert)
            {
                return -1;
            }
            return number;
        }

        static void ShowMenu()
        {
            Console.Clear();
            WriteHeader("Menu de operações");
            Console.WriteLine("Digite o numero de uma opção abaixo:");
            Console.WriteLine("1 - Cadastrar dia e operação.");
            Console.WriteLine("2 - Visualizar balanço por dia.");
            Console.WriteLine("3 - Sair.");
            Console.WriteLine("");
            Console.WriteLine("Digite o Comando:");
        }

        private static void EnterToContinue()
        {
            Console.WriteLine("");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
        public static void WriteHeader(string text)
        {
            Console.WriteLine($"-------------------- {text} ---------------");
            Console.WriteLine("");
        }
        private static void RegisterNewOperationDate(OperationManagement operationManagement)
        {

            WriteHeader("Registro da criação");
            Console.WriteLine("");

            Console.Write("Digite o Id da operação: ");
            string id = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Digite o saldo da operação: ");
            double balance = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite a data da operação (dd/mm/aaaa): ");
            string dataInput = Console.ReadLine();
            DateTime data = DateTime.Parse(dataInput);

            OperationDate od = new OperationDate(data);
            Operation op = new Operation(id, balance);
            od.Operations.Add(op);

            Console.WriteLine(od);
            Console.WriteLine(op);

            operationManagement.RegisterOperationDate(od);

            EnterToContinue();

        }
        private static void ShowTotalBalanceByDay()
        {
            Console.Clear();
            WriteHeader("Visualizar operações por dia");
            Console.Write("Digite a data (dd/mm/aaaa): ");
            Console.WriteLine();
            string dataInput = Console.ReadLine();
            DateTime data = DateTime.Parse(dataInput);
            operationManagement.ShowOperationDate(data);
            Console.ReadLine();
            EnterToContinue();
        }
    }
}
