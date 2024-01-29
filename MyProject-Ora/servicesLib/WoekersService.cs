
 using modelsLib;
 using interfacesLib;
using FileService;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace servicesLib;

public  class WorkersService :IWorkers
{

      private IWorker FileService{get;set;}
   
    public WorkersService(IWorker _fileService)
    {
      this.FileService=_fileService;
    }
    public List<workerobj> Get()
    {
       return FileService.ReadFromFile<workerobj>(); 
    }
    public  void Put(workerobj worker)
    {   
      List<workerobj> workers=FileService.ReadFromFile<workerobj>();
        var index=workers.FindIndex(p=>p.Id==worker.Id);
        workers[index]=worker;
        string json=JsonSerializer.Serialize(workers);
        FileService.WriteMessage(json);
    } 
    public  void Post(workerobj worker)
    {   
      List<workerobj> workers=FileService.ReadFromFile<workerobj>();
        // var index=workers.FindIndex(p=>p.Id==worker.Id);
        var index=(workers.Last().Id)+1;
        worker.Id=index;
         workers.Add(worker);
        string json=JsonSerializer.Serialize(workers);
        FileService.WriteMessage(json);
    }
    
}