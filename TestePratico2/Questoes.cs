using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestePratico2
{
    public class Questoes : IQuestoes
    {
        public void Questao1()
        {
            Console.WriteLine("A resposta da questão 1 é letra B. O valor armazenado em N elevado ao quadrado");
        }

        public void Questao2()
        {
            Console.WriteLine("A resposta da questão 2 é letra E. Apenas as consultas C1, C2 e C3 são equivalentes.");
        }

        public void Questao3()
        {
            string arquivo = System.IO.File.ReadAllText(@"C:\Temp\text.txt", Encoding.Default);

            var arquivoArray = arquivo.Split("\r\n");

            var resultado = CalcularQuestao3(arquivoArray).ToArray();

            for (int i = 0; i < arquivoArray.Length; i++)
            {
                Console.WriteLine($"{arquivoArray[i]} {resultado[i]}");
            }        

        }

        public void Questao4()
        {
            string arquivo = System.IO.File.ReadAllText(@"C:\Temp\text2.txt", Encoding.Default);

            var arquivo1 = arquivo.Replace("\r\n", "");
            var tamanho = arquivo1.Substring(0, 1);
            arquivo1 = arquivo1.TrimStart(char.Parse(tamanho));
            var matriz = GerarMatriz(int.Parse(tamanho), arquivo1);

            var resultado = CalcularGanhador(int.Parse(tamanho), matriz);

            Console.WriteLine($"O vencedor recebeu {resultado} votos");
        }

        public void Questao5()
        {
            int numeroIteracoes = 0;

            Console.WriteLine("Digite o número de termos");

            if (int.TryParse(Console.ReadLine(), out numeroIteracoes))
                Console.WriteLine($"O somatório dos termos dessa série para n = {numeroIteracoes} é igual a {CalcularQuestao5(numeroIteracoes)} ");
            else
                Console.WriteLine("O valor digitado é invalido");
        }

        public void Questao6()
        {
            int numeroIteracoes = 0;
            double valorX = 0D;

            Console.WriteLine("Digite o número de termos");
            if (int.TryParse(Console.ReadLine(), out numeroIteracoes))
                Console.WriteLine("Digite o valor de X");
            else
                Console.WriteLine("O valor digitado é invalido");

            if (double.TryParse(Console.ReadLine(), out valorX))
                Console.WriteLine($"O somatório dos termos dessa série para n = {numeroIteracoes} é igual a {CalcularQuestao6(numeroIteracoes, valorX)} ");
            else
                Console.WriteLine("O valor digitado é invalido");
        }

        private IEnumerable<string> CalcularQuestao3(string[] valores)
        {
            foreach (var valor in valores)
                yield return VerificarNumeroMultipoOnze(valor) ? "é múltiplo de 11" : " não é múltiplo de 11";
        }

        private void CalcularQuestao4(string[] arquivo)
        {
            var numeroAlunos = int.Parse(arquivo[0]);

            var arquivoVotacao = new int[numeroAlunos, numeroAlunos];


        }

        private int CalcularQuestao5(int n)
        {
            if (n <= 0)
                return 0;

            var arrayTotal = new int[n];
            var retorno = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                    arrayTotal[i] = 2;

                else
                    arrayTotal[i] = arrayTotal[i - 1] + 3;

                retorno += arrayTotal[i];
            }

            return retorno;
        }

        private double CalcularQuestao6(int n, double x)
        {
            var resultado = 0D;

            for (int i = 1; i <= n; i++)
            {
                var dividendo = Math.Pow(x, i);
                var divisor = i == 1 ? i : i + 2;

                if (i%2 == 0)
                    resultado -= dividendo / divisor;
                else
                    resultado += dividendo / divisor;
            }

            return resultado;
        }

        private bool VerificarNumeroMultipoOnze(string numero)
        {
            var numeroSeparado = numero.ToCharArray();
            var somatorioImpares = 0;
            var somatorioPares = 0;

            for (int i = 1; i <= numeroSeparado.Length; i++)
            {
                var numeroConvertido = int.Parse(numeroSeparado[i - 1].ToString());

                if (i % 2 == 0)
                    somatorioPares += numeroConvertido;
                else
                    somatorioImpares += numeroConvertido;
            }

            var resultado = somatorioImpares - somatorioPares;

            return resultado == 0 || resultado > 0 ? resultado % 11 == 0
                : (somatorioPares - somatorioPares) > 0 ? (somatorioPares - somatorioPares) % 11 == 0
                : false;
        }

        private int[,] GerarMatriz(int tamanho, string dados)
        {
            var vetor = dados.ToCharArray();
            var retorno = new int[tamanho, tamanho];
            int cont = 0;
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    retorno[i,j] = int.Parse(vetor[cont].ToString());
                    cont++;
                }
            }

            return retorno;
        }

        private int CalcularGanhador(int tamanho, int[,] votos)
        {
            var retorno = new int[5];

            for (int lin = 0; lin < tamanho; lin++)
            {
                for (int col = 0; col < tamanho; col++)
                {
                    retorno[col] += votos[lin, col];
                }
            }

            return retorno.Max();
        }
    }
}
