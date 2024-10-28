using DataAccess2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MVCshop.Controllers
{
    public class UserDetailController : Controller
    {

        private readonly IRepository repo;

        public UserDetailController(IRepository repo) {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<DataAccess2.Models.UserDetail> userslist = repo.getAllUsers().ToList();

            List<MVCshop.Models.UserDetail> mvclist = new List<Models.UserDetail>();

            foreach (DataAccess2.Models.UserDetail user in userslist) {
                MVCshop.Models.UserDetail mvcuser = new Models.UserDetail();

                mvcuser.id = user.id;
                mvcuser.FirstName = user.FirstName;
                mvcuser.LastName = user.LastName;
                mvcuser.EmailId = user.EmailId;
                mvcuser.Password = user.Password;

                mvclist.Add(mvcuser);

            }

            return View(mvclist);
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MVCshop.Models.UserDetail mvcuser)
        {
            if (ModelState.IsValid)
            {
                DataAccess2.Models.UserDetail user = new DataAccess2.Models.UserDetail();

                user.id = mvcuser.id;
                user.FirstName = mvcuser.FirstName;
                user.LastName = mvcuser.LastName;
                user.EmailId = mvcuser.EmailId;
                user.Password = mvcuser.Password;

                bool result = repo.AddUser(user);
            }
            return RedirectToAction("Index", "UserDetail");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DataAccess2.Models.UserDetail user = repo.getUserById(id);

            MVCshop.Models.UserDetail mvcuser = new Models.UserDetail();

            mvcuser.id = user.id;
            mvcuser.FirstName = user.FirstName;
            mvcuser.LastName = user.LastName;
            mvcuser.EmailId = user.EmailId;
            mvcuser.Password = user.Password;   

            return View(mvcuser);
        }

        [HttpPost]
        public IActionResult Edit(MVCshop.Models.UserDetail mvcuser)
        {
            if (ModelState.IsValid) {
                DataAccess2.Models.UserDetail user = new DataAccess2.Models.UserDetail();

                user.id = mvcuser.id;
                user.FirstName = mvcuser.FirstName;
                user.LastName = mvcuser.LastName;
                user.EmailId = mvcuser.EmailId;
                user.Password = mvcuser.Password;

                bool result = repo.UpdateUser(user);
            }
            return RedirectToAction("Index", "UserDetail");
        }

        
    }
}
