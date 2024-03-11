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
            string Palavra = Console.ReadLine();//Salva apalavra da rodada
            Console.Write("Informe a dica: ");
            string Dica = Console.ReadLine();//Salva a dica da rodada
            int Tentativas = 6;
            bool Ok = false;//Checa acerto de letras
            bool Jogo = true;//Mantem o whilw ativo

            char[] Caracteres = Palavra.ToCharArray();//Converte Palavra para char array
            char[] Forca = new char[Palavra.Length];//Array vazio usado pra esconder a resposta
            List<char> Letras = new List<char>();//Lista que guarda letras usadas

            for (int i = 0;  i < Caracteres.Length; i++)//Preenche Forca com " " e "_"
            {
                if (Caracteres[i] == ' ')//Preserva os espaços
                {
                    Forca[i] = ' ';
                }

                else
                {
                    Forca[i] = '_';//Add um _ pra cada item em Caracteres
                }
            }

            while (Jogo)
            {
                Console.Clear();
                Console.WriteLine("JOGO DA FORCA");
                Console.WriteLine("DICA: {0}", Dica);
                Console.WriteLine("TENTATIVAS: {0}\n", Tentativas);
                Console.WriteLine(string.Join("", Forca));//Escreve cada item de Forca
                Console.Write("\nLETRAS: ");
                Console.Write(string.Join(" - ", Letras));//Escreve cada item de Letras com " - " entre eles

                var Gan = Forca.Count(s => s == '_');//Conta cada _ em Forca

                if (Gan == 0)//Se Forca sem _, então ganhou
                {
                    Console.WriteLine("\nVOCÊ GANHOU!");
                    break;//Quebra o while
                }

                if (Tentativas == 0)//Se acabarem as tentativas, então perdeu
                {
                    Console.WriteLine("\n\nVOCÊ PERDEU!");
                    Console.WriteLine("RESPOSTA: {0}", Palavra);//Revela a resposta
                    break;//Quebra o While
                }

                Console.Write("\nINFORME UMA LETRA: ");
                char Letra = Console.ReadKey().KeyChar;//Lê e armazena a tecla pressionada em Letra
                Letras.Add(Letra);//Adiciona Letra na lista Letras

                for (int i = 0; i < Caracteres.Length; ++i)//Verifica se Letra esá presente em Caracteres
                {
                    if (Caracteres[i] == Letra)
                    {
                        Forca[i] = Letra;
                        Ok = true;//Caso haja igualdade, Ok = true. Acertou
                    }
                }
                if (Ok)//Caso haja acerto
                {
                    Ok = false;//Redefine o valor de Ok
                }

                else//Se não houve acerto, Tentativas--
                {
                    Tentativas--;
                }
            }
        }   
    }
}
