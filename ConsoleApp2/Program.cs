using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("CONFIGURANDO O JOGO\n");
            Console.Write("Informe a palavra: ");
            string Palavra = Console.ReadLine();
            Console.Write("Informe a dica: ");
            string Dica = Console.ReadLine();
            int Tentativas = 6;
            bool Ok = false;
            bool Jogo = true;

            char[] Caracteres = Palavra.ToCharArray();
            char[] Forca = new char[Palavra.Length];
            List<char> Letras = new List<char>();

            for (int i = 0;  i < Caracteres.Length; i++)
            {
                if (Caracteres[i] == ' ')
                {
                    Forca[i] = ' ';
                }

                else
                {
                    Forca[i] = '_';
                }
            }

            while (Jogo)
            {
                Console.Clear();
                Console.WriteLine("JOGO DA FORCA");
                Console.WriteLine("DICA: {0}", Dica);
                Console.WriteLine("TENTATIVAS: {0}\n", Tentativas);
                Console.WriteLine(string.Join("", Forca));
                Console.Write("\nLETRAS: ");
                Console.Write(string.Join(" - ", Letras));

                var Gan = Forca.Count(s => s == '_');

                if (Gan == 0)
                {
                    Console.WriteLine("\nVOCÊ GANHOU!");
                    break;
                }

                if (Tentativas == 0)
                {
                    Console.WriteLine("\n\nVOCÊ PERDEU!");
                    Console.WriteLine("RESPOSTA: {0}", Palavra);
                    break;
                }

                Console.Write("\nINFORME UMA LETRA: ");
                char Letra = Console.ReadKey().KeyChar;
                Letras.Add(Letra);

                for (int i = 0; i < Caracteres.Length; ++i)
                {
                    if (Caracteres[i] == Letra)
                    {
                        Forca[i] = Letra;
                        Ok = true;
                    }
                }
                if (Ok)
                {
                    Ok = false;
                }

                else
                {
                    Tentativas--;
                }
            }
        }   
    }
}
