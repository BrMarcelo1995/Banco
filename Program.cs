using Banco.Modelos;

try
{

    string opcao;

    ContaBancaria conta = conta = new ContaBancaria("Antônio Marcelo", 1000);

    do
    {
        #region Menu
        Console.WriteLine("::::::CAIXA ELETRÔNICO::::::");
        Console.WriteLine("::::::CONTAS CADASTRADAS = 1::::::");
        Console.WriteLine("::::::HISTÓRICO DE TRANSAÇÃO = 2::::::");
        Console.WriteLine("::::::REALIZAR SAQUE = 3::::::");
        Console.WriteLine("::::::REALIZAR DEPOSITO = 4::::::");
        Console.WriteLine("::::::CARTÃO PRESENTE = 5::::::");
        Console.WriteLine("::::::SAIR = 0::::::\n");

        opcao = Console.ReadLine();

        

        switch (opcao)
        {
            case "1":
                Console.WriteLine($"Conta: {conta.Numero}, Titular: {conta.Titular}, Saldo: {conta.Saldo}\n");
                break;

            case "2":
                Console.WriteLine(conta.GetHistorico());
                break;

            case "3":
                Console.WriteLine("Digite o valor do saque:");

                string valorSaque = Console.ReadLine();

                Console.WriteLine("Digite uma descricao para o saque:");

                string descSaque = Console.ReadLine();

                conta.Sacar(Convert.ToDecimal(valorSaque), DateTime.Now, descSaque);

                Console.WriteLine("Saque efetuado com sucesso \n");

                break;

            case "4":
                Console.WriteLine("Digite o valor do deposito");

                string valorDeposito = Console.ReadLine();

                Console.WriteLine("Digite uma descricao para o deposito:");

                string descDepo = Console.ReadLine();

                conta.Depositar(Convert.ToDecimal(valorDeposito), DateTime.Now, descDepo);

                Console.WriteLine("Deposito Realizado com sucesso \n");

                break;

            case"5":

                Console.WriteLine("Digite um valor para iniciar e recarregar Cartao Presente");
                ContaCartaoPresente CartaoPresente = new ContaCartaoPresente("Cartão Presente", 100, 50);
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
