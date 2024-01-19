public class Journal{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
    }

    public void DisplayAll(){
        foreach(Entry e in _entries){
            e.Display();
        }
    }

    public void SaveToFile(string file){
        using (StreamWriter outputFile = new StreamWriter(file)){
            foreach(Entry e in _entries){
                outputFile.WriteLine($"{e._date}~~{e._promptText}~~{e._entryText}");
            }
        }
    }

    public void LoadFromFile(string file){
         _entries.Clear();
         
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach(string line in lines){
            Entry myEntry = new Entry();

            string[] parts = line.Split("~~");

            myEntry._date = parts[0];
            myEntry._promptText = parts[1];
            myEntry._entryText = parts[2];

            AddEntry(myEntry);
            myEntry.Display();
        }
    }
}