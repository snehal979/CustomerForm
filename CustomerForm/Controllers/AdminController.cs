using CustomerForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CustomerForm.Controllers
{
    [Authorize(Roles = ApplicationUser.Admin)]
    public class AdminController : Controller
    {
        
    }
   
}
