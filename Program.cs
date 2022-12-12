using Banco.Modelos;
using System.Security.AccessControl;

try
{
    Console.WriteLine("######     ###    ##   ##    ####    #####\r\n ##  ##   ## ##   ###  ##   ##  ##  ### ###\r\n ##  ##  ##   ##  #### ##  ##" +
    "       ##   ##\r\n #####   ##   ##  #######  ##       ##   ##\r\n ##  ##  #######  ## ####  ##       ##   ##\r\n ##" +
    "  ##  ##   ##  ##  ###   ##  ##  ### ###\r\n######   ##   ##  ##   ##    ####    #####\n");

    string? opcao;
    List<ContaBancaria> listaContas = new List<ContaBancaria>();
    ContaBancaria conta = new ContaBancaria();

    do
    {
        #region Menu
        Console.WriteLine("::::::ABRIR UMA CONTA = 1::::::");
        Console.WriteLine("::::::HISTÓRICO DE TRANSAÇÃO = 2::::::");
        Console.WriteLine("::::::REALIZAR SAQUE = 3::::::");
        Console.WriteLine("::::::REALIZAR DEPOSITO = 4::::::");
        Console.WriteLine("::::::CONTAS CADASTRADAS = 6::::::");
        Console.WriteLine("::::::SAIR = 0::::::\n");



        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                Console.WriteLine("Qual tipo de conta deseja criar? \n1 = Padrão \n" +
                    "2 = Presente \n3 = Rendimento");

                opcao = Console.ReadLine();

                Console.WriteLine("Informe o nome do titular da conta:");

                string? nome = Console.ReadLine();

                Console.WriteLine("Informe o saldo inicial:");

                decimal saldoInicial = Convert.ToDecimal(Console.ReadLine());

                switch (opcao)
                {
                    case "1":

                        conta = new ContaBancaria(nome, saldoInicial);

                        break;

                    case "2":
                        Console.WriteLine("Digite o valor do Presente");

                        decimal valorPresente = Convert.ToDecimal(Console.ReadLine());

                        conta = new ContaCartaoPresente(nome, saldoInicial, valorPresente);

                        break;

                    case "3":

                        conta = new ContaGanhaJuros(nome, saldoInicial);
                        break;

                    default:
                        Console.WriteLine("opção inválida");
                        break;
                }
                
                listaContas.Add(conta);

                break;

            case "2":

                Console.WriteLine("1 = Listar todas as contas");
                Console.WriteLine("2 = listar uma conta específica");
                
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        ContaService.ListarHistorico(listaContas);
                        break;
                    case "2":
                        Console.WriteLine("Digite o número da conta que deseja visualizar o histórico: ");

                        ContaService.ListarHistorico(listaContas, Console.ReadLine());
                        break;

                    default: 
                        Console.WriteLine("opção inválida");
                        break;
                }
                

                

                break;

            case "3":

                try
                {
                    Console.WriteLine("Digite o número da conta que deseja efetuar o SAQUE: ");


                    conta = ContaService.BuscarConta(listaContas, Console.ReadLine());

                    Console.WriteLine("Digite o valor do saque:");

                    string? valorSaque = Console.ReadLine();

                    Console.WriteLine("Digite uma descricao para o saque:");

                    string? descSaque = Console.ReadLine();


                    conta.Sacar(Convert.ToDecimal(valorSaque), DateTime.Now, descSaque);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                break;

            case "4":

                Console.WriteLine("Digite o número da conta que deseja efetuar o DEPOSITO: ");

                conta = ContaService.BuscarConta(listaContas, Console.ReadLine());

                Console.WriteLine("Digite o valor do deposito");

                string? valorDeposito = Console.ReadLine();

                Console.WriteLine("Digite uma descricao para o deposito:");

                string? descDepo = Console.ReadLine();

                try
                {
                    conta.Depositar(Convert.ToDecimal(valorDeposito), DateTime.Now, descDepo);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine("Deposito Realizado com sucesso \n");

                break;

            case "5":

                Console.WriteLine("Digite um valor para iniciar e recarregar Cartao Presente");
                ContaCartaoPresente CartaoPresente = new ContaCartaoPresente("Cartão Presente", 100, 50);
                break;

            case "6":

                foreach (var c in listaContas)
                {
                    Console.WriteLine($"Tipo:{c.GetType().Name} Conta: {c.Numero}, Titular: {c.Titular}, Saldo: {c.Saldo}\n");
                }
                break;

            case "0":
                Console.WriteLine("Saindo do Sistema...");
                break;

            default:
                Console.WriteLine("opção inválida");
                break;

        }
        #endregion
    } while (opcao != "0");

}
catch (ArgumentException e)
{
    Console.WriteLine("Exceção caputrada tentando criar conta com valor inválido");
    Console.WriteLine(e.ToString());
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exceção caputrada tentando realizar saque");
    Console.WriteLine(e.ToString());
}
