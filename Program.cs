using System;
using System.Collections.Generic;
using NewProjectBarbearia2._0.models;

class Program
{
    static List<Cliente> clientes = new List<Cliente>();
    static Agenda agenda = new Agenda();

    static void Main(string[] args)
    {
        // Aqui você pode adicionar código para interagir com o usuário e gerenciar o cadastro e agendamento
        // Por exemplo, você pode criar um menu para adicionar clientes, agendar horários, etc.

        // Adicionar alguns clientes de exemplo
        clientes.Add(new Cliente("João", "Silva", "11999999999", "joaosilva", "senha123"));
        clientes.Add(new Cliente("Maria", "Oliveira", "11988888888", "mariaoliveira", "senha321"));

        // Exibir menu e interagir com o usuário
        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("Bem Vindo,$ A Barbearia Corte Perfeito!");
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Agendar Horário");
            Console.WriteLine("3 - Sair");
            
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    AgendarHorario();
                    break;
                case 3:
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void CadastrarCliente()
{
    Console.Write("Digite o nome do cliente: ");
    string nome = Console.ReadLine();

    Console.Write("Digite o sobrenome do cliente: ");
    string sobrenome = Console.ReadLine();

    Console.Write("Digite o número de telefone do cliente: ");
    string telefone = Console.ReadLine();

    Console.Write("Digite o login do cliente: ");
    string login = Console.ReadLine();

    Console.Write("Digite a senha do cliente: ");
    string senha = Console.ReadLine();

    Cliente novoCliente = new Cliente(nome, sobrenome, telefone, login, senha);
    clientes.Add(novoCliente);

    Console.WriteLine("Cliente cadastrado com sucesso!");

    // Perguntar ao cliente se deseja agendar um horário ou encerrar o atendimento
    Console.WriteLine("Deseja agendar um horário agora?");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não");
    int opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        AgendarHorario(); // Chama o método para agendar horário
    }
    else if (opcao == 2)
    {
        Console.WriteLine("Atendimento encerrado. Obrigado e até logo!");
    }
    else
    {
        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
    }


}

    static void AgendarHorario()
{
    bool continuarAgendamento = true;
    while (continuarAgendamento)
    {
        Console.Write("Digite o login do cliente: ");
        string login = Console.ReadLine();

        Console.Write("Digite a senha do cliente: ");
        string senha = Console.ReadLine();

        // Encontrar o cliente com base no login e senha fornecidos
        Cliente cliente = clientes.FirstOrDefault(c => c.Login == login && c.VerificarSenha(senha));

        if (cliente != null)
        {
            // Mostrar a lista de dias disponíveis
            Console.WriteLine("Dias disponíveis:");
            var diasDisponiveis = agenda.ObterDiasDisponiveis();
            for (int i = 0; i < diasDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {diasDisponiveis[i]:dd/MM/yyyy}");
            }

            // Pedir ao usuário para escolher um dia da lista
            Console.WriteLine("Digite o número do dia que deseja agendar:");
            int escolhaDia = int.Parse(Console.ReadLine()) - 1;

            // Verificar se a escolha do dia é válida
            if (escolhaDia >= 0 && escolhaDia < diasDisponiveis.Count)
            {
                DateTime diaEscolhido = diasDisponiveis[escolhaDia];
                // Mostrar a lista de horários disponíveis no dia escolhido
                Console.WriteLine($"Horários disponíveis para o dia {diaEscolhido:dd/MM/yyyy}:");
                var horariosDisponiveisNoDia = agenda.ObterHorariosDisponiveisNoDia(diaEscolhido);
                for (int j = 0; j < horariosDisponiveisNoDia.Count; j++)
                {
                    Console.WriteLine($"{j + 1} - {horariosDisponiveisNoDia[j]:HH:mm}");
                }

                // Pedir ao usuário para escolher um horário da lista
                Console.WriteLine("Digite o número do horário que deseja agendar:");
                int escolhaHora = int.Parse(Console.ReadLine()) - 1;

                // Verificar se a escolha da hora é válida
                if (escolhaHora >= 0 && escolhaHora < horariosDisponiveisNoDia.Count)
                {
                    DateTime horarioEscolhido = horariosDisponiveisNoDia[escolhaHora];
                    if (agenda.AgendarHorario(horarioEscolhido, cliente))
                    {
                        Console.WriteLine("Horário agendado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível agendar o horário.");
                    }
                }
                else
                {
                    Console.WriteLine("Escolha de horário inválida!");
                }
            }
            else
            {
                Console.WriteLine("Escolha de dia inválida!");
            }
        }
        else
        {
            Console.WriteLine("Login ou senha inválidos!");
        }
Console.WriteLine("Deseja agendar um horário agora?");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não");
    static void Main(string[] args)
    {
    int opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        AgendarHorario(); // Chama o método para agendar horário
    }
    else if (opcao == 2)
    {
        Console.WriteLine("Atendimento encerrado. Obrigado e até logo!");
    }
    else
    {
        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
    }
    }
    Console.WriteLine("Pressione Enter para encerrar...");
    Console.ReadLine();
    }
}

}
