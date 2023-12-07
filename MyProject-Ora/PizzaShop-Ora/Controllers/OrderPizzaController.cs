using Microsoft.AspNetCore.Mvc;
using modelsLib;
using interfacesLib;
namespace OrderPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderPizzaController : ControllerBase
{  
    private IOrderPizza _order;

    public OrderPizzaController(IOrderPizza order)
    { 
        _order=order;
        _order.createDate=DateTime.Now;
        Console.WriteLine("from order pizza"+_order.createDate);
    }   

     [HttpPost]
     [Route("new/{order}")]   
     public void Post(OrderPizzaobj order)=>
     _order.Post(order);



}
