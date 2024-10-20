namespace Datamain;
using Newtonsoft.Json;
public class Data { 
    public string? fileName { get; set; }
    public string? filepath2 { get; set; }
    public string? filepathtranslate { get; set; }
    public string filepath = @"C:\vocabulary\ressources\";

}


public class Translate {
    public string? toTranslate { get; set; }
    public string? translatet { get; set; }

}

public class RandomQuiz {
    //For the first vocabulary in the .json File
    public string? nextvocabfirst { get; set;}
    //For the second vocabulary in the .json File 
    public string? nextvocabsecond { get; set; } 

}