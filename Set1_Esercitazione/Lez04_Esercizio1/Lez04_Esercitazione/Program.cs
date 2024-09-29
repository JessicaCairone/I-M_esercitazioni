using System.Linq.Expressions;

namespace Lez04_Esercitazione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insAbi = true;


            while (insAbi) {
                

                Console.WriteLine("Quale operazione vuoi eseguire?\n" +
                    "Digita + per addizione\n" +
                    "- per sottrazione\n" +
                    "x per prodotto\n" +
                    "/ per divisione\n" +
                    "^ per elevazione a potenza\n" +
                    "R per radice quadrata\n" +
                    "M per eseguire operazioni complesse\n" +
                    "Q per terminare il programma\n");
                    

                string? inputUtente = Console.ReadLine();
                try
                {
                    switch (inputUtente)
                    {
                        case "+":
                            Console.WriteLine("Inserire il primo numero");
                            string? input1 = Console.ReadLine();
                            double num1 = Convert.ToDouble(input1);
                            Console.WriteLine("Inserire il secondo numero");
                            string? input2 = Console.ReadLine();
                            double num2 = Convert.ToDouble(input2);
                            Console.WriteLine($"Risultato:{num1 + num2}");
                            break;
                        case "-":
                            Console.WriteLine("Inserire il primo numero");
                            string? input3 = Console.ReadLine();
                            double num3 = Convert.ToDouble(input3);
                            Console.WriteLine("Inserire il secondo numero");
                            string? input4 = Console.ReadLine();
                            double num4 = Convert.ToDouble(input4);
                            Console.WriteLine($"Risultato:{num3 - num4}");
                            break;
                        case "x":
                            Console.WriteLine("Inserire il primo numero");
                            string? input5 = Console.ReadLine();
                            double num5 = Convert.ToDouble(input5);
                            Console.WriteLine("Inserire il secondo numero");
                            string? input6 = Console.ReadLine();
                            double num6 = Convert.ToDouble(input6);
                            Console.WriteLine($"Risultato:{num5 * num6}");
                            break;
                        case "/":
                            Console.WriteLine("Inserire il primo numero");
                            string? inputDividendo = Console.ReadLine();
                            double dividendo = Convert.ToDouble(inputDividendo);
                            Console.WriteLine("Inserire il secondo numero");
                            string? inputDivisore = Console.ReadLine();
                            double divisore = Convert.ToDouble(inputDivisore);
                            if (divisore == 0)
                            {
                                Console.WriteLine("ERRORE: il divisore non può essere zero");
                            }
                            else
                                Console.WriteLine($"Risultato:{dividendo / divisore}");
                            break;
                        case "^":
                            Console.WriteLine("Inserire il primo numero");
                            string? input7 = Console.ReadLine();
                            double num7 = Convert.ToDouble(input7);
                            Console.WriteLine("Inserire il secondo numero");
                            string? input8 = Console.ReadLine();
                            double num8 = Convert.ToDouble(input8);
                            Console.WriteLine($"Risultato:{Math.Pow(num7, num8)}");
                            break;
                        case "R":
                            Console.WriteLine("Inserire il numero");                         
                          string? inputSqrt = Console.ReadLine();
                            double numSqrt = Convert.ToDouble(inputSqrt);
                            Console.WriteLine($"Risultato:{Math.Sqrt(numSqrt)}");
                            break;
                        case "M":
                            Console.WriteLine("...");
                            break;
                        case "Q":
                            insAbi = false;
                            Console.WriteLine("Grazie per aver usato la nostra calcolatrice");
                            break;
                        default:
                            Console.WriteLine("Comando non valido!");
                            break;
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("ERRORE: formato non valido");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRORE");
                  }
                }
              } 
        }
    }

