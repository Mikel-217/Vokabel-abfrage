using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Datamain;
using System.Net;
using writing;
using reading;

namespace Program;

public class Pmain {
    Data d = new Data();
    static void Main(string[] args) {

        start();
    }

    public static void start() {

        Console.WriteLine("Vokabel abfrage: \n Bitte eingeben welche Option gewählt werden soll: \n1 --> Abfrage starten\n2 --> neue Vokabeln hinzufügen\n3 --> Beenden");

        int inputvi = Convert.ToInt32(Console.ReadLine()!);

        switch (inputvi) {
            case 1:
                //TODO
                break;
            case 2:
                Writehandler wh = new Writehandler();
                wh.mainadd();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Bitte Gültige eingabe machen");
                break;
        }
    }

}
