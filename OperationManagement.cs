using System.Collections.Generic;
using Intraday.Models;
using System;

namespace Intraday
{
    public class OperationManagement
    {
        private List<OperationDate> operationDates;

        public OperationManagement() {
            operationDates = new List<OperationDate>();
        }

        public void RegisterOperationDate(OperationDate operationDate) {
            operationDates.Add(operationDate);
        }

        public void ShowOperationDate(DateTime date)
        {
            List<OperationDate> dateOperations = this.operationDates.FindAll(ops => ops.Data.ToShortDateString().Equals(date.ToShortDateString()));

            Console.Clear();
            Program.writeHeader($"Operações do dia: {date.ToShortDateString()}");
            Console.WriteLine("-----------------------");
            Console.WriteLine($" ID Saldo");
            Console.WriteLine("-----------------------");

            dateOperations.ForEach(dt => dt.Operations.ForEach(op => Console.WriteLine($" {op.Id}   {op.Balance}")));

            double totalBalance = 0;

            dateOperations.ForEach(e => e.Operations.ForEach(o => totalBalance += o.Balance));

            Console.WriteLine($"\n Resultado: R$ {totalBalance}");

        }
    }
}