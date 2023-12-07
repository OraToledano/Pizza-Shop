using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using FileService;

namespace FileService;

    public class myFile:Ifile
    {
        public string FilePath { get ; set ; }
        public myFile()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory,"files", "myFile.json");

        }
        public void WriteMessage(string message)
        {
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, $" {message}");// {DateTime.Now}
            }
        }
        // public void AddItem<T>(T item){
        //     string json = File.ReadAllText(FilePath);
        //     var TList = JsonSerializer.Deserialize<List<T>>(json);
        //     TList.Add(item);
        //     json=JsonSerializer.Serialize(TList);
        //    WriteMessage(json);
        // }
        public List<T> readFromFile<T>()
        {  string json = File.ReadAllText(FilePath);
        Console.WriteLine("json"+json);
         if(json==default(string))
          { return default(List<T>);
          Console.WriteLine("json"+json);
          Console.WriteLine("default-string"+default(string));
          }
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            if (TList != null)
                return TList;
            return default(List<T>);
        }
        //   public void Update<T>(List<T> list){
        //    string json=JsonSerializer.Serialize(list);
        //    WriteMessage(json);
        //   }
       }

