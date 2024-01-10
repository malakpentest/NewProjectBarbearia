using projeto_barbearia.models;

// Definir a classe Program
class Program
{
    // Definir uma lista de clientes
    static List<Cliente> clientes = new List<Cliente>();

    // Definir uma lista de agendamentos
    static List<Agendamento> agendamentos = new List<Agendamento>();

    // Definir o método Main
    static void Main(string[] args)
    {
        // Mostrar o menu de opções
        Console.WriteLine("Bem-vindo ao sistema de agendamento da barbearia!");
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Cadastrar cliente");
        Console.WriteLine("2 - Agendar horário");
        Console.WriteLine("3 - Listar clientes");
        Console.WriteLine("4 - Listar agendamentos");
        Console.WriteLine("5 - Sair");

        // Ler a opção escolhida
        string opcao = Console.ReadLine();

        // Executar a ação correspondente à opção
        switch (opcao)
        {
            case "1":
                CadastrarCliente();
                break;
            case "2":
                AgendarHorario();
                break;
            case "3":
                ListarClientes();
                break;
            case "4":
                ListarAgendamentos();
                break;
            case "5":
                Sair();
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }

    // Definir o método para cadastrar cliente
    static void CadastrarCliente()
    {
        // Pedir o nome do cliente
        Console.WriteLine("Digite o nome do cliente:");
        string nome = Console.ReadLine();

        // Pedir o sobrenome do cliente
        Console.WriteLine("Digite o sobrenome do cliente:");
        string sobrenome = Console.ReadLine();

        // Pedir o celular do cliente
        Console.WriteLine("Digite o celular do cliente:");
        string celular = Console.ReadLine();

        // Criar um objeto da classe Cliente com os dados informados
        Cliente cliente = new Cliente(nome, sobrenome, celular);

        // Adicionar o cliente na lista de clientes
        clientes.Add(cliente);

        // Mostrar uma mensagem de confirmação
        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    // Definir o método para agendar horário
    static void AgendarHorario()
    {
        // Verificar se há clientes cadastrados
        if (clientes.Count == 0)
        {
            // Mostrar uma mensagem de erro
            Console.WriteLine("Não há clientes cadastrados!");
            return;
        }

        // Pedir o dia do agendamento
        Console.WriteLine("Digite o dia do agendamento (dd/mm/aaaa):");
        string dia = Console.ReadLine();

        // Pedir a hora do agendamento
        Console.WriteLine("Digite a hora do agendamento (hh:mm):");
        string hora = Console.ReadLine();

        // Converter a data e a hora em um objeto da classe DateTime
        DateTime data = DateTime.Parse(dia + " " + hora);

        // Mostrar a lista de clientes cadastrados
        Console.WriteLine("Escolha um cliente da lista:");
        for (int i = 0; i < clientes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {clientes[i].Nome} {clientes[i].Sobrenome}");
        }

        // Ler o índice do cliente escolhido
        int indice = int.Parse(Console.ReadLine()) - 1;

        // Verificar se o índice é válido
        if (indice < 0 || indice >= clientes.Count)
        {
            // Mostrar uma mensagem de erro
            Console.WriteLine("Índice inválido!");
            return;
        }

        // Obter o cliente correspondente ao índice
        Cliente cliente = clientes[indice];

        // Criar um objeto da classe Agendamento com os dados informados
        Agendamento agendamento = new Agendamento(data, cliente);

        // Adicionar o agendamento na lista de agendamentos
        agendamentos.Add(agendamento);

        // Mostrar uma mensagem de confirmação
        Console.WriteLine("Horário agendado com sucesso!");
    }

    // Definir o método para listar clientes
    static void ListarClientes()
    {
        // Verificar se há clientes cadastrados
        if (clientes.Count == 0)
        {
            // Mostrar uma mensagem de erro
            Console.WriteLine("Não há clientes cadastrados!");
            return;
        }

        // Mostrar a lista de clientes cadastrados
        Console.WriteLine("Lista de clientes:");
        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"{cliente.Nome} {cliente.Sobrenome} - {cliente.Celular}");
        }
    }

    // Definir o método para listar agendamentos
    static void ListarAgendamentos()
    {
        // Verificar se há agendamentos feitos
        if (agendamentos.Count == 0)
        {
            // Mostrar uma mensagem de erro
            Console.WriteLine("Não há agendamentos feitos!");
            return;
        }

        // Mostrar a lista de agendamentos feitos
        Console.WriteLine("Lista de agendamentos:");
        foreach (Agendamento agendamento in agendamentos)
        {
            Console.WriteLine($"{agendamento.Data} - {agendamento.Cliente.Nome} {agendamento.Cliente.Sobrenome}");
        }
    }

    // Definir o método para sair do programa
    static void Sair()
    {
        // Mostrar uma mensagem de despedida
        Console.WriteLine("Obrigado por usar o sistema de agendamento da barbearia!");
        Console.WriteLine("Até mais!");
    }
       

    
}