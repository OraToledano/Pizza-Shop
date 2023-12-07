
 using modelsLib;
 using interfacesLib;


namespace servicesLib;

public  class WorkersService :IWorkers
{
    static List<workerobj> workers {get;}

 public DateTime createDate{get;set;}

    static WorkersService()
    {
      workers=new List<workerobj>{
        new workerobj {id=0,name="avi",salary=7000,phone="0555569874"},
       new workerobj {id=1,name="eli",salary=5500,phone="0555789432"},
        new workerobj {id=2,name="ari",salary=5900,phone="0553697845"},
      };
    }

    public List<workerobj> Get()
    {
      return workers;
    }
    
    public  void Put(workerobj worker)
    {   
        var index=workers.FindIndex(p=>p.id==worker.id);
        workers[index]=worker;
    }
    
    



}

