
using Datamain;
using Program;
using System.IO;


namespace Delete;


public class Deletefiles {
   
    Data d = new Data();

    public void selectdelete() {
        try {
            string[] files = Directory.GetFiles(d.filepath);
            Console.WriteLine("Ihre Dateien: \n");
            for (int i = 0; i < files.Length; i++)
            {

                Console.WriteLine($"{i} {files[i]}\n");
            }
            Console.WriteLine("Bitte den Gewünschte Datei der Liste eingeben: \n");
            int inputfile = Convert.ToInt32(Console.ReadLine()!);
            d.filepath2 = files[inputfile];
            deletefile(d.filepath2);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }

    }

    public void deletefile(string filepath2) {
        
        Console.WriteLine($"{d.filepath2} deleted");
        try {
            File.Delete(d.filepath2!);
            Pmain.start();
        } catch (Exception e) {
            Console.WriteLine("Datei existiert nicht", e);
            Pmain.start();
        }
    }
}