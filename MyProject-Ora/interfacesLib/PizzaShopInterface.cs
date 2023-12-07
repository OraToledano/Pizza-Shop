using modelsLib;

namespace interfacesLib;

public interface IPizzaShopServices
{
      DateTime createDate{get;set;}
PizzaShopObj? GetId(int id);
List<PizzaShopObj> Get();
void Put(PizzaShopObj Pizza);
void Delete(int id);
void Post(PizzaShopObj Pizza);
  
}