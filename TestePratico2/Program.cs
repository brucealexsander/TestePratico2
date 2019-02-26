using System;

namespace TestePratico2
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuestoes questoes = new Questoes();

            int opcao;
            do
            {
                Console.WriteLine("[ 1 ] Questão 1");
                Console.WriteLine("[ 2 ] Questão 2");
                Console.WriteLine("[ 3 ] Questão 3");
                Console.WriteLine("[ 4 ] Questão 4");
                Console.WriteLine("[ 5 ] Questão 5");
                Console.WriteLine("[ 6 ] Questão 6");
                Console.WriteLine("[ 0 ] Sair do Programa");
                Console.WriteLine("-------------------------------------");
                Console.Write("Digite uma opção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        questoes.Questao1();
                        break;
                    case 2:
                        questoes.Questao2();
                        break;
                    case 3:
                        questoes.Questao3();
                        break;
                    case 4:
                        questoes.Questao4();
                        break;
                    case 5:
                        questoes.Questao5();
                        break;
                    case 6:
                        questoes.Questao6();
                        break;
                    default:
                        SairDoPrograma();
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opcao != 0);
        }

        private static void SairDoPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Vc saiu do Programa. Clique qq tecla para sair...");
        }
    }
}
