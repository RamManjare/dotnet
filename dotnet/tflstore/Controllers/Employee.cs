
using System.ComponentModel.DataAnnotations;
namespace tflstore.Controllers;
//POCO  : Plain Old CLR Object
[Serializable]    //attribute  :Metadata
public class Employee
{

    public string firstname{get;set;}
    public string lastname{get;set;}
    public string contactnumber{get;set;}
     public string email{get;set;}

 public string password{get;set;}

    public Employee(){
               this.firstname="Seema";
        this.lastname="Mane";
        this.contactnumber="8956231245";
        this.email="a@gmail.com";
         this.password="5656";
    }
    public Employee(string firstname,string lastname,string contactnumber, string email,  string password){
        this.firstname=firstname;
        this.lastname=lastname;
        this.contactnumber=contactnumber;
        this.email=email;
         this.password=password;
    }
}
