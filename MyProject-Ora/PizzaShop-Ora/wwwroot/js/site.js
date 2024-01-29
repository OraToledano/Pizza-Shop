let basicUrl = 'https://localhost:7150/PizzaShop/';
let basicToken = "";
let Order = [{ Id: 0, Name: "oo", Price: 0, Gluten: true }];
let index = 0;
let CreditCardDetails = { CardNumber: 459, CardDateYear: 2010, Name: "Name" };
const orderUrl = "https://localhost:7150/OrderPizza/";
function openBox() {
    var modal = document.getElementById('id01');
    modal.style.display = "block";
}
function FinishOrder() {
    if (localStorage.getItem("orders") == null) {
        localStorage.setItem("orders", JSON.stringify(1));
    }
    else {
        let o = 0;
        o = JSON.parse(localStorage.getItem("orders"));
        localStorage.setItem("orders", JSON.stringify(o + 1));
    }
    var Name = document.getElementById("inpName").value.trim();
    let CardNumber = document.getElementById("inpNum").value.trim();
    let CardDateYear = document.getElementById("inpExp").value.trim();
    // var Name = prompt("insert Name on Card");
    // let CardNumber = prompt("insert Card Number");
    // var CardDateYear = prompt("insert card Exp Year ");
    var CostumerName = sessionStorage.getItem("name");
    var Id = localStorage.getItem("orders");
    CreditCardDetails = { CardNumber: CardNumber, CardDateYear: CardDateYear, Name: Name };
    let sum = 0;
    Order.forEach(element => {
        sum = sum + element.Price;
    });
    fetch(`${orderUrl}order`,
        {
            method: 'post',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify({
                "CostumerId": Id, "CostumerName": CostumerName, "TotalPrice": sum,
                "ListP": Order, "CreditCardDetails": CreditCardDetails
            })
        })
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error in root in post', error));
    alert("ההזמנה בוצעה בהצלחה");
    Order = [{ Id: 0, Name: "oo", Price: 0, Gluten: true },];
    index = 0;
    document.getElementById("orderBody").innerHTML = "";
    var modal = document.getElementById('id01');
    modal.style.display = "none";

}
function Get() {
    fetch(`${basicUrl}get/`)
        .then((res) => res.json())
        .then((data) => fillPizzaList(data))
        .catch(err => { console.log(err) })
}
function fillPizzaList(pizzaList) {
    var tbody = document.getElementById('pizzatbody');
    tbody.innerHTML = "";
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
function Post() {
    var name = prompt("insert name");
    var price = prompt("insert price");
    var gluten = prompt("if not contain gluten insert 0, else everything");
    if (gluten == 0)
        gluten = true;
    else
        gluten = false;
    const myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");
    fetch(`${basicUrl}new`,
        {
            method: 'post',
            mode: 'cors',
            headers: myHeaders,
            body: JSON.stringify({ "id": 0, "name": `${name}`, "price": price, "gluten": gluten })
        })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error in root in post', error));
}
function GetId() {
    let id = prompt("insert number");
    fetch(`${basicUrl}getId/${id}`,
        {
            method: 'GET',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
        })
        .then(response => response.json())
        .then(result => printGetId(result))
        .catch(error => console.log('error', error));
}
function printGetId(result) {
    let myOrder = { Id: result.id, Name: result.name, Price: result.price, Gluten: result.gluten };
    document.getElementById("orderBody").innerHTML += " שם המוצר:" + result.name + ", קוד המוצר:" + result.id + ", מחיר המוצר:" + result.price + `<br>`;
    Order[index++] = myOrder;
}
function Put() {

    var id = prompt("insert id");
    var name = prompt("insert name");
    var price = prompt("insert price");
    var gluten = prompt("if not contain gluten insert 0, else everything");
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");

    if (gluten == 0)
        gluten = true;
    else
        gluten = false;
    fetch(`${basicUrl}update`,
        {
            method: 'Put',
            mode: 'cors',
            headers: myHeaders,
            body: JSON.stringify({ "id": id, "name": `${name}`, "price": price, "gluten": gluten })
        })
        .then(res => console.log(res))
        .catch(error => console.log('error', error));
}
function Delete() {
    let id = prompt("insert id");
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");
    fetch(`${basicUrl}delete/${id}`,
        {
            method: 'Delete',
            mode: 'cors',
            headers: myHeaders,
        })
        .then(res => console.log(res))
        .catch(error => console.log('error', error));
}
const url = 'https://localhost:7150/Login';
function Login() {
    sessionStorage.clear();
    var myHeaders = new Headers();
    const name = document.getElementById('usrname').value.trim();
    sessionStorage.setItem("name", name);
    const password = document.getElementById('psw').value.trim();
    var theSite = document.getElementById("theSite");
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({
        Name: name,
        Password: password
    })
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: raw,
        redirect: "follow",
    };
    fetch(`${url}/Login`, requestOptions)
        .then((response) => response.text())
        .then((result) => {
            basicToken = result;
            // alert(basicToken);
            if (basicToken.toString().includes("Microsoft.Asp")) {
                document.getElementById("h1").innerHTML = "HI "+ name +"! yo are client" ;
            }
            else {
                document.getElementById("h1").innerHTML = "HI " + name+"! you are worker";
            }
            document.getElementById("container").innerHTML = "";
            document.getElementById("container").style.display = "none";
            theSite.style.display = "block";

        }).catch((error) => alert("error", error));
}
const workerUrl = "https://localhost:7150/Workers/";
function addWorker() {
    var name = prompt("insert name");
    var role = prompt("insert Role");
    var password = prompt("insert password");
    const myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + basicToken);
    myHeaders.append("Content-Type", "application/json");
    fetch(`${workerUrl}add`,
        {
            method: 'post',
            mode: 'cors',
            headers: myHeaders,
            body: JSON.stringify({ "id": 0, "name": `${name}`, "role": role, "password": password })
        })
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error in root in post', error));
}