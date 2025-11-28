using BadeePlatform.DTOs;
using BadeePlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadeePlatform.Controllers
{
    public interface IParentController
    {
        public IActionResult Index();
        public IActionResult Register();
        public IActionResult Login();
        public Task<IActionResult> Register(RegisterParentDTO dto);
        public Task<IActionResult> Login(LoginParentDTO dto);
        public IActionResult AddChild(Child child);
        public IActionResult EditChildProfile();
        public Task<IActionResult> DeleteChildProfile(string childId);
        public IActionResult ViewChildProfile();
        public IActionResult ViewChildDashboard();

        public IActionResult viewParentHomePage();




    }
}
