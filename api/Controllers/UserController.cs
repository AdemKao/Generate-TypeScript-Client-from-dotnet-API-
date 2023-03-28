using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private List<UserModel> userList = new List<UserModel>(){
        new UserModel(){

            Name = "Adem",
            Email= "adem@pic.net"
        },
        new UserModel(){
            Name="Ted",
            Email = "ted@pic.net"
        }
    }

    ;

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUser")]
    public IEnumerable<UserModel> Get()
    {
        return userList;
        // yield return new UserModel() { Name = "Adem" };
    }
}

