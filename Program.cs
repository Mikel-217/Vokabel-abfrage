using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Datamain;
using System.Net;

namespace Program;

public class Pmain {
    Datamain.Data d = new Datamain.Data();
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
                VAdd add = new VAdd();
                add.mainadd();
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

public class VAdd : Data {

    Data d = new Data();

    public async void mainadd() {

        Console.Clear();
        Console.WriteLine("1 --> Liste erweitern \n2 --> neue Liste erstellen\n");
        int inputmen2 = Convert.ToInt32(Console.ReadLine()!);

        switch(inputmen2) {
            case 1:
                //TODO
                break;            
            case 2:
                await getFileName();
                break;
            default:
                Console.WriteLine("Bitte Gültige eingabe machen");
                break;
        }
        
    }

    public async Task getFileName() {
        
        Console.Clear();
        Console.WriteLine("Bitte geben Sie ihren Dateinamen an: \n");
        fileName = Console.ReadLine()!;
        await CreateFile(fileName);

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
                Thread.Sleep(100);
                Pmain.start();
            }
            inputvoc.Add(d.vocabluary!);
        }

    }

    //Data Writing to a Txt File
    public async Task Writedata(List<string> inputvoc) {

        Console.WriteLine(filepath2);
        using (StreamWriter stream = new StreamWriter(filepath2!, append: true)) {

            foreach (string voc in inputvoc!) {
                await stream.WriteLineAsync(voc);
                Console.WriteLine($"Hinzugefügt: {voc}");
            }
        }
        Console.WriteLine("Alle hinzugefügt");
        inputvoc.Clear();
    }

    //To Create a File 
    public async Task<string> CreateFile(string fileName) {

        //creates folder
        if(!Directory.Exists(filepath)) {
            Directory.CreateDirectory(filepath);
        }
        filepath2 = filepath + fileName + ".txt";
        using (FileStream fs = File.Create(filepath2)) {
        //Just close the file after creating it
        }
        Console.WriteLine($"Datei wurde erfolgreich erstellt: {filepath2}");
        await vadd();
        return filepath2;
    }

}


