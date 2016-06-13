using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysEverything
{
    public class Comands
    {
        public string[] befehle = new string[10];

        public string Help(int Zahl)
        {
            befehle[0] = "'ReadMe' zeigt die 'Readme.txt' an.";
            befehle[1] = "'Comand' zeigt alle Comands an.";
            befehle[2] = "'Github' zeigt den Github-Link des Projekts an.";
            befehle[3] = "'License' zeigt die Lizenz an.";
            befehle[4] = "'About' Über den Streamer. 8=====D";


            return befehle[Zahl];
            
        }

        public string ReadMe()
        {

            return "ReadMe";
        }

        public string Comand()
        {
            return "!help,!Readme,!Comands,!Github,!License,!About,!Comandhelp [comand]";
        }

        public string Github()
        {
           return "http://www.github.com/philimnorden/TwitchPlaysEverything";  
        }

        public string License()
        {
            return "Hier entsteht noch ein Text...";
        }

        public string About()
        {
            return "Hier ensteht noch ein Text...";
        }
        
    }
}
