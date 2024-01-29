using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using modelsLib;

// using modelsLib;
// using FileService;

namespace FileService;

    public class myMail:IMail
    {
        public string FilePath { get ; set ; }
        public myMail()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory,"files", "mailDetails", "mail.txt");
        }
        public void WriteMessage(OrderPizzaobj message)
        {  
            if (File.Exists(FilePath))
            {
                // Console.WriteLine("\n\n\nhiiiiiiiiiii\n\n\n");
                File.AppendAllText(FilePath,DateTime.Now+"\n");
                File.AppendAllText(FilePath,"PIZZA SHOP\n");
                double sum=0;
                File.AppendAllText(FilePath,"costumer:"+message.CostumerName+", number:"+message.CostumerId+"\n");
                foreach (var item in message.ListP)
                {
                    File.AppendAllText(FilePath,item.Name+"\t\t"+item.Price+"\n"); 
                }
                File.AppendAllText(FilePath,"total price:"+message.TotalPrice+"₪\n"); 
                File.AppendAllText(FilePath,"thanks for buying in our shop!!\n\n\n");
            }
        }
    }