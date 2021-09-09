namespace Intraday.Models
{
    public class Operation
    {
        public string Id
        { get; set; }
        public double Balance
        { get; set; }
        public Operation(string code, double quantity)
        {
            this.Id = code;
            this.Balance = quantity;
        }

        public override string ToString() {
            return $"Operação criada. ID: {this.Id}  Saldo: R$: {this.Balance}";
        }
    }
}