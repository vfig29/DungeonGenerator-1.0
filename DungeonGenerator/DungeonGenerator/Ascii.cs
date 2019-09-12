using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonGenerator
{
    class Ascii
    {
        int atributo;
        public Ascii()
        {
        }
        public static void TelaInicial()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("________                                                                      ____                                                                           ");
            Console.WriteLine("`MMMMMMMb.                                                                   6MMMMb/                                                                         ");
            Console.WriteLine(" MM    `Mb                                                                  8P    YM                                                 /                       ");
            Console.WriteLine(" MM     MM ___   ___ ___  __     __       ____     _____   ___  __         6M      Y   ____   ___  __     ____   ___  __    ___     /M       _____   ___  __ ");
            Console.WriteLine(" MM     MM `MM    MM `MM 6MMb   6MMbMMM  6MMMMb   6MMMMMb  `MM 6MMb        MM         6MMMMb  `MM 6MMb   6MMMMb  `MM 6MM  6MMMMb   /MMMMM   6MMMMMb  `MM 6MM ");
            Console.WriteLine(" MM     MM  MM    MM  MMM9 `Mb 6M'`Mb   6M'  `Mb 6M'   `Mb  MMM9 `Mb       MM        6M'  `Mb  MMM9 `Mb 6M'  `Mb  MM69  '8M'  `Mb   MM     6M'   `Mb  MM69  ");
            Console.WriteLine(" MM     MM  MM    MM  MM'   MM MM  MM   MM    MM MM     MM  MM'   MM       MM     ___MM    MM  MM'   MM MM    MM  MM'        ,oMM   MM     MM     MM  MM'    ");
            Console.WriteLine(" MM     MM  MM    MM  MM    MM YM.,M9   MMMMMMMM MM     MM  MM    MM       MM     `M'MMMMMMMM  MM    MM MMMMMMMM  MM     ,6MM9'MM   MM     MM     MM  MM     ");
            Console.WriteLine(" MM     MM  MM    MM  MM    MM  YMM9    MM       MM     MM  MM    MM       YM      M MM        MM    MM MM        MM     MM'   MM   MM     MM     MM  MM     ");
            Console.WriteLine(" MM    .M9  YM.   MM  MM    MM (M       YM    d9 YM.   ,M9  MM    MM        8b    d9 YM    d9  MM    MM YM    d9  MM     MM.  ,MM   YM.  , YM.   ,M9  MM     ");
            Console.WriteLine("_MMMMMMM9'   YMMM9MM__MM_  _MM_ YMMMMb.  YMMMM9   YMMMMM9  _MM_  _MM_        YMMMM9   YMMMM9  _MM_  _MM_ YMMMM9  _MM_    `YMMM9'Yb.  YMMM9  YMMMMM9  _MM_    ");
            Console.WriteLine("                               6M    Yb                                                                                                                      ");
            Console.WriteLine("                               YM.   d9                                                                                                                      ");
            Console.WriteLine("                                YMMMM9                            ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("__/       ____   ");
            Console.WriteLine("`MM      6MMMMb  ");
            Console.WriteLine(" MM     6M'  `Mb ");
            Console.WriteLine(" MM     MM    MM " + "                                     " + "Sua zona está sendo criada, aguarde alguns segundos!");
            Console.WriteLine(" MM     MM    MM ");
            Console.WriteLine(" MM     MM    MM ");
            Console.WriteLine(" MM 68b YM.  ,M9 ");
            Console.WriteLine("_MM_Y89  YMMMM9 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       _              ");
            Console.WriteLine(" /_    | | ._/_ _  _  /_` / . _ _/_ _ ");
            Console.WriteLine("/_//_/ |/ / /  /_//  /_, / / /_//  /_'");
            Console.WriteLine("   _/                                 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                                                     --:/++++/                                                      ");
            Console.WriteLine("                                                                                                                 :/+++os+osso/-  --                                                    ");
            Console.WriteLine("                                                                                                          :/+oossssssoosssooyssys+-                                                    ");
            Console.WriteLine("                                                                            --::-                     :+oyyssssyssyyososooooo+++ooo                                                    ");
            Console.WriteLine("                                                                -//:::/++soyyhmmddy/                -oyddhhsyhhyyyyyssoooo+o+++/:-                                                     ");
            Console.WriteLine("                                                              -////+ossyyhmdyydddmmyo              -osddsshhhhhyhhyssoossso++/-                                                        ");
            Console.WriteLine("                                                              -:::///shyhddhhddmNmNmhs             oosyssssyydyhhyssssssyssyosyy+                                                      ");
            Console.WriteLine("                                                               -:::::/oshddddmmmmmmNdys          -ssyhdhhdddddmmdhdhhyooso+/-                                                          ");
            Console.WriteLine("                                                                 -:/ooyhmmmmNNmdmmmmNhho         osdhhdmmNmNmmNmmmddys+//-                                                             ");
            Console.WriteLine("                                                                ::::ohhdmNNNNNmmmNmddmsyo       oshNmmmNNNmNmmmmyoys+-                                                                 ");
            Console.WriteLine("                                                   +ddd:-+yhyso+/- -:odddmdhmNmNNdmmmmosd+     +oymNNNNNNNmdmddss-                                                                     ");
            Console.WriteLine("                                                   ommdmmNNdyhdddh:   - -:--md+NNysyhsyoyd+::+ssymNNNNNNNmdho+/                                                                        ");
            Console.WriteLine("                                                    ---mNNmmmh+///+         -  /hysys+syhoshoyhhmNNNNNNmmds--                                                                          ");
            Console.WriteLine("                                                      /mmmhddo//so+:              yhhssyyysysddNMNNNNMNmso                                                                             ");
            Console.WriteLine("                                                      smyd+oh+++o++:              oyhyhsmyyhmNNMMMNNNNNd:                                                                              ");
            Console.WriteLine("                                                      smmmdsh++o+:o:             +osshhhddhdmmNNMMMNmhs-                                                                               ");
            Console.WriteLine("                     :   -::+/-                    -+ymdsdo++oo+-            hdhhdhyhmmhdhdmNNNMo:/+                  -oyyhhs/                                                      ");
            Console.WriteLine("                    -o:///+o+o+                      +dmhhyohhy-           /ymmmdhyo+sdddddmmNmN:                     hNNmNNmdo-                      -///o+:-                      ");
            Console.WriteLine("                     o-::+++++o-              /::/+syhdmmdhsymdyssos+      s/+y+:     smmNNNmmNN+    --              :hdNyyMd/:-                    +hmmmdhddds/                    ");
            Console.WriteLine("                     :/o/s/+++o              smdssoosysyhdddhhhdhdmmdo               sdNNmdNNNNdo  :/+/:-           /dNNNmoMy-o:                   :hmmdysyyhhhh                    ");
            Console.WriteLine("                      //o+++/so            /hdyhhssosossyyhhdhhhhdhmmdo:            /dNds/omdmmd/ o/::/:++/        :dmNNNNmNy--/                   odNNhyshhysos-                   ");
            Console.WriteLine("                      :+oo++ssyo/-        ohdyshhyyososssyymNmhyhyhdmmoo/-          hmd+hhyyyhNy-:s/-   :/s-      -hdNNNNNNNm::                    smNmmhyhyysys-                   ");
            Console.WriteLine("        :ss- -:/:::--//ysosydymmmdhs++/- /ysyyy+sdhssoosydmdmdmhhhhhdmooss+       :+s+yoyyhyshNh--oo+::++o/-     -/yyNdNNMMMNhso///:               /ymNmyyyssyh+-                   ");
            Console.WriteLine("        -hNy+s/ -/oso//ss+ssshmNNNhyhdmms+:+oysyydmmhhhddddhddmdddhddmdyhhhy+  :oy+o++sydhyh-dhms:-:/- -:: --:/ss+ymNNMMMNNNmmmmmmNm                -/hhdyyssyss                    ");
            Console.WriteLine("       -/+oooo:oydyy/:/:+//syhhdNdyooshdmds/syhhhhNNddhdhhdhmddmmmNmdmNmmmdhdyssys+syhdsy/:  h-dd/ ---:    /syssysydmdNNNmmmmmmmmmho                   -/syhooy+                    ");
            Console.WriteLine("       -+yyho/yydmyys////+osoyydNms+shhhNNh/+hhhs ydmdddddmdmmNNmmNNmmmmNmmhdmhsshhdyo/ o    : /ds::+oo+:  +hdsyhsohdmMMmdmdmmmmm+:::     --::-:--:++/://+++shy+o++/-               ");
            Console.WriteLine("       +syd+/hhoohyysss+/+osydmNNNh::ydmNNms:+ys  -ddddddddhdhdhhmNmd+-/sdmmmmdddhoo -- :       /:--+mdhd  :ydssyoohhMMMmmmmdmmm/::-: /oosy+/+oosssho+/:+++soo+syyy+so/-            ");
            Console.WriteLine("       sdNN/yy//shyyyyysyydmdmdmNNNh /yhyhmmy-:    /ddhhhhyyyssyyhdhd+  :/-/sdyoo- :-                sddm/::-doososyhdmNmmmmdho/--+/-/yyoyhy++/ossys    :+oo+/:/yhhy:o+so/          ");
            Console.WriteLine("       hmNmysyhhdsyyhyyyyhhddmmNNNNMssyyyoyhs       ymdddhyyyyyyyysyh+   :   s  -:                   sddo--::ss+ooyhhhydmmmddho++s/--:h+/odhsoyyhyy-  /+//++: -odhhhooyossho-       ");
            Console.WriteLine("       +-:+o///hmhoyhhhhydhddmNNNNNNNh/:-/:/os:     hmmdddhyyyo:++oss/       -                       sds:-:://+osssyyhssmmmmmdddd/:++oy+ooshhsyysho//+++/-  -/+hmmdhysossyydyo      ");
            Console.WriteLine("       :  //ssoyddyyhyyhdhhhdmNNNNNmd++/:/+oyhs/  :yhmmdmddhhyo+yy/+s:                      -        os++:----:yssssyyhyhNmmddddm: :+-+ooyy+/+syo:ssooo:  -:/sdNNNmhyyo/oyhhyh-     ");
            Console.WriteLine("      -/  /+shhhdmdymhsyhddhmmNNNNmmy //oossyyys /syyddmmdhdhyys/yh/::          //      /+++osoyyho   so+:/++/ yoshyhhhhhmmmmdmdh   +h:-soys/:-   syyss/s+symmmNNmmhhdhsooyhyy      ");
            Console.WriteLine("       o--//yhy-+NdmhmhyydmmNNNNNNmh/ :oo/+/osd//yyhyyddddhhhyoyy+sd+--          -/+/- oooosshhyhddy:/+soso/   shyydyhddmdNNNmmmh    +h+ o+ooshso-+sddhdmmmmNNNdhhhshhyyhhyyysy:    ");
            Console.WriteLine("       -/-os+/  -NNmmmmmyshNNNMNNmdhohdy//+sys: odmmmdmmmddmdhhdhy:shs--           :+sys:/-::+oymmdyysso+-     /dmmddmmdmmdmNNNNm-     -oohhh+ :+ysosydNmNNmmmds/y+++ s///+ysssd:   ");
            Console.WriteLine("         -      /hdddddmdyydmyssooshmmNNyso/   symmddhdmyydmmhhhyyo:ody-            -/shos+/yys+hddh+/:-        -omdmmmNmmNNNNmmNs y/    /hddds   -hdhsoydmddy+-://:/ o  +o+shy/    ");
            Console.WriteLine("                :hyhhyhhhhhy////+/o+hyo/      -dddmdhydmhyddhyyysso+:sdy:            :syo///+/+ydddhhy-          oddmdmmdhdNmNdmNdymms/:-  yddhs  -sdmddhyssso/:://o/ s:osoydo/     ");
            Console.WriteLine("                +hyhhyyshyhsyso+ymd/-         ohdmdho+hmoohdhyhdyyss+-smdo+:         :hyys+o+shhdmmddy+        /ymdhhddmmoydmNNNmdmNNmyyyhsodyyys-ss/osdmmddyosyddyo+/hyyydo-       ");
            Console.WriteLine("               :yhyhhyoohddoyhdmmmho+:       -hmdmsh/+hm++hddhyhyhsys:+mmNs        :/sohdhhsdmmmdmmmdo:      /shhhhhhyhdmo+dmmmhddmdmhs  -:oyoo+:ody/--oohmmddddhhyyyohdh+-         ");
            Console.WriteLine("              -hdhysysysshysyhyhhmdyh:-      /mdmhyy/+ydooyhhhhhshhys+/smmds     -+hhysddsydhdddhhsssyooyh: o+ss+shyyshymy+ymmdhmdddmdh-     :- /ssyhsyyyddddhsyhhhhhodo            ");
            Console.WriteLine("             -ydhhhhdmmdsoohdddhydmd/        -:dmhdhsyyhhhyhhdhdyhhysy//oydh/    /hh/:sy+oom:+oy/h+/:sdhhyy +o+/+hhhdmhhhys+dmmmmhddmmhs:       :soosyshddhyssddmmdmhsdhs+:-        ");
            Console.WriteLine("            -ohhhyyymdmNdhoodmNNmmNmh:        -dNdmhhhysydyyhdhdyhhyso:syhmms/   odo  -//+so--/soo/ sdh++sy:-+/+hhydmhhhdNyohhdNmdddmmdy-       soyos+yyyyyhhddyyhdddsy/+syso/:     ");
            Console.WriteLine("           -:hhhysyhdmdmNmy+odmNNmmmmy:       +dmddhhhhsydhyhdddyddhys/ydmddhs: -/ds   /+//   /o/- -dm: -:oy/:oyssyhyhdhmMdhddNNNNmmmNhs:      /oyooysyshhhsoosssohyddy-  -/ssso/-  ");
            Console.WriteLine("           -yhyhyyshyhmmdmddydNmNdmddhy/      odddmNmdhyyyyyhhyhyyhhhhs/ooohmhs++ohh  ---/  -:osyy:/hm/  -/ys+//+oossdNNNNdNNNMMMMNNmm/-       +yhoooyhds+yo++oosossdmh:     -:+ooo+");
            Console.WriteLine("           +dhhohyyyhhhddhddmmmmNNdmdsoh+-      -hmmmdddhhhhdyoyddddhho:  :odmdhhyyd+:--/-/ohhdddhsosd:-/++++ys-/oshNNMMdmdddmmNNNNNNN+-       /ydsssyyhsoyss+ooosyydds:         -/o");
            Console.WriteLine("          /hdhhyhyyhyyddddhhmdNNNmmmmo /ho:      :dmy+::///os+ :hmdh+//:-  ohmmdddhmssoo+yhdhs+/oosydd  oos+/+yo:sdMNNMNhhhdydmmNNNNNmy-        :oyddmdddyhyhhhhdyhddh/:            ");
            Console.WriteLine("         -sdmyhhhhdyhhydyydddmmNNNdNdd- -sy/      -yhh/:::/+s   -hmdyso/:- -/oydddhyyyhyhhhyyooyyyyydh- -/+ooyhh/hNMNMMmyhhmhddmNNmmmhd-           :dNNNNNmmmmmmNmmhoyo:            ");
            Console.WriteLine("--       /mmddddmdhdhhmhhhhmhNNNNNNmNd:   +yo:     /ddyyyyhy-    /mmmhso+/:   -/syohyyyshhyhsydddmhssho+osyddmo+smmNNMMmydhmdddddmmmddh+            smdmmdhhyddmNhhssss+            ");
            Console.WriteLine("----     +soyyhmdmmhmddmhdddmmmNNNdNdd:    :ys/-   /dNmddddy     :dmmddddh+       -dshsydmddshmdmdsyyhhdhhdhhy+ydmdmMMMdyyhdhdhhhdddddyh-           :hdhyysooyyhmhooy/os         ---");
            Console.WriteLine("---------sso+:/+ssoosyhhydmdmmmmmNmNdm: -   -oy+:  ddNmdhhds     hhmdhhdhh-       :dysyhmdddydddhhhddd+:://++shymhmmMMMhydhhhdmmhhddNhhds-           -yhhhsosyyhd//h+ -y:    -------");
            Console.WriteLine("--------:hhhhhhyo++o++/:/++ssyhydmmhyo----   -/ys+/yhhhysyhy-   /dddhhhhd+       -shoodhhyso+yyosshddd-://oydhdmdmdNMhhdhdhyhdmmhhddmhyyh/            /dddhsyhhhd+s/-  /s   --------");
            Console.WriteLine("--------+hdddmmNd:-::::/::/sdmmNNmm+:-----  -- -+hsosoysoshh----sdddhhhhd--  --:/oyhyyydh++/-----:/syd+ -:/oohdhhhhMd-oyhhyshdddhhdhhyyyo+            :dddhsshhdd/---   +/----------");
            Console.WriteLine("----::---sdddmmNN/--       hdhhdmmm+-------- --  :yhs+osssyy----ydmdhhyyd----:+ossohhyhmNhss+:-:-::+shh-   -:NNMNmmd:-o+so+oshsyyyhyysso/----       ---ohdhsyyddmd:---- -//:::----:-");
            Console.WriteLine("---::::---shddmmNNo------- +dddmNNNm::------------:/yho++shs----odhdhyyhh:---syyyoyhhdyNNmdsss/:::/+syd+---:hdmNMNNo--/:/::/mmmmNmNm/:--------    -----:yhdysdMNmy::-----::/::::::-:");
            Console.WriteLine("::::::::--odddmmNNm:-------:dhhddmmm/-::----------+o+ohyo+so-:::/ddhyyyo/:---:oysyhhhyhMNmNmdysss+osyyhh---/yhhdNNd---------ddmNNNNy:---::--------------:hmyymNNNd::::::::::::::::::");
            Console.WriteLine(":::::/::--/dddmmNNm:-------smdddmNmmo:::::::-----:-::sooydy::::::dhyyyo::::::::/ohNmdhdNmmNMNNmdhhddhdddo--/shydNN/:--------yydmNNMy:::::::---:-------:::+ddhydmNo:::::::::::::::::/");
            Console.WriteLine("::////:::::dmdmmmNNd:::::::+mdmmmmNNy::::::::::::::::/dyoss:::::+hddhh/:::::::::/oddhhdmmmmh/dNmNNNNmmmdy::/syydNy:::::::---+sdmmmNh:::::::::::::::::::://mdhymNN+:://::////////////");
            Console.WriteLine("///////////ymmNNNNNs/::::::ymmmmNNMd//::::::/::::::://sdyyho///ohmdddd::::::::::::/dmNmmmms::/ymNMNNNNh//:/+yhhmN+:::::::::::yhdmNNd//:://////:::::://////mhymNNm///////////:///////");
            Console.WriteLine("/////////+++mmmmNNNm///////ommmNmNNy//////////:///////omddhh//ohdmmmddo://////::://mdmmNMNh/://dNmmmMMd/////ydhmm//////:::::/+syhmmd//////////////////////dyhdmMy/////////////+++++/");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();


        }
        public static void setas(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("                             --");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("                            -ym-           ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("                           -hMMh-                 ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("                         -hNMMMMMh-               ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("                       -yNMMMMMMMMNh-               ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("                      /yhhhMMMMMMhhhy/            ");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine("                          .MMMMMM.                 ");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine("                          .MMMMMM.                 ");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine("               `          .MMMMMM.           ");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine("             -y/          .MMMMMM.          /y-      ");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine("           -yNM+          .MMMMMM.          +MNy-      ");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine("         -yNMMMhoooooooooo++++++++oooooooooohMMMNs-    ");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine("       .yNMMMMMMMMMMMMMMMMd      dMMMMMMMMMMMMMMMMNs.    ");
            Console.SetCursorPosition(x, y + 13);
            Console.WriteLine("       -hMMMMMMMMMMMMMMMMMd      dMMMMMMMMMMMMMMMMMh-    ");
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine("         :hNMMMdyyyyyyyyyys::::::syyyyyyyyyydMMMMh:       ");
            Console.SetCursorPosition(x, y + 15);
            Console.WriteLine("           :hMM+          .MMMMMM.          +MMh:      ");
            Console.SetCursorPosition(x, y + 16);
            Console.WriteLine("             :h+          .MMMMMM.          +h:        ");
            Console.SetCursorPosition(x, y + 17);
            Console.WriteLine("               `          .MMMMMM.          `           ");
            Console.SetCursorPosition(x, y + 18);
            Console.WriteLine("                          .MMMMMM.                      ");
            Console.SetCursorPosition(x, y + 19);
            Console.WriteLine("                          .MMMMMM.                      ");
            Console.SetCursorPosition(x, y + 20);
            Console.WriteLine("                      /sssyMMMMMMysss/               ");
            Console.SetCursorPosition(x, y + 21);
            Console.WriteLine("                       /dMMMMMMMMMMd/                   ");
            Console.SetCursorPosition(x, y + 22);
            Console.WriteLine("                         /dMMMMMMd/                     ");
            Console.SetCursorPosition(x, y + 23);
            Console.WriteLine("                           /dMMd/                     ");
            Console.SetCursorPosition(x, y + 24);
            Console.WriteLine("                             //                      ");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }

        public static void Instrucoes(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(",-_/         .                         ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("'  | ,-. ,-. |- ,-. . . ,-. ,-. ,-. ,-. ::");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(".^ | | | `-. |  |   | | |   | | |-' `-.");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("`--' ' ' `-' `' '   `-^ `-' `-' `-' `-' ::");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }
        public static void Area(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("    ,.                 ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("   / |   ,-. ,-. ,-. ::");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("  /~~|-. |   |-' ,-|   ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine(",'   `-' '   `-' `-^ ::");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }

        public static void Info(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(",-_/              ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("'  | ,-. ,', -. :: ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine(".^ | | | |- | |   ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("`--' ' ' |  `-' ::");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("         '        ");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }
        public static void Mapa(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(",-,-,-.                 ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine("`,| | |   ,-. ,-. ,-. ::");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("  | ; | . ,-| | | ,-|   ");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("  '   `-' `-^ |-' `-^ ::");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("              |         ");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("              '         ");
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }
    }

    
}
