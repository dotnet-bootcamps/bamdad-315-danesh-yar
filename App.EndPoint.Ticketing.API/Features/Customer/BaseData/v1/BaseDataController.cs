using App.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.Ticketing.API.Features.Customer.BaseData.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseDataController : ControllerBase
{
    [HttpGet("[action]")]
   
    public IActionResult GetTicketCategoris()
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {Id=1,Name="rasool",Age=38,Contacts=new List<Contact>()
            {
                new Contact(){Id=1,PhoneNO=123346},
                new Contact(){Id=2,PhoneNO=12234456},
                new Contact(){Id=3,PhoneNO=12234456},
                new Contact(){Id=4,PhoneNO=126677456},
            },
            },
            new Student()
            {Id=2,Name="reza",Age=34,Contacts=new List<Contact>()
            {
                new Contact(){Id=5,PhoneNO=123346},
                new Contact(){Id=6,PhoneNO=12234456},
                new Contact(){Id=7,PhoneNO=12234456},
                new Contact(){Id=8,PhoneNO=126677456},
            },
            }
        };
        

        var result = students.SelectMany(student => new Student().Contacts).ToList();

        return Ok();
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Contact> Contacts { get; set; }
}

public class Contact
{
    public int Id { get; set; }
    public int PhoneNO { get; set; }
}
