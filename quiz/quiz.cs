using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using Datamain;
using Newtonsoft.Json;

namespace RQuiz;

public class Quiz {
    Data d = new Data();
    RandomQuiz rq = new RandomQuiz();
    List<RandomQuiz> quizdata = new List<RandomQuiz>();

    Random r = new Random();

    public async void mainquiz() {
        Console.WriteLine("Vokabelnüben: \n");
        await selectFileQuiz();
    }

    public void randomquestions() {
        
        Console.Clear();
        int quiznumber = quizdata.Count();

        for (int i = 0; quiznumber > i; i++) {
            int randomindex = r.Next(quiznumber);
            var randomquiz = quizdata[randomindex];
            Console.WriteLine($"Bitte geben sie für: {randomquiz.nextvocabfirst} die Übersetzung an");
            string input = Console.ReadLine()!;
            if(input == randomquiz.nextvocabsecond) {
                Console.WriteLine("Ihre Antwort ist richtig\n");
                continue;
            }else {
                Console.WriteLine($"Ihre Antwort ist falsch. Richtig wäre {randomquiz.nextvocabsecond}");
                continue;
            }

        }
    }

    public async Task getData() {
        string jsonData;
        try {
            Console.WriteLine(d.filepath2);
            if(d.filepath2 == null) Console.WriteLine($"Datei leer {d.filepath2}");
            using (StreamReader sr = new StreamReader(d.filepath2!)) {
                jsonData = await sr.ReadToEndAsync();
            }
            
            List<Translate>? translations = JsonConvert.DeserializeObject<List<Translate>>(jsonData);

            foreach (Translate translation in translations!) {
                quizdata.Add( new RandomQuiz{
                    nextvocabfirst = translation.toTranslate,
                    nextvocabsecond = translation.translatet
                });
            }

            randomquestions();
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    public async Task selectFileQuiz() {
        try {
            string[] files = Directory.GetFiles(d.filepath);
            Console.WriteLine("Ihre Dateien: \n");
            for(int i = 0; i < files.Length; i++) {

                Console.WriteLine($"{i} {files[i]}\n");
            }
            Console.WriteLine("Bitte den Gewünschte Datei der Liste eingeben: \n");
            int inputfile = Convert.ToInt32(Console.ReadLine()!);
            d.filepath2 = files[inputfile];
            await getData();
        } catch(Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}
