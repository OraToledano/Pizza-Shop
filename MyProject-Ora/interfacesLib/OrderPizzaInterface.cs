using modelsLib;


namespace interfacesLib;

public interface IOrderPizza
{
  DateTime createDate{get;set;}
 void Post(OrderPizzaobj order);
  
}