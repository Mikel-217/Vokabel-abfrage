using Datamain;
using Program;
using writing;

namespace reading;

public class Readhandler {

    Data d = new Data();
    Writehandler wh = new Writehandler();
    public async void mainread() {
        
    }


    public async void searchinput() {
        Console.WriteLine("Bitte den Gewünschte Namen der Liste eingeben: \n");
        string inputfile = Console.ReadLine()!;
        await getallfile(inputfile);
    }

    public async Task getallfile(string? inputfile) {

        try {
            string[] files = Directory.GetFiles(d.filepath);
            foreach (string file in files) {

                if(file == inputfile) {
                    inputfile = d.rightfile;
                }

            }
        } catch(Exception e) {

            Console.WriteLine(e.Message);
        }
    }

}