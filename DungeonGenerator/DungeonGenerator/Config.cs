using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Config
    {
        public static Vetor2 tamanhoMinSala = new Vetor2(6, 6), tamanhoMaxSala = new Vetor2(20, 20),
            tamanhoMaxDungeon = new Vetor2(120, 70), tamanhoMinDungeon = new Vetor2(25, 25), tamanhoMatrizZona = new Vetor2(100, 100);//tamanhoMatrizZona: numerosPares

        public static int numeroMinPortas = 1, numeroMaxPortas = 2, numeroMinEntradas = 1, numeroMaxEntradas = 3, numeroMinSalas = 4, numeroMaxSalas = 20, numeroMinAreas = 4, numeroMaxAreas = 12;
        //coordSalas[i] = coordSala;

        /*
          if (coordAtual.x == coordPortasEntradas[i].x - 1 && coordAtual.y == coordPortasEntradas[i].y)
                    {
                        ligacao = false;
                        Console.WriteLine("mudou de i:" + i);
                    }
                    if (coordAtual.x == coordPortasEntradas[i].x && coordAtual.y == coordPortasEntradas[i].y + 1)
                    {
                        ligacao = false;
                        Console.WriteLine("mudou de i:" + i);
                    }
                    if (coordAtual.x == coordPortasEntradas[i].x && coordAtual.y == coordPortasEntradas[i].y - 1)
                    {
                        ligacao = false;
                        Console.WriteLine("mudou de i:" + i);
                    }
         
        //colisão vertical
            if (direcao == "v")
            {
                if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjcima != null)
                {
                    if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjcima.tipoCelula == "psala" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjcima.tipoCelula == "contornoDungeon" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjcima.tipoCelula == "porta" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjcima.tipoCelula == "entrada")
                    {
                        direcao = "h";

                    }
                }
                if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjbaixo != null)
                {
                    if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjbaixo.tipoCelula == "psala" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjbaixo.tipoCelula == "contornoDungeon" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjbaixo.tipoCelula == "porta" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjbaixo.tipoCelula == "entrada")
                    {
                        direcao = "h";
                      
                    }
                }
            }

            //colisão horizontal
            if (direcao == "h")
            {
                if(dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjesq != null)
                {
                    if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjesq.tipoCelula == "psala" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjesq.tipoCelula == "contornoDungeon" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjesq.tipoCelula == "porta" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjesq.tipoCelula == "entrada")
                    {
                        direcao = "v";
                    }
                }
                if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjdir != null)
                {
                    if (dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjdir.tipoCelula == "psala" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjdir.tipoCelula == "contornoDungeon" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjdir.tipoCelula == "porta" || dungeonInserida.dungeon[coordAtual.x, coordAtual.y].adjdir.tipoCelula == "entrada")
                    {
                        direcao = "v";
                    }
                }
            }
            //Fim de colisoes


         */
    }
}
