using System;

namespace DelegatesTapPucMinas
{
    class Program
    {
        delegate void ExibirDados();

        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\t\t\tEXEMPLOS DELEGATE");
            Console.WriteLine("------------------------------------------------------------------");

            SimularCalculadora();
            ExibirDadosAluno();
        }

        #region Calculadora
        private static void SimularCalculadora()
        {
            Console.WriteLine("=== Calculadora Delegate ===");

            Console.Write("Digite o primeiro valor: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("\r\nDigite o segundo valor: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("\r\nEscolha uma opção " +
                "(1 = Soma / 2 = Subtração / 3 = Multiplicação / 4 = Divisão): ");

            int opcao = int.Parse(Console.ReadLine());

            Func<int, int, int> calcular;

            switch (opcao)
            {
                case 1:
                    calcular = (a, b) => a + b;
                    break;
                case 2:
                    calcular = (a, b) => a - b;
                    break;
                case 3:
                    calcular = (a, b) => a * b;
                    break;
                case 4:
                    calcular = (a, b) => a / b;
                    break;
                default:
                    Console.ReadKey();
                    return;
            }

            EscreverResultado(a, b, calcular);
            Console.ReadKey();
        }

        private static void EscreverResultado(int a, int b, Func<int, int, int> calcular)
        {
            int resultado = calcular(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
        #endregion

        #region Aluno
        private static void ExibirDadosAluno()
        {
            Console.WriteLine("=== Exemplo Delegate Multicast ===");

            Aluno aluno1 = new Aluno("Primeiro", new DateTime(1994, 8, 11), 1);
            Aluno aluno2 = new Aluno("Segundo", new DateTime(1996, 7, 25), 2);

            ExibirDados exibirDados = null; // declara um delegate vazio

            // adiciona métodos ao delegate
            exibirDados += new ExibirDados(aluno1.ExibirNome);
            exibirDados += new ExibirDados(aluno1.ExibirNumeroMatricula);

            exibirDados += new ExibirDados(aluno2.ExibirNome);
            exibirDados += new ExibirDados(aluno2.ExibirNumeroMatricula);

            exibirDados(); // invoca o delegate.

            Console.ReadKey();
        }

        class Aluno
        {
            private string _nome;
            private DateTime _dataNascimento;
            private int _numeroMatricula;

            public Aluno(string nome, DateTime dataNascimento, int numeroMatricula)
            {
                _nome = nome;
                _dataNascimento = dataNascimento;
                _numeroMatricula = numeroMatricula;
            }

            public void ExibirNome() =>
                Console.WriteLine("Nome: " + _nome);
            public void ExibirDataNascimento() =>
                Console.WriteLine("Data nascimento: " + _dataNascimento.ToString("dd/MM/yyyy"));
            public void ExibirNumeroMatricula() =>
                Console.WriteLine("Matrícula: " + _numeroMatricula);
        }
        #endregion
    }
}
