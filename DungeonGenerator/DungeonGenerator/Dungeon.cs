using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Dungeon
    {
        public Vetor2 tamanhoDungeon;
        public Vetor2 coordEntradas;
        public Vetor2[] coordSalas = new Vetor2[Config.numeroMaxSalas];
        public Celula[,] dungeon = new Celula[Config.tamanhoMaxDungeon.x, Config.tamanhoMaxDungeon.y];
        public int idDungeon = 0;
        public int numeroSalas;
        public int numeroEntradas;
        public bool terminarCaminho;
        public bool terminarPivot;
        public bool errorCaminho = false;



        public Dungeon(Area areaPai)
        {
            //Instanciando a Randomizacao
            Random tamanho = new System.Random(Guid.NewGuid().GetHashCode());
            // Gerando valores aleatorios de coordenada x e y, para instanciar o vector.
            int x = tamanho.Next(Config.tamanhoMinDungeon.x, Config.tamanhoMaxDungeon.x);
            int y = tamanho.Next(Config.tamanhoMinDungeon.y, Config.tamanhoMaxDungeon.y);
            Vetor2 tamanhoDungeon = new Vetor2(x, y);
            Celula[,] dungeon = new Celula[tamanhoDungeon.x, tamanhoDungeon.y];
            this.tamanhoDungeon = tamanhoDungeon;
            int numeroEntradas = tamanho.Next(Config.numeroMinEntradas, Config.numeroMaxEntradas);
            this.numeroEntradas = numeroEntradas;
            idDungeon++;
            //Preenchendo a Dungeon.
            for (int i = 0; i < tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < tamanhoDungeon.x; j++)
                {
                    if (j == 0 || i == 0 || j == (tamanhoDungeon.x - 1) || i == (tamanhoDungeon.y - 1))
                    {
                        Vetor2 coordPreenchida = new Vetor2(j, i);
                        Celula celulaPreencheu = new Celula(coordPreenchida, "contornoDungeon");
                        dungeon[j, i] = celulaPreencheu;
                    }
                    else
                    {
                        Vetor2 coordPreenchida = new Vetor2(j, i);
                        Celula celulaPreencheu = new Celula(coordPreenchida, "parede");
                        dungeon[j, i] = celulaPreencheu;
                    }
                }

            }
            //Alocando Salas;
            int numeroSalas = tamanho.Next(Config.numeroMinSalas, Config.numeroMaxSalas);
            this.numeroSalas = numeroSalas;
            for (int i = 0; i < numeroSalas; i++)
            {
                Sala salaInstanciada = new Sala();
                int xSala = tamanho.Next(2, tamanhoDungeon.x - salaInstanciada.tamanhoSala.x - 2);
                int ySala = tamanho.Next(2, tamanhoDungeon.y - salaInstanciada.tamanhoSala.y - 2);
                Vetor2 coordSala = new Vetor2(xSala, ySala);
                salaInstanciada.coordAncoraDungeon = coordSala;
                //Checando se já possui alguma sala nas celulas randomizadas.
                bool checkOk = true; // 2 - Pode fazer a dungeon. false - Não pode fazer a dungeon.
                for (int j = 0; j < salaInstanciada.tamanhoSala.y; j++)
                {
                    for (int k = 0; k < salaInstanciada.tamanhoSala.x; k++)
                    {

                        if ((dungeon[(coordSala.x + k), (coordSala.y + j)].tipoCelula) != "parede") // ou se os adjacentes da celula sejam porta(importante implementar em caso de erro).
                        {
                            checkOk = false;
                        }



                    }


                }
                //Após, a checar. Caso o check seja true, pode fazer a sala.
                if (checkOk == true)
                {
                    for (int j = 0; j < salaInstanciada.tamanhoSala.y; j++)
                    {
                        for (int k = 0; k < salaInstanciada.tamanhoSala.x; k++)
                        {
                            dungeon[coordSala.x + k, coordSala.y + j] = salaInstanciada.sala[k, j];
                            Vetor2 novaCoord = new Vetor2(coordSala.x + k, coordSala.y + j);
                            dungeon[coordSala.x + k, coordSala.y + j].coordCelulaDun = novaCoord;

                        }


                    }

                }
            }

            //Adicionando Entradas;
            for (int i = 0; i < 4; i++)
            {
                if (areaPai.portas[i] != null)
                {
                    int xEntrada = tamanho.Next(1, tamanhoDungeon.x - 2);
                    int yEntrada = tamanho.Next(1, tamanhoDungeon.y - 2);
                    Vetor2 coordPreenchida2 = new Vetor2(0, 0);
                    switch (i)
                    {
                        case 0:
                            //esquerda
                            coordPreenchida2 = new Vetor2(0, yEntrada);
                            break;
                        case 1:
                            //direita
                            coordPreenchida2 = new Vetor2(tamanhoDungeon.x - 1, yEntrada);
                            break;
                        case 2:
                            //cima
                            coordPreenchida2 = new Vetor2(xEntrada, 0);
                            break;
                        case 3:
                            //baixo
                            coordPreenchida2 = new Vetor2(xEntrada, tamanhoDungeon.y - 1);
                            break;
                    }

                    Celula celulaPreencheu = new Celula(coordPreenchida2, "entrada");
                    celulaPreencheu.ehEntrada = true;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y] = celulaPreencheu;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y].coordCelulaDun.x = coordPreenchida2.x;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y].coordCelulaDun.y = coordPreenchida2.y;
                }
            }

            //Adicionando Entradas Secretas;
            for (int i = 0; i < 4; i++)
            {
                if (areaPai.portasSecretas[i] != null)
                {
                    int xEntrada = tamanho.Next(1, tamanhoDungeon.x - 2);
                    int yEntrada = tamanho.Next(1, tamanhoDungeon.y - 2);
                    Vetor2 coordPreenchida2 = new Vetor2(0, 0);
                    switch (i)
                    {
                        case 0:
                            //esquerda
                            coordPreenchida2 = new Vetor2(0, yEntrada);
                            break;
                        case 1:
                            //direita
                            coordPreenchida2 = new Vetor2(tamanhoDungeon.x - 1, yEntrada);
                            break;
                        case 2:
                            //cima
                            coordPreenchida2 = new Vetor2(xEntrada, 0);
                            break;
                        case 3:
                            //baixo
                            coordPreenchida2 = new Vetor2(xEntrada, tamanhoDungeon.y - 1);
                            break;
                    }

                    Celula celulaPreencheu = new Celula(coordPreenchida2, "entradaSecreta");
                    celulaPreencheu.ehEntradaSecreta = true;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y] = celulaPreencheu;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y].coordCelulaDun.x = coordPreenchida2.x;
                    dungeon[coordPreenchida2.x, coordPreenchida2.y].coordCelulaDun.y = coordPreenchida2.y;
                }
            }


            this.dungeon = dungeon;
        }

        public void superSalas(Dungeon dungeonInserida)
        {
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.x; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.y; j++)
                {
                    if (dungeonInserida.dungeon[i, j].tipoCelula == "pSala" || dungeonInserida.dungeon[i, j].tipoCelula == "porta")
                    {
                        dungeonInserida.dungeon[i, j].pegarAdjacentes(dungeonInserida.dungeon[i, j]);
                        if (dungeonInserida.dungeon[i, j].adjcima != null && dungeonInserida.dungeon[i, j].adjbaixo != null && dungeonInserida.dungeon[i, j].adjesq != null && dungeonInserida.dungeon[i, j].adjdir != null)
                        {
                            if (dungeonInserida.dungeon[i, j].adjcima.tipoCelula != "parede" && dungeonInserida.dungeon[i, j].adjbaixo.tipoCelula != "parede" && dungeonInserida.dungeon[i, j].adjesq.tipoCelula != "parede" && dungeonInserida.dungeon[i, j].adjdir.tipoCelula != "parede" && dungeonInserida.dungeon[i, j].adjcima.tipoCelula != "contornoDungeon" && dungeonInserida.dungeon[i, j].adjbaixo.tipoCelula != "contornoDungeon" && dungeonInserida.dungeon[i, j].adjesq.tipoCelula != "contornoDungeon" && dungeonInserida.dungeon[i, j].adjdir.tipoCelula != "contornoDungeon")
                            {
                                if (dungeonInserida.dungeon[i, j].adjcima.tipoCelula == "pSala" || dungeonInserida.dungeon[i, j].adjbaixo.tipoCelula == "pSala" || dungeonInserida.dungeon[i, j].adjesq.tipoCelula == "pSala" || dungeonInserida.dungeon[i, j].adjdir.tipoCelula == "pSala")
                                {
                                    dungeonInserida.dungeon[i, j].tipoCelula = "chao";
                                    dungeonInserida.dungeon[i, j].ehPorta = false;
                                }

                            }
                        }
                    }

                }
            }
        }
        public void InserirCaminhos(Dungeon dungeonInserida)
        {
            int contadorErrorCaminho = 0;
            //Declarando Vetor que armazena as coordenadas das portas e entradas.
            Vetor2[] coordPortasEntradas = new Vetor2[dungeonInserida.numeroEntradas + (Config.numeroMaxPortas * dungeonInserida.numeroSalas)];
            int contadorCoord = 0;
            //Varrendo a dungeon e armazenando as coordenadas das portas e entradas dentro do vetor.
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                {
                    if (dungeonInserida.dungeon[j, i].tipoCelula == "porta" || dungeonInserida.dungeon[j, i].tipoCelula == "entrada")
                    {
                        dungeonInserida.dungeon[j, i].pegarAdjacentes(dungeonInserida.dungeon[j, i]);
                        if (dungeonInserida.dungeon[j, i].adjbaixo != null && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            coordPortasEntradas[contadorCoord] = dungeonInserida.dungeon[j, i].adjbaixo.coordCelulaDun;
                            contadorCoord++;
                        }
                        if (dungeonInserida.dungeon[j, i].adjcima != null && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede")
                        {
                            
                            coordPortasEntradas[contadorCoord] = dungeonInserida.dungeon[j, i].adjcima.coordCelulaDun;
                            contadorCoord++;
                        }
                        if (dungeonInserida.dungeon[j, i].adjdir != null && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede")
                        {
                            
                            coordPortasEntradas[contadorCoord] = dungeonInserida.dungeon[j, i].adjdir.coordCelulaDun;
                            contadorCoord++;
                        }
                        if (dungeonInserida.dungeon[j, i].adjesq != null && dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede")
                        {
                            
                            coordPortasEntradas[contadorCoord] = dungeonInserida.dungeon[j, i].adjesq.coordCelulaDun;
                            contadorCoord++;
                        }

                    }
                }

            }
            //Fim da Varredura.
            //Randomizando uma coordenada de partida para criação dos caminhos da dungeon.
            dungeonInserida.terminarCaminho = true;
            while (dungeonInserida.terminarCaminho)
            {
                dungeonInserida.CriarCaminho(dungeonInserida, coordPortasEntradas, contadorCoord, contadorErrorCaminho);
                contadorErrorCaminho++;
                if (contadorErrorCaminho >= 9999999)
                {
                    //Console.WriteLine("ERROR REFAZENDO DUNGEON primeiro");
                    dungeonInserida.errorCaminho = true;
                    break;


                }


            }
            
            PivotCaminho(dungeonInserida, contadorCoord);

            




            int contadorDebug;
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.x; i++)
            {
                contadorDebug = 0;
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.y; j++)
                {
                    contadorDebug = 0;
                    if (dungeonInserida.dungeon[i, j].tipoCelula == "parede")
                    {
                        dungeonInserida.dungeon[i, j].pegarAdjacentes(dungeonInserida.dungeon[i, j]);
                        if (dungeonInserida.dungeon[i, j].adjcima != null && dungeonInserida.dungeon[i, j].adjbaixo != null && dungeonInserida.dungeon[i, j].adjesq != null && dungeonInserida.dungeon[i, j].adjdir != null)
                        {
                            if (dungeonInserida.dungeon[i, j].adjcima.tipoCelula == "caminho") { contadorDebug++; }
                            if (dungeonInserida.dungeon[i, j].adjbaixo.tipoCelula == "caminho") { contadorDebug++; }
                            if (dungeonInserida.dungeon[i, j].adjesq.tipoCelula == "caminho") { contadorDebug++; }
                            if (dungeonInserida.dungeon[i, j].adjdir.tipoCelula == "caminho") { contadorDebug++; }
                            if (contadorDebug >= 3) { dungeonInserida.dungeon[i, j].tipoCelula = "caminho"; }
                        }
                    }

                }
            }
            
        }

        public void CriarCaminho(Dungeon dungeonInserida, Vetor2[] coordPartida, int contadorCoord, int contadorErrorCaminho)
        {
            Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
            int condicaoCompleta = 0;
            for (int i = 0; i < contadorCoord; i++)
            {
                if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].idCaminho == 100 || dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].idCaminho == i)
                {
                    dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].pegarAdjacentes(dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y]);
                    int direcao = rnd.Next(1, 100);
                    dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].tipoCelula = "caminho";
                    dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].idCaminho = i;
                    if (direcao > 1 && direcao <= 25)//cima
                    {

                        if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjcima != null)
                        {
                            if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjcima.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjcima.tipoCelula == "caminho")
                            {
                                //coordPartida[i].x = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjcima.coordCelulaDun.x;
                                coordPartida[i].y = coordPartida[i].y - 1;

                            }

                        }
                    }
                    if (direcao > 25 && direcao <= 50)//baixo
                    {
                        if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjbaixo != null)
                        {
                            if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjbaixo.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjbaixo.tipoCelula == "caminho")
                            {
                                //coordPartida[i].x = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjbaixo.coordCelulaDun.x;
                                coordPartida[i].y = coordPartida[i].y + 1;

                            }

                        }
                    }
                    if (direcao > 50 && direcao <= 75)//esquerda
                    {
                        if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq != null)
                        {
                            if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq.tipoCelula == "caminho")
                            {
                                if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq.coordCelulaDun != null)
                                {
                                    coordPartida[i].x = coordPartida[i].x - 1;
                                    //coordPartida[i].y = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq.coordCelulaDun.y;
                                }


                            }
                        }
                    }
                    if (direcao > 75 && direcao <= 100)//direita
                    {
                        if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjdir != null)
                        {
                            if (dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjdir.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjdir.tipoCelula == "caminho")
                            {
                                coordPartida[i].x = coordPartida[i].x + 1;
                                //coordPartida[i].y = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjdir.coordCelulaDun.y;
                            }
                        }
                    }
                }
                else
                {
                    condicaoCompleta++;
                    if (condicaoCompleta == contadorCoord - 1) {  dungeonInserida.terminarCaminho = false; }// original: condicaoCompleta == contadorCoord - 1
                }
            }
            if (contadorErrorCaminho >= 9999999)
            {
                //Console.WriteLine("ERROR REFAZENDO DUNGEON primeiro");
                dungeonInserida.errorCaminho = true;
                return ;
            }

        }

        public void PivotCaminho(Dungeon dungeonInserida, int contadorCoord)
        {
            int contadorErroCaminho = 0;
            bool geracaoCoord = true;
            Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
            Vetor2 coordPartida = new Vetor2(0, 0);
            //gerando coordenada inicial.
            while (geracaoCoord)
            {
                coordPartida.x = rnd.Next(1, dungeonInserida.tamanhoDungeon.x - 2);
                coordPartida.y = rnd.Next(1, dungeonInserida.tamanhoDungeon.y - 2);
                if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida.x, coordPartida.y].tipoCelula == "caminho")
                {
                    geracaoCoord = false;
                }

            }
            //preence o vetor com todas as possibilidades de id.
            int[] todasIds = new int[contadorCoord];
            for (int i = 0; i < contadorCoord; i++)
            {
                todasIds[i] = i;
            }
            //Constroi o caminho pivot-----------------------------

            int direcao;
            dungeonInserida.terminarPivot = true;
            while (dungeonInserida.terminarPivot)
            {
                int condicaoCompleta = 0;
                dungeonInserida.dungeon[coordPartida.x, coordPartida.y].pegarAdjacentes(dungeonInserida.dungeon[coordPartida.x, coordPartida.y]);
                direcao = rnd.Next(1, 100);
                dungeonInserida.dungeon[coordPartida.x, coordPartida.y].tipoCelula = "caminho";
                for (int i = 0; i < contadorCoord; i++)
                {
                    if (todasIds[i] == dungeonInserida.dungeon[coordPartida.x, coordPartida.y].idCaminho)
                    {
                        todasIds[i] = 200;
                    }
                }
                if (direcao > 1 && direcao <= 25)//cima
                {

                    if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjcima != null)
                    {
                        if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjcima.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjcima.tipoCelula == "caminho")
                        {
                            //coordPartida[i].x = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjcima.coordCelulaDun.x;
                            coordPartida.y = coordPartida.y - 1;

                        }

                    }
                }
                if (direcao > 25 && direcao <= 50)//baixo
                {
                    if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjbaixo != null)
                    {
                        if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjbaixo.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjbaixo.tipoCelula == "caminho")
                        {
                            //coordPartida[i].x = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjbaixo.coordCelulaDun.x;
                            coordPartida.y = coordPartida.y + 1;

                        }

                    }
                }
                if (direcao > 50 && direcao <= 75)//esquerda
                {
                    if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjesq != null)
                    {
                        if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjesq.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjesq.tipoCelula == "caminho")
                        {
                            if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjesq.coordCelulaDun != null)
                            {
                                coordPartida.x = coordPartida.x - 1;
                                //coordPartida[i].y = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjesq.coordCelulaDun.y;
                            }


                        }
                    }
                }
                if (direcao > 75 && direcao <= 100)//direita
                {
                    if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjdir != null)
                    {
                        if (dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjdir.tipoCelula == "parede" || dungeonInserida.dungeon[coordPartida.x, coordPartida.y].adjdir.tipoCelula == "caminho")
                        {
                            coordPartida.x = coordPartida.x + 1;
                            //coordPartida[i].y = dungeonInserida.dungeon[coordPartida[i].x, coordPartida[i].y].adjdir.coordCelulaDun.y;
                        }
                    }
                }




                //checando se já se passou por todas as ids possiveis.
                for (int i = 0; i < contadorCoord; i++)
                {
                    if (todasIds[i] == 200)
                    {
                        condicaoCompleta++;
                        if (condicaoCompleta >= contadorCoord) { dungeonInserida.terminarPivot = false; }//original: condicaoCompleta >= contadorCoord - 1 (testando se a formula atual remove o bug de uma das salas n se conectar c as outras)
                        else { contadorErroCaminho++; }
                    }
                }
                //DEBUG LOOP INFINITO(CONDICAO NUNCA ATENDIDA)
                if (contadorErroCaminho >= 9999999)
                {
                    //Console.WriteLine("ERROR REFAZENDO DUNGEON");
                    dungeonInserida.errorCaminho = true;
                    break;
                    

                }
            }
        }
        public void inserirDungeonPai(Dungeon dungeonInserida)
        {
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                {
                    dungeonInserida.dungeon[j, i].dungeonPai = dungeonInserida;
                }

            }
        }

        public void DebugPosCaminho(Dungeon dungeonInserida)
        {
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                {
                    if (dungeonInserida.dungeon[j, i].ehPorta == true)
                    {
                        dungeonInserida.dungeon[j, i].tipoCelula = "porta";
                    }
                    if (dungeonInserida.dungeon[j, i].ehEntrada == true)
                    {
                        dungeonInserida.dungeon[j, i].tipoCelula = "entrada";
                    }
                    if (dungeonInserida.dungeon[j, i].ehEntradaSecreta == true)
                    {
                        dungeonInserida.dungeon[j, i].tipoCelula = "entradaSecreta";
                    }
                }

            }
            //



        }
    public static void ReestabelecerCoords(Dungeon dungeonInserida)
        {
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                {
                    dungeonInserida.dungeon[j, i].coordCelulaDun.x = j;
                    dungeonInserida.dungeon[j, i].coordCelulaDun.y = i;
                }

            }

        }

    public bool FiltroCaminho(Dungeon dungeonInserida)
        {
            int contadorCaminho = 0;
            int areaDungeon = (dungeonInserida.tamanhoDungeon.y - 2) * (dungeonInserida.tamanhoDungeon.x - 2);
            for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
            {
                for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                {
                    if(dungeonInserida.dungeon[j, i].tipoCelula == "caminho")
                    {
                        contadorCaminho++;
                    }
                }

            }

            if(contadorCaminho > (areaDungeon * 45 / 100))
            {
                for (int i = 0; i < dungeonInserida.tamanhoDungeon.y; i++)
                {
                    for (int j = 0; j < dungeonInserida.tamanhoDungeon.x; j++)
                    {
                        if (dungeonInserida.dungeon[j, i].tipoCelula == "caminho")
                        {
                            dungeonInserida.dungeon[j, i].tipoCelula = "parede";
                        }
                    }

                }
                return true;
            }
            return false;
        }

        public void InserirSubtipos(Dungeon dungeonInserida)//Esperando as sprites
        {
            for (int i = 1; i < dungeonInserida.tamanhoDungeon.y - 1; i++)
            {
                for (int j = 1; j < dungeonInserida.tamanhoDungeon.x - 1; j++)
                {
                    dungeonInserida.dungeon[j, i].pegarAdjacentes(dungeonInserida.dungeon[j, i]);
                    //SUBTIPOS DA PAREDE:
                    if (dungeonInserida.dungeon[j, i].tipoCelula == "parede")
                    {
                        //subtipo esquerda:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "esquerda";
                        }
                        //subtipo direita:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "direita";
                        }
                        //subtipo cima:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "cima";
                        }
                        //subtipo baixo:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula != "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "baixo";
                        }
                        //subtipo quinaEC:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "quinaEC";
                        }
                        //subtipo quinaEB:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula != "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "quinaEB";
                        }
                        //subtipo quinaDC:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "quinaDC";
                        }
                        //subtipo quinaDB:
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula != "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula != "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "quinaDB";
                        }
                        //subtipo centro
                        if (dungeonInserida.dungeon[j, i].adjesq.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjdir.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjcima.tipoCelula == "parede" && dungeonInserida.dungeon[j, i].adjbaixo.tipoCelula == "parede")
                        {
                            dungeonInserida.dungeon[j, i].subTipoCelula = "centro";
                        }

                    }

                }

            }

        }
        //
        public void AdicionarPlayerSpawn(Area areaPai, Dungeon dungeonInserida)
        {
            if (areaPai.inicial == true)
            {
                bool loop = true;
                Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
                while (loop == true)
                {
                    int coordSpawnx = rnd.Next(1, dungeonInserida.tamanhoDungeon.x - 1);
                    int coordSpawny = rnd.Next(1, dungeonInserida.tamanhoDungeon.y - 1);

                    if (dungeonInserida.dungeon[coordSpawnx, coordSpawny].tipoCelula == "caminho")
                    {
                        dungeonInserida.dungeon[coordSpawnx, coordSpawny].spawn = true;
                        for (int i = coordSpawnx - 2; i <= coordSpawnx + 2; i++)
                        {
                            for (int j = coordSpawny - 2; j <= coordSpawny + 2; j++)
                            {
                                if (i != coordSpawnx || j != coordSpawny)
                                {
                                    if (i > 0 && j > 0 && i < dungeonInserida.tamanhoDungeon.x - 1 && j < dungeonInserida.tamanhoDungeon.y - 1 && dungeonInserida.dungeon[i, j].tipoCelula == "caminho")
                                    {
                                        dungeonInserida.dungeon[i, j].subSpawn = true;
                                    }
                                }
                            }

                        }
                        loop = false;
                    }
                    else
                    {
                        loop = true;
                    }

                }


            }
        }
        //
        public void AdicionarBossSpawn(Area areaPai, Dungeon dungeonInserida)
        {
            if (areaPai.final == true)
            {
                bool permit;
                bool loop = true;
                Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
                while (loop == true)
                {
                    permit = true;
                    int coordSpawnx = rnd.Next(1, dungeonInserida.tamanhoDungeon.x - 1);
                    int coordSpawny = rnd.Next(1, dungeonInserida.tamanhoDungeon.y - 1);

                    if (dungeonInserida.dungeon[coordSpawnx, coordSpawny].tipoCelula == "caminho" || dungeonInserida.dungeon[coordSpawnx, coordSpawny].tipoCelula == "chao")
                    {
                        for (int i = coordSpawnx - 2; i <= coordSpawnx + 2; i++)
                        {
                            for (int j = coordSpawny - 2; j <= coordSpawny + 2; j++)
                            {
                                if (i != coordSpawnx || j != coordSpawny)
                                {
                                    if (i < 0 || j < 0 || i > dungeonInserida.tamanhoDungeon.x - 1 || j > dungeonInserida.tamanhoDungeon.y - 1 || (dungeonInserida.dungeon[i, j].tipoCelula != "chao" && dungeonInserida.dungeon[i, j].tipoCelula != "caminho"))
                                    {
                                        permit = false;
                                    }
                                }
                            }

                        }

                        if (permit == true)
                        {
                            for (int i = coordSpawnx - 1; i <= coordSpawnx + 1; i++)
                        {
                            for (int j = coordSpawny - 1; j <= coordSpawny + 1; j++)
                            {
                                    if (i > 0 && j > 0 && i < dungeonInserida.tamanhoDungeon.x - 1 && j < dungeonInserida.tamanhoDungeon.y - 1)
                                    {
                                        dungeonInserida.dungeon[i, j].spawnBoss = true;
                                    }  
                            }

                        }
                            dungeonInserida.dungeon[coordSpawnx, coordSpawny].spawnBoss = true;
                            loop = false;
                        }
                    }
                    else
                    {
                        loop = true;
                    }

                }


            }
        }

    }
}
