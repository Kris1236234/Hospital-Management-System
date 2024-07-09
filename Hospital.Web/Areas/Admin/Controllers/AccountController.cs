using Hospital.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Hospital.Repositories.Interfaces;

public class AccountController : Controller
{
    private readonly IUserRepository _userRepository;

    public AccountController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public IActionResult Login(Login model)
    {
        var user = _userRepository.GetUserByLogin(model.LoginName);

        if (user != null)
        {
            string savedPassword = user.PasswordHash; 
         
        }


        return RedirectToAction("Login");
    }
}
