using System;

class Program
{
    static void Main(string[] args)
    {
        float aplicacao;
        float juros_simples, juros_simplesT = 0, juros_compostos, juros_compostoT = 0;
        int periodo;
        float taxa_de_juros;

        Console.WriteLine("\n Digite o valor da aplicacao:");
        aplicacao = float.Parse(Console.ReadLine());

        Console.WriteLine("\n Digite o periodo da aplicacao (em meses):");
        periodo = int.Parse(Console.ReadLine());

        Console.WriteLine("\n Digite a taxa de juros de aplicacao (em %):");
        taxa_de_juros = float.Parse(Console.ReadLine());

        for (int i = 0; i < periodo; i++)
        {
            juros_simples = aplicacao * taxa_de_juros / 100;
            Console.WriteLine("\n Juros simples no mes {0}: {1}", i + 1, juros_simples);
            juros_simplesT += juros_simples;
        }

        Console.WriteLine("\n Juros simples totais: {0}", juros_simplesT);

        float aplicacaoAcumulada = aplicacao;

        for (int i = 0; i < periodo; i++)
        {
            juros_compostos = aplicacaoAcumulada * taxa_de_juros / 100;
            Console.WriteLine("\n Juros compostos no mes {0}: {1:F2}", i + 1, juros_compostos);
            juros_compostoT += juros_compostos;
            aplicacaoAcumulada += juros_compostos;
        }
        Console.WriteLine("\n Juros compostos totais: {0}", (aplicacao * (Math.Pow(1 + taxa_de_juros / 100, periodo) - 1)).ToString("0.00"));

        Console.ReadLine();
    }
}
