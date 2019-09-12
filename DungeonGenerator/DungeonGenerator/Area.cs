using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Area
    {
        public string tema;
        public Dungeon dungeonInserida;
        public Vetor2[] portas = {null, null, null, null}; //0 - esquerda, 1 - direita, 2 - cima, 3 - baixo.
        public Vetor2[] portasSecretas = { null, null, null, null }; //0 - esquerda, 1 - direita, 2 - cima, 3 - baixo.
        public Vetor2 posicaoMatriz;
        public bool inicial = false, final = false, secreta = false, descoberta = false;
        public bool boss = false;



    public Area(Vetor2 posicaoMatriz)
        {
            this.posicaoMatriz = posicaoMatriz;
            tema = "semtema";
            dungeonInserida = null;

        }
    }
}
