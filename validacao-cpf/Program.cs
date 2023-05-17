using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    static string cpf { get; set; } = "";
    static bool close { get; set; } = false;
    static List<int> digitsToConfirmFirst = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static List<int> digitsToConfirmSecond = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static void Main(string[] args)
    {
        do
        {
            do
            {
                Console.Clear();
                Console.Write("digite o cpf(apenas números):");
                Program.cpf = Console.ReadLine();
            } while (!Program.VerifyInput(cpf.Trim()));

            Program.VerifyCpf(cpf.Trim());
        } while (Program.close == true);
    }

    static bool VerifyInput(string cpf)
    {
        bool result = true;

        if (String.IsNullOrWhiteSpace(cpf))
        {
            Program.Response("É necessário digitar corretamente, apenas números.", true);
            result = false;
        }
        else if (!Double.TryParse(cpf, out double doubleCpf))
        {
            Program.Response("É necessário digitar corretamente, apenas números.", true);
            result = false;
        }
        else
        {
            if (cpf.Count() < 11)
            {
                Program.Response("CPF deve possuir 11 dígitos.", true);
                result = false;
            }
            else if (cpf.Count() > 11)
            {
                Program.Response("CPF deve possuir apenas 11 dígitos.", true);
                result = false;
            }
        }


        return result;
    }

    static void Response(string resp, bool isError)
    {
        string response = "";
        if (isError)
        {
            response = "CPF INVÁLIDO: " + resp;
        }
        response = resp;

        Console.Clear();
        Console.WriteLine(response);
        Thread.Sleep(3000);
    }

    static bool ResponseReturnBool(string question, bool isError)
    {
        var resultQuestion = "";
        var repeatQuestion = true;
        var response = true;
        do
        {
            Console.Clear();
            Console.WriteLine(question);
            resultQuestion = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(resultQuestion))
            {
                Console.Clear();
                Console.WriteLine("Input Inválido, Tente Novamente");
                Thread.Sleep(3000);
                repeatQuestion = false;
            }
            else
            {
                if (resultQuestion.ToLower().Equals("sim") || resultQuestion.ToLower().Equals("s"))
                {
                    repeatQuestion = false;
                    response = true;
                }
                else if (
                    resultQuestion.ToLower().Equals("nao")
                    ||
                    resultQuestion.ToLower().Equals("não")
                    ||
                    resultQuestion.ToLower().Equals("n"))
                {
                    repeatQuestion = false;
                    response = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input Inválido, Tente Novamente");
                    Thread.Sleep(3000);
                }
            }

        } while (repeatQuestion == true);

        return response;
    }

    static bool GetVerification(List<int> numbers, int Digit, bool isSecond)
    {
        int totalValue = 0;
        var valueToCheck = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (isSecond)
            {
                totalValue = totalValue + numbers[i] * Program.digitsToConfirmSecond[i];
            }
            else
            {
                totalValue = totalValue + numbers[i] * Program.digitsToConfirmFirst[i];
            }
        }
        var resultSum = totalValue % 11;

        if (resultSum == 10)
        {
            valueToCheck = 0;
        }
        else
        {
            valueToCheck = resultSum;
        }

        return valueToCheck == Digit ? true : false;
    }

    static void VerifyCpf(string cpf)
    {
        int FirstDigitToConfirm = Int32.Parse(cpf.Substring(cpf.Length - 2, 1));
        int SecondDigitToConfirm = Int32.Parse(cpf.Substring(cpf.Length - 1));

        List<int> numbersToConfirmFirst = Program.TransformInt(cpf.Substring(0, cpf.Length - 2));
        List<int> numbersToConfirmSecond = Program.TransformInt(cpf.Substring(0, cpf.Length - 1));

        if (
            Program.GetVerification(numbersToConfirmFirst, FirstDigitToConfirm, false) &&
            Program.GetVerification(numbersToConfirmSecond, SecondDigitToConfirm, true))
        {
            Program.close = Program.ResponseReturnBool("CPF Válido!\nDeseja vereficar outro CPF? S/N", false);
        }
    }

    static List<int> TransformInt(string cpf)
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < cpf.Length; i++)
        {
            numbers.Add(int.Parse(cpf[i].ToString()));
        }

        return numbers;
    }
}