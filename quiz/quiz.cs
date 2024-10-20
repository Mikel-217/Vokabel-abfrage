using Datamain;
using System.Text.Json;

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
        try {

            using (FileStream fs = new FileStream(d.filepath2!, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs)) {
                string jsonData = await sr.ReadToEndAsync();
                Console.WriteLine(jsonData);
                var options = new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                };

                List<Translate>? translations = JsonSerializer.Deserialize<List<Translate>>(jsonData, options);

                if (translations != null) {
                    foreach (var translate in translations) {
                        quizdata.Add(new RandomQuiz {
                            nextvocabfirst = translate.toTranslate,
                            nextvocabsecond = translate.translatet
                        });
                    }
                }
                Console.WriteLine("Daten erfolgreich geladen");
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
