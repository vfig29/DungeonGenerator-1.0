using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Sala
    {   //Matriz Sala, com o tamanho
        public Vetor2 tamanhoSala;
        public Celula[,] sala = new Celula[Config.tamanhoMaxSala.x, Config.tamanhoMaxSala.y];
        //Caracteristicas da sala.
        public Vetor2[] coordPortas = new Vetor2[Config.numeroMaxPortas];
        public int numeroPortas;
        public int idSala = 0; // Valor inicial.
        public Vetor2 coordAncoraDungeon;



        public Sala()
        {
            //Instanciando a Randomizacao
            Random tamanho = new System.Random(Guid.NewGuid().GetHashCode());
            // Gerando valores aleatorios de coordenada x e y, para instanciar o vector.
            int x = tamanho.Next(Config.tamanhoMinSala.x, Config.tamanhoMaxSala.x);
            int y = tamanho.Next(Config.tamanhoMinSala.y, Config.tamanhoMaxSala.y);
            Vetor2 tamanhoSala = new Vetor2(x, y);
            Celula[,] sala = new Celula[tamanhoSala.x, tamanhoSala.y];
            this.tamanhoSala = tamanhoSala;
            int numeroPortas = tamanho.Next(Config.numeroMinPortas, Config.numeroMaxPortas);
            this.numeroPortas = numeroPortas;
            idSala = idSala++;
            //Preenchendo a Sala;
            for (int i = 0; i< tamanhoSala.y; i++)
            {
                for (int j = 0; j < tamanhoSala.x; j++)
                {  
                    if (j == 0 || i == 0 || j == (tamanhoSala.x - 1) || i == (tamanhoSala.y - 1))
                    {
                    Vetor2 coordPreenchida = new Vetor2(j, i);
                    Celula celulaPreencheu = new Celula(coordPreenchida, "pSala");
                        //adicionando subtipo*
                        if (j == 0 && i == 0)
                        {
                            celulaPreencheu.subTipoCelula = "quinaEC";

                        }
                        if (j == 0 && i == (tamanhoSala.y - 1))
                        {
                            celulaPreencheu.subTipoCelula = "quinaEB";

                        }
                        if (j == 0 && i != (tamanhoSala.y - 1) && i != 0)
                        {
                            celulaPreencheu.subTipoCelula = "esquerda";

                        }
                        if (j == (tamanhoSala.x - 1) && i == 0)
                        {
                            celulaPreencheu.subTipoCelula = "quinaDC";

                        }
                        if (j == (tamanhoSala.x - 1) && i == (tamanhoSala.y - 1))
                        {
                            celulaPreencheu.subTipoCelula = "quinaDB";

                        }
                        if (j == (tamanhoSala.x - 1) && i != (tamanhoSala.y - 1) && i != 0)
                        {
                            celulaPreencheu.subTipoCelula = "direita";

                        }
                        if (i == 0 && j != 0 && j != (tamanhoSala.x - 1))
                        {
                            celulaPreencheu.subTipoCelula = "cima";

                        }
                        if (i == tamanhoSala.y - 1 && j != 0 && j != (tamanhoSala.x - 1))
                        {
                            celulaPreencheu.subTipoCelula = "baixo";

                        }


                        celulaPreencheu.coordCelulaSala = coordPreenchida;
                    sala[j, i] = celulaPreencheu;
                    }
                    else
                    {
                        Vetor2 coordPreenchida = new Vetor2(j, i);
                        Celula celulaPreencheu = new Celula(coordPreenchida, "chao");
                        celulaPreencheu.coordCelulaSala = coordPreenchida;
                        sala[j, i] = celulaPreencheu;

                    }
                }

            }
            //Adicionando Portas.
            for (int i = 0; i < numeroPortas; i++)
            {
                int xPorta = tamanho.Next(1, tamanhoSala.x - 2);
                int yPorta = tamanho.Next(1, tamanhoSala.y - 2);
                int ladoPorta = tamanho.Next(1, 4);
                Vetor2 coordPreenchida2 = new Vetor2(0, 0);
                switch (ladoPorta)
                {
                    case 1:
                        coordPreenchida2 = new Vetor2(0, yPorta);
                        break;
                    case 2:
                        coordPreenchida2 = new Vetor2(tamanhoSala.x - 1, yPorta);
                        break;
                    case 3:
                         coordPreenchida2 = new Vetor2(xPorta , 0);
                        break;
                    case 4:
                        coordPreenchida2 = new Vetor2(xPorta , tamanhoSala.y - 1);
                        break;
                }

                Celula celulaPreencheu = new Celula(coordPreenchida2, "porta");
                celulaPreencheu.ehPorta = true;
                celulaPreencheu.coordCelulaSala = coordPreenchida2;
                sala[coordPreenchida2.x, coordPreenchida2.y] = celulaPreencheu;
            }

            

            this.sala = sala;
        }
    }
}
