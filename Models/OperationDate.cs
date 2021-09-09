using System;
using System.Collections.Generic;

namespace Intraday.Models
{
    public class OperationDate
    {
        public DateTime Data
        { get; set; }

        public List<Operation> Operations
        { get; set;}

        public OperationDate(DateTime data)
        {
            this.Data = data;
            this.Operations = new List<Operation>();     

        }

        public override string ToString() {
            return $"A data criada é: {this.Data.ToShortDateString()}";
        }
    }
}