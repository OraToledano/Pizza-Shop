using modelsLib;

namespace interfacesLib;
public interface IWorkers
{
public  DateTime createDate{get;set;}
List<workerobj> Get();
void Put(workerobj worker);

  
}