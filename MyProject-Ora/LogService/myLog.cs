using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;


namespace LogServices;

    public class myLog:Ilog
    {
        public string FilePath { get ; set ; }
        public myLog()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory,"files", "midlleware.txt");

        }
        public void WriteMessage(string message)
        {
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, $" {message}");
            }
        }
    
       }
