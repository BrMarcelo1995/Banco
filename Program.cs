using Banco.Modelos;

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
        Console.WriteLine("::::::CADASTRAR CONTA = 1::::::");
        Console.WriteLine("::::::HISTÓRICO DE TRANSAÇÃO = 2::::::");
        Console.WriteLine("::::::REALIZAR SAQUE = 3::::::");
        Console.WriteLine("::::::REALIZAR DEPOSITO = 4::::::");
        Console.WriteLine("::::::CARTÃO PRESENTE = 5::::::");
        Console.WriteLine("::::::CONTAS CADASTRADAS = 6::::::");
        Console.WriteLine("::::::SAIR = 0::::::\n");

        

        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":

                #region collection
                Console.WriteLine("Informe o nome do titular da conta:");

                string? nome = Console.ReadLine();

                Console.WriteLine("Informe o saldo inicial:");

                decimal saldoInicial = Convert.ToDecimal(Console.ReadLine());

                conta = new ContaBancaria(nome, saldoInicial);

                listaContas.Add(conta);

                #endregion
                break;

            case "2":
                Console.WriteLine("Digite o número da conta que deseja visualizar o histórico: ");

                string? numeroConta = Console.ReadLine();

                Console.WriteLine(ContaService.BuscarConta(listaContas, numeroConta).GetHistorico());

                break;

            case "3":

                Console.WriteLine("Digite o número da conta que deseja efetuar o SAQUE: ");

                numeroConta = Console.ReadLine();


                conta = ContaService.BuscarConta(listaContas, numeroConta);

                Console.WriteLine("Digite o valor do saque:");

                string? valorSaque = Console.ReadLine();

                Console.WriteLine("Digite uma descricao para o saque:");

                string? descSaque = Console.ReadLine();

                try
                {
                    conta.Sacar(Convert.ToDecimal(valorSaque), DateTime.Now, descSaque);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                break;

            case "4":

                Console.WriteLine("Digite o número da conta que deseja efetuar o DEPOSITO: ");

                numeroConta = Console.ReadLine();

                conta = ContaService.BuscarConta(listaContas, numeroConta);

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
                    Console.WriteLine($"Conta: {c.Numero}, Titular: {c.Titular}, Saldo: {c.Saldo}\n");
                }      
                break;

            case "0":
                Console.WriteLine("Saindo do Sistema...");
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