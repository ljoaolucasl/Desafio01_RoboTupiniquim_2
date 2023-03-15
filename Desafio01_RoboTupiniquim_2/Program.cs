namespace Desafio01_RoboTupiniquim_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Robô 1

            int robo1X = 0, robo1Y = 0;
            int areaX = 0, areaY = 0;
            string direcao = "";
            string instrucoesString = "";
            char[] instrucoesChar1 = { };

            Descricoes(1);
            CriaArea(ref areaX, "x");
            CriaArea(ref areaY, "y");

            Descricoes(2);
            PosicaoRobo(ref robo1X, areaX, "x");
            PosicaoRobo(ref robo1Y, areaY, "y");

            Descricoes(3);
            DirecaoRobo(ref direcao);

            Descricoes(4);
            Instrucoes(ref instrucoesString, ref instrucoesChar1);
            Movimentar(ref direcao, ref robo1X, ref robo1Y, areaX, areaY, ref instrucoesChar1);

            //Robô 2

            int robo2X = 0, robo2Y = 0;
            direcao = "";
            instrucoesString = "";
            char[] instrucoesChar2 = { };

            Descricoes(0);

            Descricoes(5);
            PosicaoRobo(ref robo2X, areaX, "x");
            PosicaoRobo(ref robo2Y, areaY, "y");

            Descricoes(3);
            DirecaoRobo(ref direcao);

            Descricoes(4);
            Instrucoes(ref instrucoesString, ref instrucoesChar2);
            Movimentar(ref direcao, ref robo2X, ref robo2Y, areaX, areaY, ref instrucoesChar2);

            Diamante();

            Descricoes(6);

            Console.ReadLine();
        }

        private static void Diamante()
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

        private static void Movimentar(ref string direcao, ref int robox, ref int roboy, int areaX, int areaY, ref char[] instrucoes)
        {
            Console.WriteLine($"\nPosição Inicial: {robox} {roboy} {direcao}\n");

            for (int i = 0; i < instrucoes.Length; i++)
            {
                string descricaoInstrucoes = "";

                if (instrucoes[i] == 'E')
                {
                    switch (direcao)
                    {
                        case "N": direcao = "O"; break;
                        case "L": direcao = "N"; break;
                        case "S": direcao = "L"; break;
                        case "O": direcao = "S"; break;
                    }
                    descricaoInstrucoes = "Virado para esquerda";
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
                    descricaoInstrucoes = "Virado para direita";
                }
                else if (instrucoes[i] == 'M')
                {
                    bool aviso = false;
                    switch (direcao)
                    {
                        case "N": { roboy++; if(roboy > areaY) { roboy--; aviso = true; } break; }
                        case "L": { robox++; if (robox > areaX) { robox--; aviso = true; } break; }
                        case "S": { roboy--; if (roboy < 0) { roboy++; aviso = true; } break; }
                        case "O": { robox--; if (robox < 0) { robox++; aviso = true; } break; }
                    }
                    if(aviso)
                    {
                        descricaoInstrucoes = "Atenção, fique dentro da área limite";
                    }
                    else
                    {
                        descricaoInstrucoes = "Movido para frente";
                    }
                 }
                else
                {
                    descricaoInstrucoes = "Valores inválidos filtrados com sucesso! Aguardando nova instrução";
                }
                Console.WriteLine($"{robox} {roboy} {direcao} - {descricaoInstrucoes}");
            }
            Console.WriteLine($"\n{robox} {roboy} {direcao} - Concluído");
        }

        private static void Instrucoes(ref string instrucoes, ref char[] instrucoeschar)
        {
            bool letrasValidas = true;

            while(true) 
            {
                letrasValidas = true;

                instrucoes = Console.ReadLine().ToUpper();

                if (!string.IsNullOrEmpty(instrucoes) && !string.IsNullOrWhiteSpace(instrucoes)) { }
                if (instrucoes.Contains("E") || instrucoes.Contains("D") || instrucoes.Contains("M")) { }
                else {letrasValidas = false;}

                if (letrasValidas) { break; }
            }
            instrucoeschar = instrucoes.ToCharArray();
        }

        private static void Descricoes(int numero)
        {
            switch (numero)
            {
                case 0:Console.WriteLine("\nO Segundo Robô está esperando por instruções!"); break;

                case 1:Console.WriteLine("Temos dois Robôs Tupiniquins que estão explorando Marte!");
                       Console.WriteLine("Qual é o tamanho da área de procura? (x, y)"); break;

                case 2: Console.WriteLine("\nO Primeiro Robô está em qual posição? (x, y)"); break;

                case 3: Console.WriteLine("\nEle está virado para qual polo? (N, S, L, O)"); break;

                case 4:Console.WriteLine("\nAgora o Robô precisa explorar a área!");
                       Console.WriteLine("Que tal mudar a direção e movimentá-lo agora?");
                       Console.WriteLine("Siga as instruções abaixo: ");

                       Console.WriteLine("\nTecle todos os movimentos em uma mesma linha abaixo:\n");
                       Console.WriteLine("(E) para virar para a esquerda");
                       Console.WriteLine("(D) para virar para a direita");
                       Console.WriteLine("(M) para movimentá-lo para frente\n");
                       Console.Write("Instruções: "); break;

                case 5: Console.WriteLine("\nO Segundo Robô está em qual posição? (x, y)"); break;

                case 6: Console.WriteLine("\nParabéns! Os robôs exploraram as áres indicadas com sucesso!");
                        Console.Write("\nFinalizando Aplicação...\n"); break;
            }
        }

        private static void DirecaoRobo(ref string direcao)
        {
            while (direcao != "N" && direcao != "S" && direcao != "L" && direcao != "O")
            {
                Console.Write($"Polo = ");
                direcao = Console.ReadLine().ToUpper();
            }
        }

        private static void PosicaoRobo(ref int roboxy, int areaxy, string xy)
        {
            bool numero;

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

        }

        private static void CriaArea(ref int area, string xy)
        {
            bool numero;

            do
            {
                Console.Write($"{xy} = ");
                string entrada = Console.ReadLine();

                numero = int.TryParse(entrada, out area);

                if(!numero)
                {
                    Console.WriteLine("Apenas números! Tente novamente.");
                }

            } while (!numero);
        }
    }
}