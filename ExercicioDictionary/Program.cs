namespace ExercicioDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votos = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();           
            string name;


            try
            {
                using (StreamReader sr = File.OpenText(path))
                {

                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        name = line[0];
                        int qVotos = int.Parse(line[1]);
                        if (votos.ContainsKey(name))
                        {
                            votos[name] += qVotos;
                        }
                        else
                        {
                            votos.Add(name, qVotos);
                        }     
                        
                    }
                    foreach (var item in votos)
                    {                            
                        Console.WriteLine($"{item.Key}: {item.Value}");
                        
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}