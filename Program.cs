using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Program;


public class Pmain {

    static void Main(string[] args) {

        start();
    }

    public static async void start() {

        Console.WriteLine("Vokabel abfrage: \n Bitte eingeben welche Option gewählt werden soll: \n1 --> Abfrage starten\n2 --> neue Vokabeln hinzufügen\n");

        int inputvi = Convert.ToInt32(Console.ReadLine()!);

        switch (inputvi) {
            case 1:
                break;
            case 2:
                VAdd adding = new VAdd();
                await adding.vadd();
                break;
            default:
                break;
        }
    }

}

class VAdd : Data {

    Data d = new Data();
    
    public async Task vadd() {

        List<string> inputvoc = new List<string>();
        Console.WriteLine("Bitte Vokabel eingeben und Enter drücken: \n ESC zum beenden drücken \n");

        while (true) {
            d.vocabluary = Console.ReadLine();
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);

            if(keyinfo.Key == ConsoleKey.Escape) {
                if(inputvoc.Count > 0) {
                    await Writedata(inputvoc);
                }
                Pmain.start();
            }
            inputvoc.Add(d.vocabluary!);
        }

    }

    public async Task Writedata(List<string> inputvoc) {

        string filepath = @"C:\tmp\tests\ressources\vokabeln1.txt";

        using (StreamWriter stream = new StreamWriter(filepath, append: true)) {

            foreach (string voc in inputvoc!) {
                await stream.WriteLineAsync(voc);
                Console.WriteLine($"Hinzugefügt: {voc}");
            }
        }
        inputvoc.Clear();
    }

}



public class Data { 
    public string? vocabluary { get; set; }

}