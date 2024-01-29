using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using interfacesLib;
using modelsLib;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace PizzaShop_Ora.Controllers;


[ApiController]
[Route("[controller]")]
public class PizzaShopController : ControllerBase
{
    public PizzaShopController(IPizzaShopServices _pizza)
    {
        this.pizza=_pizza;
        _pizza.createDate=DateTime.Now;
        Console.WriteLine("from pizza shop"+_pizza.createDate);
    }   
    
private IPizzaShopServices pizza;
//Get
[HttpGet]
[Route("get")]
public ActionResult<List<PizzaShopObj>> Get()=>
pizza.Get();
    //Get by id
    [Range(0,100000,ErrorMessage ="the id is not valid")]
    private int _id;
    [HttpGet]
    [Route("getId/{id}")]
    
    public PizzaShopObj? GetId(int id) {
        _id=id;
      return pizza.GetId(_id);

    } 
    //Update
    [HttpPut]
    [Route("update")]   
   public void Put(PizzaShopObj Pizza)=>
   pizza.Put(Pizza);
   //new
     [HttpPost]
     [Route("new")]   
    public IActionResult Post(PizzaShopObj Pizza){
    pizza.Post(Pizza);
    return CreatedAtAction(nameof(Get),new{id=Pizza.id},Pizza);
     }

//delete
[Required]
private int d_id;
[HttpDelete]
 [Route("delete/{id}")]
 public void Delete(int id)
 { d_id=id;
    pizza.Delete(d_id);}
}
