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
        public Task<IActionResult> AddChild();
        public Task<IActionResult> AddChild(AddChildDTO dto);
        public Task<IActionResult> DeleteChildProfile(string childId);
        public Task<IActionResult> ViewChildProfile(string childId);
        public IActionResult ViewChildDashboard();
        public IActionResult ViewParentHomePage();

        public Task<IActionResult> GetSchoolsByCity(string city);

        public Task<IActionResult> GetGradesBySchool(string schoolId);

        public Task<IActionResult> GetClassesByGrade(string gradeId);





    }
}
