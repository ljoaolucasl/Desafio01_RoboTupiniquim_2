namespace Desafio01_RoboTupiniquim_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int roboPrimeiroX, roboPrimeiroY;
            int areaLimiteX, areaLimiteY;
            string direcaoRobo;
            char[] instrucoesPrimeiroRobo;

            Descricoes(1, "Primeiro Robô");
            areaLimiteX = CriaArea("x");
            areaLimiteY = CriaArea("y");

            Descricoes(2, "Primeiro Robô");
            roboPrimeiroX = DefinePosicaoInicialRobo(areaLimiteX, "x");
            roboPrimeiroY = DefinePosicaoInicialRobo(areaLimiteY, "y");

            Descricoes(3, "Primeiro Robô");
            direcaoRobo = DefineDirecaoInicialRobo();

            Descricoes(4, "Primeiro Robô");
            instrucoesPrimeiroRobo = InstrucoesMovimentoEDirecao();
            LerExecutarInstrucoes(ref direcaoRobo, ref roboPrimeiroX, ref roboPrimeiroY, areaLimiteX, areaLimiteY, instrucoesPrimeiroRobo);


            int roboSegundoX, roboSegundoY;
            direcaoRobo = "";
            char[] instrucoesSegundoRobo;

            Descricoes(0, "Segundo Robô");

            Descricoes(2, "Segundo Robô");
            roboSegundoX = DefinePosicaoInicialRobo(areaLimiteX, "x");
            roboSegundoY = DefinePosicaoInicialRobo(areaLimiteY, "y");

            Descricoes(3, "Segundo Robô");
            direcaoRobo = DefineDirecaoInicialRobo();

            Descricoes(4, "Segundo Robô");
            instrucoesSegundoRobo = InstrucoesMovimentoEDirecao();
            LerExecutarInstrucoes(ref direcaoRobo, ref roboSegundoX, ref roboSegundoY, areaLimiteX, areaLimiteY, instrucoesSegundoRobo);

            DesenhaDiamante();

            Descricoes(5, "Segundo Robô");

            Console.ReadLine();
        }

        private static void Descricoes(int numero, string robo)
        {
            switch (numero)
            {
                case 0: Console.WriteLine("\nO Segundo Robô está esperando por instruções!"); break;

                case 1:
                    Console.WriteLine("Temos dois Robôs Tupiniquins que estão explorando Marte!");
                    Console.WriteLine("Qual é o tamanho da área de procura? (x, y)"); break;

                case 2: Console.WriteLine($"\nO {robo} está em qual posição? (x, y)"); break;

                case 3: Console.WriteLine("\nEle está virado para qual polo? (N, S, L, O)"); break;

                case 4:
                    Console.WriteLine("\nAgora o Robô precisa explorar a área!");
                    Console.WriteLine("Que tal mudar a direção e movimentá-lo agora?");
                    Console.WriteLine("Siga as instruções abaixo: ");

                    Console.WriteLine("\nTecle todos os movimentos em uma mesma linha abaixo:\n");
                    Console.WriteLine("(E) para virar para a esquerda");
                    Console.WriteLine("(D) para virar para a direita");
                    Console.WriteLine("(M) para movimentá-lo para frente\n");
                    Console.Write("Instruções: "); break;

                case 5:
                    Console.WriteLine("\nParabéns! Os robôs exploraram as áres indicadas com sucesso!");
                    Console.Write("\nFinalizando Aplicação...\n"); break;
            }
        }

        private static int CriaArea(string xy)
        {
            bool numero;
            int areaXY;

            do
            {
                Console.Write($"{xy} = ");
                string entrada = Console.ReadLine();

                numero = int.TryParse(entrada, out areaXY);

                if (!numero)
                {
                    Console.WriteLine("Apenas números! Tente novamente.");
                }

            } while (!numero);

            return areaXY;
        }

        private static int DefinePosicaoInicialRobo(int areaxy, string xy)
        {
            bool numero;
            int roboxy;

            do
            {
                Console.Write($"{xy} = ");
                string entrada = Console.ReadLine();

                numero = int.TryParse(entrada, out roboxy);

                if (!numero)
                {
                    Console.WriteLine("Usamos apenas números em nossa coordenadas. Tente novamente.");
                }
                else if (roboxy > areaxy)
                {
                    Console.WriteLine("Esta área é perigosa e é fora do limite permitido para o robô...");
                }
            }
            while (roboxy > areaxy || !numero);

            return roboxy;
        }

        private static string DefineDirecaoInicialRobo()
        {
            string direcao = "";

            while (direcao != "N" && direcao != "S" && direcao != "L" && direcao != "O")
            {
                Console.Write($"Polo = ");
                direcao = Console.ReadLine().ToUpper();
            }

            return direcao;
        }

        private static char[] InstrucoesMovimentoEDirecao()
        {
            bool letrasValidas;
            string instrucoesString;
            char[] instrucoesArray;

            while (true)
            {
                letrasValidas = true;

                instrucoesString = Console.ReadLine().ToUpper();

                if (!string.IsNullOrEmpty(instrucoesString) && !string.IsNullOrWhiteSpace(instrucoesString)) { }
                if (instrucoesString.Contains("E") || instrucoesString.Contains("D") || instrucoesString.Contains("M")) { }
                else { letrasValidas = false; }

                if (letrasValidas) { break; }
            }
            instrucoesArray = instrucoesString.ToCharArray();

            return instrucoesArray;
        }

        private static void LerExecutarInstrucoes(ref string direcao, ref int robox, ref int roboy, int areaX, int areaY, char[] instrucoes)
        {
            Console.WriteLine($"\nPosição Inicial: {robox} {roboy} {direcao}\n");

            for (int i = 0; i < instrucoes.Length; i++)
            {
                string descricaoInstrucaoExecutada;

                if (instrucoes[i] == 'E')
                {
                    switch (direcao)
                    {
                        case "N": direcao = "O"; break;
                        case "L": direcao = "N"; break;
                        case "S": direcao = "L"; break;
                        case "O": direcao = "S"; break;
                    }
                    descricaoInstrucaoExecutada = "Virado para esquerda";
                }
                else if (instrucoes[i] == 'D')
                {
                    switch (direcao)
                    {
                        case "N": direcao = "L"; break;
                        case "L": direcao = "S"; break;
                        case "S": direcao = "O"; break;
                        case "O": direcao = "N"; break;
                    }
                    descricaoInstrucaoExecutada = "Virado para direita";
                }
                else if (instrucoes[i] == 'M')
                {
                    bool avisoLimiteArea = false;
                    switch (direcao)
                    {
                        case "N": { roboy++; if (roboy > areaY) { roboy--; avisoLimiteArea = true; } break; }
                        case "L": { robox++; if (robox > areaX) { robox--; avisoLimiteArea = true; } break; }
                        case "S": { roboy--; if (roboy < 0) { roboy++; avisoLimiteArea = true; } break; }
                        case "O": { robox--; if (robox < 0) { robox++; avisoLimiteArea = true; } break; }
                    }
                    if (avisoLimiteArea)
                    {
                        descricaoInstrucaoExecutada = "Atenção, fique dentro da área limite";
                    }
                    else
                    {
                        descricaoInstrucaoExecutada = "Movido para frente";
                    }
                }
                else
                {
                    descricaoInstrucaoExecutada = "Valores inválidos filtrados com sucesso! Aguardando nova instrução";
                }
                Console.WriteLine($"{robox} {roboy} {direcao} - {descricaoInstrucaoExecutada}");
            }
            Console.WriteLine($"\n{robox} {roboy} {direcao} - Concluído");
        }

        private static void DesenhaDiamante()
        {
            Console.WriteLine("\nVocê achou um diamante!\n");

            char[] diamante = new char[7];

            for (int i = 0; i < 7; i++)
            {
                diamante[i] = ' ';
            }

            int meio = (diamante.Length - 1) / 2;

            int contador = 0;

            for (int i = 0; i < diamante.Length; i++)
            {
                if (i == 0)
                {
                    diamante[meio] = 'x';
                }
                else if (i < meio + 1)
                {
                    diamante[meio + i] = 'x';
                    diamante[meio - i] = 'x';
                }
                else
                {
                    diamante[contador] = ' ';
                    diamante[diamante.Length - 1 - contador] = ' ';
                    contador++;
                }

                foreach (char x in diamante)
                {
                    Console.Write(x);
                }

                Console.WriteLine("");
            }
        }

    }
}