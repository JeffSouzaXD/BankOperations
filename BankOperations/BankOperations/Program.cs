using System.Globalization;

namespace OperacoesBancarias
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria conta;
            Console.Write("Informe o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Informe o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial? (s/n)");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                Console.Write("Informe o valor de depósito inicial: ");
                double depositoInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta = new ContaBancaria(numero, titular, depositoInicial);
            }
            else
            {
                conta = new ContaBancaria(numero, titular);
            }
            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);

            Console.WriteLine();
            Console.WriteLine("Deseja fazer um Deposito na conta? (s/n) ");
            resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                Console.Write("Entre um valor para depósito: ");
                double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                conta.Deposito(quantia);
                Console.WriteLine("Dados da conta atualizados:");
                Console.WriteLine(conta);
            }
            else
            {

                if (conta.SaldoBancario() > 0)
                {
                    Console.WriteLine("Deseja fazer um Saque na conta? (s/n) ");
                    resp = char.Parse(Console.ReadLine());
                    if (resp == 's' || resp == 'S')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Seu saldo é de: $ " + conta.SaldoBancario());
                        Console.Write("Entre um valor para saque: (Uma taxa de $5 é cobrada por saque)");
                        double quantia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        if (quantia  > conta.SaldoBancario()) 
                        {
                            Console.WriteLine("Você não possui saldo suficiente!");
                            return;
                        } else
                        {
                            conta.Saque(quantia);
                            Console.WriteLine("Dados da conta atualizados:");
                            Console.WriteLine(conta);
                        }
                    } else
                    {
                        Console.WriteLine("Agradecemos por usar o nosso banco!");
                    }

                 } else
                {
                    Console.WriteLine("Agradecemos por usar o nosso banco!");
                }
            }

        }
    }
}
