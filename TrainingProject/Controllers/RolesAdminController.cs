using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{

    [Authorize(Roles ="admin")]
    public class RolesAdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: RolesAdmin
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        public ActionResult ListUsers(FormCollection form)
        {
            var users = context.Users.OrderBy(u => u.UserName).ToList();
            return View(users);
        }


        public ActionResult ManageUserRoles(FormCollection form)
        {
            UserRoleViewModel vm = new UserRoleViewModel();
           
            var userName = form["UserName"];

            var user = context.Users.Where(u => u.UserName == userName.Trim()).FirstOrDefault();

            if (user != null)
            {
                var roles = context.Roles.ToList();
                vm.UserName = userName;
                vm.UserId = user.Id;

                foreach(var item in roles)
                {
                    RoleAssignment roleAssignment = new RoleAssignment();
                    roleAssignment.Name = item.Name;
                    roleAssignment.Id = item.Id;
                    roleAssignment.isChecked = false;

                    if(user.Roles != null)
                    {
                        var roleIds = user.Roles.Select(r => r.RoleId).ToList();
                        if(roleIds.Contains(item.Id))
                        {
                            roleAssignment.isChecked = true;

                        }    
                        else
                        {
                            roleAssignment.isChecked = false;
                        }
                    }
                    vm.UserRoles.Add(roleAssignment);
                }
            }
            else
            {
                vm = null;
            }
            return View(vm); 

        }


        [HttpPost]
        public ActionResult UpdateRoles(UserRoleViewModel updateRoles)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userId = updateRoles.UserId;

            foreach (var item in updateRoles.UserRoles)
            {
                if(item.isChecked)
                {
                    if(!userManager.IsInRole(userId, item.Id))
                    {
                        userManager.AddToRole(userId, item.Name);
                    }
                }
                else if(userManager.IsInRole(userId, item.Name))
                {
                    userManager.RemoveFromRoles(userId, item.Name);
                }
            }
            return RedirectToAction("Index");
        }
    }
}