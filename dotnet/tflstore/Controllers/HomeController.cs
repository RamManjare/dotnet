using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tflstore.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
namespace tflstore.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        Console.WriteLine("Home Controller instance initialized......");
        _logger = logger;
    }

    //Action Methods

    public IActionResult Index()
    {
        Console.WriteLine("Invoking Home Controller index method.. ");
        return View();
    }

    public IActionResult Privacy()
    {
        Console.WriteLine("Invoking Home Controller Privacy method. ");
        return View();
    }

    public IActionResult Login(){
         Console.WriteLine("Invoking Home Controller Login method. ");
       

        return View();
    }

public IActionResult postregister(string firstname,string lastname,string contactnumber,string email, string password){
    
        Employee e1=new Employee(firstname,lastname,contactnumber, email,  password);
        
       try{
        string fileName=@"D:\Ram_Sagar\dotnet\employee.json";
        string jsonString = System.IO.File.ReadAllText(fileName);
        List<Employee> emp = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        
           emp.Add(e1);
      
            // dynamic data type variable
            var options=new JsonSerializerOptions {IncludeFields=true};
            var empJson=JsonSerializer.Serialize<List<Employee>>(emp,options);
         
            System.IO.File.WriteAllText(fileName,empJson);
         //   Deserialize from JSON file
             jsonString = System.IO.File.ReadAllText(fileName);
            List<Employee> jsonEmp = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
            
    }
   catch(Exception exp){
    
    }
    finally{ }
        return View();
    }
    
    public IActionResult Validate(string email, string password){

         Console.WriteLine("Validating User credentials.... ");
        string fileName=@"D:\Ram_Sagar\dotnet\employee.json";
        string jsonString = System.IO.File.ReadAllText(fileName);
          Console.WriteLine(jsonString);
            List<Employee> jsonEmp1 = JsonSerializer.Deserialize<List<Employee>>(jsonString);
            Console.WriteLine("\n JSON :Deserializing data from json file\n \n");
            foreach( Employee e in jsonEmp1)
            {
                Console.WriteLine($"{e.firstname} : {e.email}");  
               
               String em=$"{e.email}";
               string p=$"{e.password}";

        if(email ==em && 
           password==p){
             Console.WriteLine("successfull validation of user..... ");
             Console.WriteLine("Redirecting to welcome..... ");   
            return Redirect("/home/Welcome");
           }
            }
        return View();
    }
    
    public IActionResult Welcome(){
         Console.WriteLine("Invoking Home Controller Welcome  method. ");
       
        return View();
    }

    public IActionResult Register(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
