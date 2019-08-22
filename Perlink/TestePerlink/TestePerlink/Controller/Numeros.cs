using System;
using TestePerlink.Domain.Service;

namespace TestePerlink
{
    public class Numero
    {
        private readonly INumeroService numeroService;

        public Numero(INumeroService numeroService)
        {
            this.numeroService = numeroService;
        }

        public Action ObterNumeroFeliz()
        {
            return numeroService.ObterNumeroFeliz();
        }

        public static void Main(string[] args)
        {
            Console.Write("Entre com um número feliz! ");

            int numeroDigitado = int.Parse(Console.ReadLine());
            int unidade, dezena, centena;
            int numeroFeliz = 0;
            double resultado, resultadoUnidade, resultadoDezena, resultadoCentena;

            numeroFeliz = numeroDigitado;
            resultado = Math.Pow(numeroDigitado, 2.0);
            numeroDigitado = (int)resultado;

            for (int i = 0; i < 100; i++)
            {
                if (numeroDigitado > 100)
                {
                    unidade = numeroDigitado % 10;
                    dezena = numeroDigitado / 10;
                    resultadoDezena = dezena % 10;
                    centena = dezena / 10;
                    dezena = (int)resultadoDezena;
                    resultadoUnidade = Math.Pow(unidade, 2.0);
                    resultadoDezena = Math.Pow(dezena, 2.0);
                    resultadoCentena = Math.Pow(centena, 2.0);
                    numeroDigitado = (int)(resultadoUnidade + resultadoDezena + resultadoCentena);
                }
                else
                {
                    unidade = numeroDigitado % 10;
                    dezena = numeroDigitado / 10;
                    resultadoUnidade = Math.Pow(unidade, 2.0);
                    resultadoDezena = Math.Pow(dezena, 2.0);
                    numeroDigitado = (int)(resultadoUnidade + resultadoDezena);
                }

                if (numeroDigitado == 1)
                {
                    Console.WriteLine("O número {0}, é um número feliz: ", numeroFeliz);
                    ValoresImpares();
                }

            }
            Console.WriteLine("O número {0} não é um número feliz: ", numeroFeliz);
            Console.WriteLine("");
            ValoresImpares();
        }

        public static void ValoresImpares()
        {
            int resto;
            int[] valoresInteiros = new int[25];

            for (int i = 0; i < valoresInteiros.Length; i++)
            {
                resto = i % 2;
                if (resto != 0)
                {
                    valoresInteiros[i] = i;
                    Console.Write(valoresInteiros[i] + ", ");
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Todos esses números, não são mulitplos de 2: ");

            ValoresMutiplos3(valoresInteiros);

        }

        public static void ValoresMutiplos3(int[] valoresInteiros)
        {
            int resto;

            for (int i = 1; i < valoresInteiros.Length; i++)
            {
                resto = i % 3;
                if (resto == 0)
                {
                    valoresInteiros[i] = i;
                    Console.Write(valoresInteiros[i] + ", ");
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Todos esses números, são mulitplos de 3: ");
            ValoresMutiplos7(valoresInteiros);


        }

        public static void ValoresMutiplos7(int[] valoresInteiros)
        {
            int resto;

            for (int i = 1; i < valoresInteiros.Length; i++)
            {
                resto = i % 7;
                if (resto == 0)
                {
                    valoresInteiros[i] = i;
                    Console.Write(valoresInteiros[i] + ", ");
                }

            }
            Console.WriteLine("");
            Console.WriteLine("Todos esses números, são mulitplos de 7: ");
            Console.ReadKey();

        }

    }
}
