using Common.Helpers;
using Day07;

IEnumerable<string> lines = await PuzzleInputReader.GetPuzzleInputs();

lines = lines.Skip(1);

FSDirectory rootDirectory = new("/", null);
FSDirectory currentDirectory = rootDirectory;


foreach (string line in lines)
{
    List<string> words = line.Split(' ').ToList();

    if (words.ElementAt(0) == "$")
    {
        string command = words.ElementAt(1);
        if (command == "cd")
        {
            string destination = words.ElementAt(2);
            if (destination == "..")
            {
                currentDirectory = currentDirectory.GetParentDirectory();
            }
            else if (destination == "/")
            {
                currentDirectory = rootDirectory;
            }
            else
            {
                currentDirectory = currentDirectory.GetChildItemByName<FSDirectory>(destination);
            }
        }
        else if (command == "ls")
        {
            //do nothing
        }
        else
        {
            throw new ArgumentException();
        }
    }
    else if (words.ElementAt(0) == "dir")
    {
        currentDirectory.AddChild(new FSDirectory(words.ElementAt(1), currentDirectory));
    }
    else if (int.TryParse(words.ElementAt(0), out int size))
    {
        currentDirectory.AddChild(new FSFile(words.ElementAt(1), size, currentDirectory));
    }
}

int counter = 0;
rootDirectory.TabulateSizeWithThreshold(100000, ref counter);

Console.WriteLine($"Total thresholded size: {counter}");

int freeSpace = 70000000 - rootDirectory.GetSize();
int spaceToFree = 30000000 - freeSpace;

List<FSDirectory> dirsList = new List<FSDirectory>();
rootDirectory.GetSizeAndAddToListIfAtLeastThreshold(spaceToFree, dirsList);

FSDirectory minimumFolder = dirsList.OrderBy(d => d.GetSize()).First();

Console.WriteLine($"Delete folder: {minimumFolder.GetName()} - {minimumFolder.GetSize()}");