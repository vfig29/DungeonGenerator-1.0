using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DungeonGenerator
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleConfig.ChangeFont();
            Ascii.TelaInicial();
            Grafico terminal = new Grafico();
            //terminal.gerarGrafico();
            Zona zonaCriada = new Zona();
            Console.SetCursorPosition(50, 17);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("*** Zona Criada, aperte enter para exibir as areas na tela!!! ***");
            Console.ResetColor();
            Console.ReadLine();
            terminal.TelaDeExibicao(zonaCriada);
            Console.Clear();
            Grafico.gerarGrafico(zonaCriada.bossArea);
            Console.ReadLine();


        }
        
        public static int PegarTecla()
        {
            int idTecla = 0;
            bool loop = true;
            while (loop == true)
            {
                ConsoleKeyInfo teclaApertada = Console.ReadKey(true);
                if (teclaApertada.Key.ToString() == "RightArrow" || teclaApertada.Key.ToString() == "D")
                {
                    idTecla = 1;
                    loop = false;
                }
                if (teclaApertada.Key.ToString() == "LeftArrow" || teclaApertada.Key.ToString() == "A")
                {
                    idTecla = 2;
                    loop = false;
                }
                if (teclaApertada.Key.ToString() == "UpArrow" || teclaApertada.Key.ToString() == "W")
                {
                    idTecla = 3;
                    loop = false;
                }
                if (teclaApertada.Key.ToString() == "DownArrow" || teclaApertada.Key.ToString() == "S")
                {
                    idTecla = 4;
                    loop = false;
                }
                if (teclaApertada.Key.ToString() == "Escape")//|| teclaApertada.Key.ToString() == "Enter" || teclaApertada.Key.ToString() == "Space"
                {
                    idTecla = 5;
                    loop = false;
                }
            }
            

            return idTecla;
        }

    }
}
