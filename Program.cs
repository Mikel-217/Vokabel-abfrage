using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Datamain;
using System.Net;
using writing;
using Delete;
using RQuiz;

namespace Program;

public class Pmain {
    static Data d = new Data();
    static void Main(string[] args) {
        Console.Title = "Vokabel abfrage";
        start();
    }

    public static void start() {

        Console.WriteLine("Vokabel abfrage: \n Bitte eingeben welche Option gewählt werden soll: \n1 --> Abfrage starten\n2 --> neue Vokabeln hinzufügen\n3 --> Vokabeln löschen\n4--> Programm beenden");

        int inputvi = Convert.ToInt32(Console.ReadLine()!);

        switch (inputvi) {
            case 1:
                Quiz quiz = new Quiz();
                quiz.mainquiz();    
                break;
            case 2:
                Writehandler wh = new Writehandler();
                wh.mainadd();
                break;
            case 3:
                Deletefiles delete = new Deletefiles();
                delete.selectdelete();
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Bitte Gültige eingabe machen");
                break;
        }
    }

    /** 
    TOD:
    - Seperate Reader for all classes? --> Yes / Done
    - Fix Overriting the .json file
    - Add Random Questions --> Done
    - Fix bugs:
        - Program ends after new list input
        - Json Serialliser doesnt work
    **/

}
