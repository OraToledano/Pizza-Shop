using Microsoft.AspNetCore.Mvc;
using modelsLib;
using interfacesLib;

namespace Workers.Controllers;



[ApiController]
[Route("[controller]")]
public class WorkersController : ControllerBase
{
    public WorkersController(IWorkers _worker)
    {this.worker=_worker;
        _worker.createDate=DateTime.Now;
        Console.WriteLine("from  worker"+_worker.createDate);
    }   
    
    private IWorkers worker;
//Get
     [HttpGet]
     [Route("get")]
  public List<workerobj> Get()=>
  worker.Get();

//Update
     [HttpPut]
    [Route("updatePrice/{worker}")]   
   public void Put(workerobj W)=>
   worker.Put(W);
}