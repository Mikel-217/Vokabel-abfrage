using Datamain;
using Program;
using writing;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

namespace reading;

public class Readhandler {

    Data d = new Data();
    Writehandler wh = new Writehandler();
    public void mainread() {
        searchinput();
    }

    public void searchinput() {
        try {
            string[] files = Directory.GetFiles(d.filepath);
            Console.WriteLine("Ihre Dateien: \n");
            foreach (string file in files) {
                Console.WriteLine($"{file}\n");
            }
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("Bitte den Gewünschte Namen der Liste eingeben: \n");
        string inputfile = Console.ReadLine()!;
        setrightfile(inputfile);
        
    }

    void setrightfile(string? inputfile) {

        string[] files = Directory.GetFiles(d.filepath);
        foreach (string file in files) {
            if(file == inputfile) {
                d.rightfile = file;
            }
        }
    }

}