using System;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using XDocument.Model;


class Program
{
  
    public class GetSerilizerClass
    {
        private readonly string _filepath;
        public GetSerilizerClass(string filepath)
        {
            this._filepath = filepath;
        }

        public Template GetJsonFile()
        {
            if (!File.Exists(_filepath))
            {
                Console.WriteLine("JSON file not found.");
                return new Template { Configurations = new List<Configuration>() };
            }
            using FileStream json = File.OpenRead(_filepath);
               Template teachers = JsonSerializer.Deserialize<Template>(json) ?? new Template { Configurations = new List<Configuration>() };
            return teachers;

        }
    }
    public static void Main()
    {
       string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Console.WriteLine(path);
        string jsonpathname = Path.Combine(path, "Template.json");
        Console.WriteLine(jsonpathname);
        try
        {
            GetSerilizerClass serializer = new GetSerilizerClass(jsonpathname);
            Template teachers = serializer.GetJsonFile();
            foreach (Configuration config in teachers.Configurations)
            {
                 Console.WriteLine(config.ToString());
            }
            Console.ReadLine();
        }
        catch (Exception ex) { 
        Console.WriteLine(ex.ToString());
            Console.ReadLine();
        }
    }
}
