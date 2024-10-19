using Program;
using Datamain;
using System.Text.Json;

namespace writing;

public class Writehandler : Data {
    
    Data d = new Data();

    Translate t = new Translate();  
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
    
    public async Task vadd()
    {
        List<Translate> inputvoc = new List<Translate>();
        Console.WriteLine("Bitte Vokabeln eingeben. ESC zum Beenden drücken.\n");

        while (true)
        {

            //Input first vocabulary
            Console.Write("Wort: ");
            string vocab1 = Console.ReadLine()!;

            //Input second vocabulary    
            Console.Write("Übersetzung: ");
            string vocab2 = Console.ReadLine()!;
            
            //check for ESC to return to the menu
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            if(keyinfo.Key == ConsoleKey.Escape) {

                if (inputvoc.Count > 0) {
                    await Writedata(inputvoc);
                }
                Pmain.start();
            }

            inputvoc.Add(new  Translate{ toTranslate = vocab1, translatet = vocab2 });
        }
    }

    // Writing in .json file
    public async Task Writedata(List<Translate> inputvoc)
    {
        string jsonString = JsonSerializer.Serialize(inputvoc, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(d.filepath2!, jsonString);

        Console.WriteLine("Alle Vokabeln hinzugefügt");
        inputvoc.Clear(); 
    }


    //To Create a File 
    public async Task<string> CreateFile(string fileName) {

        //creates folder
        if(!Directory.Exists(d.filepath)) {
            Directory.CreateDirectory(d.filepath);
        }
        d.filepath2 = d.filepath + fileName + ".json";
        using (FileStream fs = File.Create(d.filepath2)) {
        //Just close the file after creating it
        }

        Console.WriteLine($"Datei wurde erfolgreich erstellt: {d.filepath2} {d.filepathtranslate}");
        await vadd();
        return d.filepath;
    }
}