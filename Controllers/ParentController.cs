using BadeePlatform.Data;
using BadeePlatform.Models;
using BadeePlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BadeePlatform.Controllers
{
    public class ParentController : Controller
    {
        private readonly IChildService _childService;

        public ParentController(IChildService childService)
        {
            _childService = childService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();

        }

        public IActionResult Login()
        {
            return View();

        }

        public IActionResult AddChild(Child child)
        {
            return View();

        }

        public IActionResult EditChildProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteChildProfile(String childId)
        {

            var parentId = HttpContext.Session.GetString("ParentId");

            if (string.IsNullOrEmpty(parentId))
            {
                return RedirectToAction("Login");
            }

            try {
                bool success = await _childService.DeleteChildProfileAsync(parentId, childId);

                if (!success)
                {
                    TempData["DeleteChildError"] = "الطفل غير موجود في قائمتك";
                    return RedirectToAction("ManageMultipleChildren");
                }

                TempData["DeleteChildSuccess"] = "تم حذف الطفل برقم الهوية " + childId + " بنجاح";
                return RedirectToAction("ManageMultipleChildren");
            }
            catch
            {
                TempData["DeleteChildError"] = "حدث خطأ غير متوقع أثناء عملية الحذف. الرجاء المحاولة لاحقاً.";
                return RedirectToAction("ManageMultipleChildren");
            }
            }

        public IActionResult ViewChildProfile()
        {
            return View();

        }

        public IActionResult ViewChildDashboard()
        {
            return View();

        }

    }
}
