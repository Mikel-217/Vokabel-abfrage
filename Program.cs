using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Datamain;

namespace Program;

public class Pmain {
    Datamain.Data d = new Datamain.Data();
    static void Main(string[] args) {

        start();
    }

    public static async void start() {

        Console.WriteLine("Vokabel abfrage: \n Bitte eingeben welche Option gewählt werden soll: \n1 --> Abfrage starten\n2 --> neue Vokabeln hinzufügen\n3 --> Beenden");

        int inputvi = Convert.ToInt32(Console.ReadLine()!);

        switch (inputvi) {
            case 1:
                //TODO
                break;
            case 2:
                VAdd adding = new VAdd();
                await adding.vadd();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }

}

public class VAdd : Data {

    Data d = new Data();

    public void mainadd() {

        Console.Clear();
        Console.WriteLine("1 --> Liste erweitern \n2 --> neue Liste erstellen\n");
        int inputmen2 = Convert.ToInt32(Console.ReadLine()!);

        switch(inputmen2) {
            case 1:
                //TODO
                break;            
            case 2:
                //TODO
                break;
            default:
                Console.WriteLine("Bitte Gültige eingabe machen");
                break;
        }
        
    }
    
    //ADD Vocabulary Task
    public async Task vadd() {

        List<string> inputvoc = new List<string>();
        Console.WriteLine("Bitte Vokabel eingeben und Enter drücken: \nESC zum beenden drücken \n");
        
        while (true) {
            d.vocabluary = Console.ReadLine();
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);

            if(keyinfo.Key == ConsoleKey.Escape) {
                if(inputvoc.Count > 0) {
                    await Writedata(inputvoc);
                }
                Thread.Sleep(2000);
                Pmain.start();
            }
            inputvoc.Add(d.vocabluary!);
        }

    }

    //Data Writing to a Txt File
    public async Task Writedata(List<string> inputvoc) {

        string filepath = @"C:\tmp\tests\ressources\vokabeln1.txt";
        // string filepath = @"C:\tmp\tests\ressources\{Data}"; --> Later for getting the right path

        using (StreamWriter stream = new StreamWriter(filepath, append: true)) {

            foreach (string voc in inputvoc!) {
                await stream.WriteLineAsync(voc);
                Console.WriteLine($"Hinzugefügt: {voc}");
            }
        }
        Console.WriteLine("Alle hinzugefügt");
        inputvoc.Clear();
    }

    //To Create a File 
    // public async Task CreateFile() {

        //<Todo>    

    // }

}


