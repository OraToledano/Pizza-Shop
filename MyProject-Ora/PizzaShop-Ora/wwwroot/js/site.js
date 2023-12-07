//  let basicUrl='https://localhost:7150/PizzaShop/';
// function fillPizzaList(pizzaList) {
//     var tbody=document.getElementById('pizzatbody');
//     tbody.innerHTML=" ";
//     pizzaList.forEach(pizza => {
//         tbody.innerHTML+=`<tr>
//         <td> ${pizza.name}</td>
//         <td>${pizza.gluten}</td>
//         <td>${pizza.price}</td>
//         <td>${pizza.id}</td>
//         </tr>`
//         tbody.append();
//     });
// }

// function Get() {
//         fetch(`${basicUrl}get`)
//         .then((res) => res.json()) 
//         .then((data) =>  fillPizzaList(data)) 
//          .catch(err=>{console.log(err)})
//     }
// function Post() {
// fetch(`${basicUrl}new` ,
// { method : 'post', 
// mode: 'cors',
//  headers: { 'Content-Type': 'application/json',
// 'Accept' : 'application/json' 
//  }, 

let basicUrl='https://localhost:7150/PizzaShop/';
function printGetId(result)
    {
        document.getElementById("getId").innerHTML+="name:"+result.name+" ,id:"+result.id+`<br>`;
    
    }

function Get(params) {
    fetch(`${basicUrl}get/`)
    .then((res) => res.json()) 
    .then((data) =>  fillPizzaList(data)) 
     .catch(err=>{console.log(err)})
}
function fillPizzaList(pizzaList) {
    var tbody=document.getElementById('pizzatbody');
    tbody.innerHTML="";
    pizzaList.forEach(pizza => {
        tbody.innerHTML +=
        `<tr>
        <td>${pizza.name}    </td>
        <td>${pizza.gluten}</td>
        <td>${pizza.price}</td>
        <td>${pizza.id}</td>
        </tr>`
    });
}
function Post(){
    var id=prompt("insert id");
    var name=prompt("insert name");
    var price=prompt("insert price");
    var gluten=prompt("if not contain gluten insert 0, else everything");
    if(gluten==0)
     gluten=true;
    else
    gluten=false;

fetch(`${basicUrl}new`, 
{
    method : 'post', 
    mode: 'cors',
    headers: { 'Content-Type': 'application/json', 
    'Accept' : 'application/json'
 }, 
body: JSON.stringify({"id":id,"name":`${name}`,"price":price,"gluten":gluten}) })
  .then(response => response.json())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));
}
function GetId(){
let id=prompt("insert number");
    fetch(`${basicUrl}getId/${id}`, 
    {
        method : 'GET', 
        mode: 'cors',
        headers: { 'Content-Type': 'application/json', 
        'Accept' : 'application/json'
     }, 
     })
      .then(response => response.json())
      .then(result => printGetId(result))
      .catch(error => console.log('error', error));
    }
    function Put(){
        var id=prompt("insert id");
        var name=prompt("insert name");
        var price=prompt("insert price");
        var gluten=prompt("if not contain gluten insert 0, else everything");
        if(gluten==0)
         gluten=true;
        else
        gluten=false;
        fetch(`${basicUrl}update`, 
        {
            method : 'Put', 
            mode: 'cors',
            headers: { 'Content-Type': 'application/json', 
            'Accept' : 'application/json'
         }, 
        body: JSON.stringify({"id":id,"name":`${name}`,"price":price,"gluten":gluten}) })
          .then(res => console.log(res))
          .catch(error => console.log('error', error));
        }
        function Delete()
        {
            let id=prompt("insert id");
            fetch(`${basicUrl}delete/${id}`, 
            {
                method : 'Delete', 
                mode: 'cors',
                headers: { 'Content-Type': 'application/json', 
                'Accept' : 'application/json'
             }, 
             })
              .then(res => console.log(res))
              .catch(error => console.log('error', error));
        }

