using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Grafico
    {
        public static int idGrafico;
        static int margem = 10;


        public Grafico()
        {

        }

        public static void gerarGrafico(Area areaPai)
        {
            Dungeon dungeonInstanciada = areaPai.dungeonInserida;


            for (int i = 0; i < dungeonInstanciada.tamanhoDungeon.x; i++)
            {
                for (int j = 0; j < dungeonInstanciada.tamanhoDungeon.y; j++)
                {
                    Vetor2 v = new Vetor2(0, 0);
                    Celula cel = new Celula(v, "");
                    cel = dungeonInstanciada.dungeon[i, j];
                    Console.SetCursorPosition(cel.coordCelulaDun.x, 6 + cel.coordCelulaDun.y); //Console.SetCursorPosition(i, j);
                    gerarString(cel.tipoCelula, cel.spawn, cel.subSpawn, cel.spawnBoss, cel.spawnsbPlayer, cel.spawnsbBoss);


                }
            }
        }
        public static void gerarString(string tipoCelula, bool spawn, bool subSpawn, bool spawnBoss, bool spawnsbPlayer, bool spawnsbBoss)
        {
            if (tipoCelula == "parede")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("#");
                Console.ResetColor();
            }
            if (tipoCelula == "chao")
            {
                if (spawnBoss == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-");
                    Console.ResetColor();

                }
                else
                {
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            if (tipoCelula == "pSala")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("I");
                Console.ResetColor();
            }
            if (tipoCelula == "porta")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("/");
                Console.ResetColor();
            }
            if (tipoCelula == "caminho")
            {
                if (spawn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("+");
                    Console.ResetColor();
                }
                else if (subSpawn == true && spawn == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".");
                    Console.ResetColor();
                }
                else if (spawn == false && spawnBoss == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-");
                    Console.ResetColor();

                }
                else if (spawnsbPlayer == true && spawn == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".");
                    Console.ResetColor();
                }
                else if (spawn == false && spawnsbBoss == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("-");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(".");
                    Console.ResetColor();
                }
            }
            if (tipoCelula == "entrada")
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("/");
                Console.ResetColor();
            }
            if (tipoCelula == "contornoDungeon")
            {

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("I");
                Console.ResetColor();
            }
            if (tipoCelula == "entradaSecreta")
            {

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("T");
                Console.ResetColor();
            }

        }
        public static Dungeon gerarDungeon(Area areaPai)
        {
            bool errorFiltro = true;
            //Inicializando Dungeon
            Dungeon dungeonInstanciada = new Dungeon(areaPai);
            while (errorFiltro || dungeonInstanciada.errorCaminho)
            {
                //Console.WriteLine("novo ciclo");
                //Console.WriteLine("criando a dungeon...");
                dungeonInstanciada = new Dungeon(areaPai);
                //Console.WriteLine("inserindo dungeonpai...");
                dungeonInstanciada.inserirDungeonPai(dungeonInstanciada);
                //Console.WriteLine("criando super salas...");
                dungeonInstanciada.superSalas(dungeonInstanciada);
                //Console.WriteLine("inserindo caminhos");
                dungeonInstanciada.InserirCaminhos(dungeonInstanciada);
                //Console.WriteLine("debugando pos caminhos");
                dungeonInstanciada.DebugPosCaminho(dungeonInstanciada);
                //Console.WriteLine("reestabelecendo coords");
                Dungeon.ReestabelecerCoords(dungeonInstanciada); // Para recuperar as coordenadas perdidas.
                //Console.WriteLine("filtrando a dungeon");
                errorFiltro = dungeonInstanciada.FiltroCaminho(dungeonInstanciada);
                //Console.WriteLine("inserindo subtipos");
                dungeonInstanciada.InserirSubtipos(dungeonInstanciada);
                //Console.WriteLine("fim do ciclo");
                //Fim da inicialização.
            }
            //fora do while: acabamentos finais, que dependem de uma dungeon perfeita.
            dungeonInstanciada.AdicionarPlayerSpawn(areaPai, dungeonInstanciada);
            dungeonInstanciada.AdicionarBossSpawn(areaPai, dungeonInstanciada);
            //Console.WriteLine("dungeonCriada");
            return dungeonInstanciada;
        }

    static public void GraficoZona(Zona zonaInserida, Area areaAtual)
        {
            for (int i = 0; i < Config.tamanhoMatrizZona.x; i++)
            {
                for (int j = 0; j < Config.tamanhoMatrizZona.y; j++)
                {
                    if (zonaInserida.zona[i, j] != null)
                    {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + i + 15, j - 35);
                        if (zonaInserida.zona[i, j] == areaAtual)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else if(zonaInserida.zona[i, j].inicial == true && zonaInserida.zona[i, j] != areaAtual)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("+");
                            Console.ResetColor();
                        }
                        else if (zonaInserida.zona[i, j].final == true && zonaInserida.zona[i, j] != areaAtual)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("-");
                            Console.ResetColor();
                        }
                        else if (zonaInserida.zona[i, j].secreta == true)
                        {
                            if (zonaInserida.zona[i, j].descoberta == false)
                            {
                                Console.Write(" ");
                                Console.ResetColor();

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("x");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("#");
                            Console.ResetColor();
                        }
                        
                    }
                }
            }

        }
        //
        public void TelaDeExibicao(Zona zonaInserida)
        {
                    Area areaAtual = zonaInserida.zona[zonaInserida.areaInicial.x, zonaInserida.areaInicial.y];
                    bool mudancaDeArea;
                    bool dentroDaFuncao = true;
                    while(dentroDaFuncao == true)
                    {
                    mudancaDeArea = true;
                    if (areaAtual != null)
                    {
                        Console.Clear();
                        //Console.WriteLine("Area:" + zonaInserida.zona[i, j].posicaoMatriz.x + " / " + zonaInserida.zona[i, j].posicaoMatriz.y);
                        //Console.ReadLine();
                        gerarGrafico(areaAtual);
                        Grafico.GraficoZona(zonaInserida, areaAtual);
                        Ascii.Info(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 6);
                        Console.Write("Numero de areas criadas: " + zonaInserida.numeroDeAreas + ".");
                        if(zonaInserida.numeroDeAreasSecretas > 0)
                        {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 8);
                        Console.WriteLine("Está zona possui " + zonaInserida.numeroDeAreasSecretas  + " áreas secretas.");
                        }
                        if(areaAtual.inicial == true)
                        {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 7);
                        Console.WriteLine("Status: Esta é uma area inicial.");
                        }
                        else if(areaAtual.secreta == true && areaAtual.inicial == false)
                        {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 7);
                        Console.WriteLine("Status: Esta é uma área secreta!");
                        areaAtual.descoberta = true;
                        }
                        else if (areaAtual.final == true && areaAtual.inicial == false)
                        {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 7);
                        Console.WriteLine("Status: Esta é uma área de Boss!");
                        }
                        else
                        {
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 7);
                        Console.WriteLine("Status: Esta é uma área comum.");
                        }
                        Ascii.Mapa(areaAtual.dungeonInserida.tamanhoDungeon.x + 50, 1);
                        Ascii.Instrucoes(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 23);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 28);
                        Console.WriteLine("> Mova-se pela Zona usando os direcionais! ou W, A, S, D.");
                        Ascii.setas(areaAtual.dungeonInserida.tamanhoDungeon.x + 30, 30);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 29);
                        Console.Write("> Legenda(Mapa):");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 30);
                        Console.Write("'#' -> Area Comum.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 31);
                        Console.Write("'+' -> Area Inicial.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 32);
                        Console.Write("'-' -> Area de Boss.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 33);
                        Console.Write("' ' -> Area Secreta.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 34);
                        Console.Write("'O' -> Sua posicao.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 35);
                        Console.Write("'x' -> Area Secreta Descoberta.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 37);
                        Console.Write("> Legenda(Area):");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 38);
                        Console.Write("'#' -> Obstaculos.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 39);
                        Console.Write("'I' -> Paredes.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 40);
                        Console.Write("'.' -> Chao comum.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 41);
                        Console.Write("' ' -> Chao de Salas.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 42);
                        Console.Write("'T' -> Parede Danificada.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 43);
                        Console.Write("'/' -> Portas.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 44);
                        Console.Write("'..+..' -> Area de Spawn do Player.");
                        Console.SetCursorPosition(areaAtual.dungeonInserida.tamanhoDungeon.x + 2, 45);
                        Console.Write("'-----' -> Area de Spawn do Boss.");
                        Ascii.Area(0, 0);
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 0);
                }

                    while (mudancaDeArea == true)
                    {
                        switch (Program.PegarTecla())
                        {
                            case 1:
                                if (zonaInserida.zona[areaAtual.posicaoMatriz.x + 1, areaAtual.posicaoMatriz.y] != null)
                                {
                                    areaAtual = zonaInserida.zona[areaAtual.posicaoMatriz.x + 1, areaAtual.posicaoMatriz.y];
                                    mudancaDeArea = false;
                                }
                                break;
                            case 2:
                                if (zonaInserida.zona[areaAtual.posicaoMatriz.x - 1, areaAtual.posicaoMatriz.y] != null)
                                {
                                    areaAtual = zonaInserida.zona[areaAtual.posicaoMatriz.x - 1, areaAtual.posicaoMatriz.y];
                                    mudancaDeArea = false;
                                }
                                break;
                            case 3:
                                if (zonaInserida.zona[areaAtual.posicaoMatriz.x, areaAtual.posicaoMatriz.y - 1] != null)
                                {
                                    areaAtual = zonaInserida.zona[areaAtual.posicaoMatriz.x, areaAtual.posicaoMatriz.y - 1];
                                    mudancaDeArea = false;
                                }
                                break;
                            case 4:
                                if (zonaInserida.zona[areaAtual.posicaoMatriz.x, areaAtual.posicaoMatriz.y + 1] != null)
                                {
                                    areaAtual = zonaInserida.zona[areaAtual.posicaoMatriz.x, areaAtual.posicaoMatriz.y + 1];
                                    mudancaDeArea = false;
                                }
                                break;
                            case 5:
                                dentroDaFuncao = false;
                                mudancaDeArea = false;
                                Console.SetCursorPosition(120, 120);
                                break;
                        }

                    }
            }
        }

        public static void DivisaoDaTela(Zona zonaInserida)//inativa
        {
            Area areaAtual = zonaInserida.zona[zonaInserida.areaInicial.x, zonaInserida.areaInicial.y];

            for (int i = -1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x - (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas); i <= 1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x + (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas); i++)
            {
                Console.SetCursorPosition(i, areaAtual.posicaoMatriz.y + zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas + 1);
                Console.Write("::");
            }
            for (int i = -1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x - (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas); i <= 1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x + (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas); i++)
            {
                Console.SetCursorPosition(i, areaAtual.posicaoMatriz.y - zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas - 1);
                Console.Write("::");
            }
            for (int i = areaAtual.posicaoMatriz.y - zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas - 1; i <= areaAtual.posicaoMatriz.y + zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas + 1; i++)
            {
                Console.SetCursorPosition(-1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x - (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas), i);
                Console.Write("::");
            }
            for (int i = areaAtual.posicaoMatriz.y - zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas - 1; i <= areaAtual.posicaoMatriz.y + zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas + 1; i++)
            {
                Console.SetCursorPosition(1 + areaAtual.dungeonInserida.tamanhoDungeon.x + areaAtual.posicaoMatriz.x + (zonaInserida.numeroDeAreas + zonaInserida.numeroDeAreasSecretas), i);
                Console.Write("::");
            }




        }
    }
}
