using System;

using static System.Console;

namespace ASCII;

public class AscII
{
    public void Display()
    {
        string border = @"
You see a sign ahead:



 .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.
/ .. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \
\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/ /
 \/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /
 / /\/ /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /\/ /\
/ /\ \/`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'\ \/\ \
\ \/\ \                                                    /\ \/ /
 \/ /\ \                                                  / /\/ /
 / /\/ /                                                  \ \/ /\
/ /\ \/               ENTER IF YOU DARE                    \ \/\ \
\ \/\ \                                                    /\ \/ /
 \/ /\ \                                                  / /\/ /
 / /\/ /                                                  \ \/ /\
/ /\ \/                                                    \ \/\ \
\ \/\ \.--..--..--..--..--..--..--..--..--..--..--..--..--./\ \/ /
 \/ /\/ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ /\/ /
 / /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\
/ /\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \
\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `' /
 `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'
";
        WriteLine(border);
        PromptToPressAnyKey();

        Clear();

        string temple = @"

                                    |
                                   ,|,
                                   |||
                                  / | \
                                  | | |
                                  | | |
                                 /  |  \
                                 |  |  |
                                 |  |   \
                                /    \  |
                                |    |  |
                                |    |   \
                               /     |   |
                8              |     |   |
              """"8""""           /      |    \
                8            /        \   ,\
              ,d8888888888888|========|="""" |
            ,d""  ""88888888888|  ,aa,  |  a |
          ,d""      ""888888888|  8  8  |  8 |
       ,d8888888b,   ""8888888|  8aa8  |  8,|
     ,d""  ""8888888b,   ""88888|========|="""" |
   ,d""      ""8888888b,   ""888|  a  a  |  a |
 ,d""   ,aa,   ""8888888b,   ""8|  8  8  |  8,|
/|    d""  ""b    |""""""""""""|     |========|="""" |
 |    8    8    |      |     |  ,aa,  |  a |
 |    8aaaa8    |      |     |  8  8  |  8 |
 |              |      |     |  """"""""  | ,,=|
 |aaaaaaaaaaaaaa|======""""""""""""""""""""""""""""""""""
            Normand  Veilleux
";

        WriteLine(temple);
        WriteLine("This is the tempale");
        PromptToPressAnyKey();

        Credits();
    }

    public void Credits()
    {
        WriteLine("==Credits==");
        WriteLine("Border by : https://www.asciiart.eu/art-and-design/borders");
        WriteLine("Temple by :  Normand  Veilleux | https://www.asciiart.eu/buildings-and-places/church");
    }

    static void PromptToPressAnyKey()
    {
        WriteLine("Press any key...");
        ReadKey(true);
    }
}
