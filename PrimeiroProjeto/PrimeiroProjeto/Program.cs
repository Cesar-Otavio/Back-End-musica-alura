//Screen Sound
using System.Security.AccessControl;

string Boa_Vinda = "Boas vindas ao Pixel.Flag\n";
//List<string> lista_das_bandas = new List<string> {"Dj cz", "FF" };
Dictionary<string, List<int>> bandas_registradas = new Dictionary<string, List<int>>();
bandas_registradas.Add("Cz'Dj", new List<int> { 10, 8, 6});
bandas_registradas.Add("Dj", new List<int> { });

void Exibir_logo()
{
    Console.WriteLine(@"

█▀█ █ ▀▄▀ █▀▀ █░░ ░ █▀▀ █░░ ▄▀█ █▀▀
█▀▀ █ █░█ ██▄ █▄▄ ▄ █▀░ █▄▄ █▀█ █▄█
");
    Console.WriteLine(Boa_Vinda);
}

void Exibir_opcoes()
{
    Console.Clear();
    Exibir_logo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcao_escolhida = Console.ReadLine()!; // A ! não deixa ela retornar um valor nulo.
    int opcao_escolhida_numerica = int.Parse(opcao_escolhida); // O int parse transforma uma string em um numero inteiro.

    switch (opcao_escolhida_numerica) 
    {
        case 1: registrar_bandas();
            break;
        case 2: mostrar_bandas();
            break;
        case 3: avaliar_uma_banda();
            break;
        case 4: Console.WriteLine("Você escolheu a opção " + opcao_escolhida);
            break;
        case -1: Console.WriteLine("Até a proxima :)");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void registrar_bandas()
{
    Console.Clear();
    Exibir_logo();
    exibir_titulo_da_opcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nome_da_banda = Console.ReadLine()!;
    bandas_registradas.Add(nome_da_banda, new List<int>());
    Console.WriteLine($"A banda {nome_da_banda} Foi registrada com sucesso! ");
    Thread.Sleep(2000);
    Console.Clear();
    Exibir_opcoes();
}

void mostrar_bandas()
{
    Console.Clear();
    Exibir_logo();
    exibir_titulo_da_opcao("Exibindo todas as bandas registradas.");
    //for (int i = 0; i < lista_das_bandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {lista_das_bandas[i]}");
    //}
    foreach(string banda in bandas_registradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu!");
    Console.ReadKey();
    Console.Clear();
    Exibir_opcoes();
}

void exibir_titulo_da_opcao(string titulo)
{
    int quantidade_de_letras = titulo.Length;
    string tracos = string.Empty.PadLeft(quantidade_de_letras, '-');
    Console.WriteLine(tracos);
    Console.WriteLine(titulo);
    Console.WriteLine(tracos + "\n");
}

void avaliar_uma_banda()
{
    //digite qual banda que deseja avaliar
    //saber se existe no dicionario >> atribuir uma nota
    //senão volta ao menu principal
    Console.Clear();
    Exibir_logo();
    exibir_titulo_da_opcao("Avaliar banda");
    Console.Write("Digite a banda que deseja avaliar: ");
    string nome_da_banda = Console.ReadLine()!;
    if (bandas_registradas.ContainsKey(nome_da_banda))
    {
        Console.Write($"Qual nota que a banda {nome_da_banda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas_registradas[nome_da_banda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nome_da_banda}!");
        Thread.Sleep(2000);
        Exibir_opcoes();
    }
    else 
    {
        Console.WriteLine($"A banda {nome_da_banda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu.");
        Console.ReadKey(true);
        Console.Clear();
        Exibir_opcoes();
    }
}

Exibir_logo();
Exibir_opcoes();