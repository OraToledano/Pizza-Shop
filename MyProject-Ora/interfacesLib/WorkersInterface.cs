using modelsLib;

namespace interfacesLib;
public interface IWorkers
{

List<workerobj> Get();
void Post(workerobj worker);
void Put(workerobj worker);

  
}