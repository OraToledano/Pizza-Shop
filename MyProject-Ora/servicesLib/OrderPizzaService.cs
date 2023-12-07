using interfacesLib;
using modelsLib;

namespace servicesLib;

public  class OrderPizzaService : IOrderPizza
{
    static List<OrderPizzaobj> Orders {get;}
     
    static int Counter =1;
    public DateTime createDate{get;set;}

    static OrderPizzaService()
    {
      Orders=new List<OrderPizzaobj>{
        new OrderPizzaobj {id=0,costumerName="Moshe",TotalPrice=56.9,ListP=new List<PizzaShopObj>{
            new PizzaShopObj{id=7,name="nonGluten",price=23.6,gluten=false},
            new PizzaShopObj{id=8,name="sharp",price=39.8,gluten=true}
        }}
      };
    }
    
    public void Post(OrderPizzaobj order)
    {  order.id=Counter++;
        Orders.Add(order);
         
    }



}

