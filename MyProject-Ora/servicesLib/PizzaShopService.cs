using modelsLib;
using interfacesLib;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using FileService;

namespace servicesLib;

public  class PizzaShopServices :IPizzaShopServices
{
    // static List<PizzaShopObj> pizzas {get;}
  private Ifile fileService{get;set;}
    static int Counter =0;
    public DateTime createDate{get;set;}
    
    public PizzaShopServices(Ifile _fileService)
    {
      this.fileService=_fileService;
    }

    public List<PizzaShopObj> Get()
    {
      return fileService.readFromFile<PizzaShopObj>();
    }
    public PizzaShopObj? GetId(int id){
      List<PizzaShopObj> pizzas=fileService.readFromFile<PizzaShopObj>();
        foreach(var p in pizzas)
        {
            if(p.id==id)
            return p;
        }
        return null;
    }
    
    public  void Delete(int id)
    {List<PizzaShopObj> pizzas=fileService.readFromFile<PizzaShopObj>();
         foreach(var p in pizzas)
        {
            if(p.id==id)
               {pizzas.Remove(p);
               break;}

        }
     string json=JsonSerializer.Serialize(pizzas);
    fileService.WriteMessage(json);
    }

    public void Post(PizzaShopObj Pizza)
    { List<PizzaShopObj> pizzas=fileService.readFromFile<PizzaShopObj>();
    if(pizzas!=null)
       {Pizza.id=Counter++;
       pizzas.Add(Pizza);
       }
        else{
       pizzas=new List<PizzaShopObj>();
       pizzas.Add(Pizza);
       }
       string json=JsonSerializer.Serialize(pizzas);
        fileService.WriteMessage(json);
     }
    public  void Put(PizzaShopObj Pizza)
    {   List<PizzaShopObj> pizzas=fileService.readFromFile<PizzaShopObj>();
        var index=pizzas.FindIndex(p=>p.id==Pizza.id);
        pizzas[index]=Pizza;
        string json=JsonSerializer.Serialize(pizzas);
        fileService.WriteMessage(json);
    }

}

