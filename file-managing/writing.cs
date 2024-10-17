using Program;
using Datamain;

namespace writing;

public class Writehandler : Data {
    
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

        Console.WriteLine(d.filepath2);
        using (StreamWriter stream = new StreamWriter(d.filepath2!, append: true)) {

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
        if(!Directory.Exists(d.filepath)) {
            Directory.CreateDirectory(d.filepath);
        }
        d.filepath2 = d.filepath + fileName + ".txt";
        using (FileStream fs = File.Create(d.filepath2)) {
        //Just close the file after creating it
        }
        // d.filepathtranslate = "translatet_" + d.filepath2 ;
        // using (FileStream fs = File.Create(d.filepathtranslate)) {
        //For the translation --> added later
        // }

        Console.WriteLine($"Datei wurde erfolgreich erstellt: {d.filepath2} {d.filepathtranslate}");
        await vadd();
        return d.filepath;
    }
}