using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
     class Celula
    {
        public string tipoCelula; // parede, chao, pSala, porta, caminho, entrada, entradaSecreta, contornoDungeon; (adicionado entradaSecreta)
        public string subTipoCelula; //esquerda, direita, cima, baixo, quinaEC, quinaEB, quinaDC, quinaDB, centro; *
        public Celula adjdir, adjesq, adjcima, adjbaixo;
        public int idCelula = 0;
        public Vetor2 coordCelulaDun;
        public Vetor2 coordCelulaSala;
        public Dungeon dungeonPai;
        public int idCaminho;
        public bool ehPorta = false;
        public bool ehEntrada = false, ehEntradaSecreta = false;
        public bool spawn = false, subSpawn = false;//subSpawn é a area de seguranca ao redor do player, para monstros não spawnarem muito perto dele, no inicio.
        public bool spawnBoss;//Possivel unir com subtipos caso o portal para o boss ocupe mais de uma celula.
        public bool spawnsbBoss = false, spawnsbPlayer = false;

        public Celula(Vetor2 coordCelulaDun, string tipoCelula)
        { 
            //Pegando a cordenada da celula em questão.
            this.coordCelulaDun = coordCelulaDun;
            //Pegando o tipo da celula em questão.
            this.tipoCelula = tipoCelula;
            idCelula = idCelula++;
            idCaminho = 100;

        }
        public void pegarAdjacentes(Celula celula)
        {
            celula.adjesq = null;
            celula.adjdir = null;
            celula.adjcima = null;
            celula.adjbaixo = null;
            if (celula.coordCelulaDun.x != 0) { celula.adjesq = celula.dungeonPai.dungeon[celula.coordCelulaDun.x - 1, celula.coordCelulaDun.y]; }
            if (celula.coordCelulaDun.x != celula.dungeonPai.tamanhoDungeon.x - 1) { celula.adjdir = celula.dungeonPai.dungeon[celula.coordCelulaDun.x + 1, celula.coordCelulaDun.y]; }
            if (celula.coordCelulaDun.y != 0) { celula.adjcima = celula.dungeonPai.dungeon[celula.coordCelulaDun.x, celula.coordCelulaDun.y - 1]; }
            if (celula.coordCelulaDun.y != celula.dungeonPai.tamanhoDungeon.y - 1) { celula.adjbaixo = celula.dungeonPai.dungeon[celula.coordCelulaDun.x, celula.coordCelulaDun.y + 1]; }
        }
        

    }
}







