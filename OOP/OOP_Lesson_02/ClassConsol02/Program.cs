namespace Finances
{
    class Program
    {
        public static void Main(string[] args)
        {
            ViewBankAccount viewBankAccount = new ViewBankAccount();
            viewBankAccount.ViewAccountSet();
            viewBankAccount.ViewAccount();
        }
    }
}
