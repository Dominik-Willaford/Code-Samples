using CodeSamples.Models;
using CodeSamples.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeSamples.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseFunctionService _databaseFunctionService;
        public HomeController(IDatabaseFunctionService databaseFunctionService)
        {
            _databaseFunctionService = databaseFunctionService;
        }
        public ActionResult Index()
        {            
            return View(_databaseFunctionService.GetEntries());
        }

        public ActionResult GetPartialView()
        {
            return PartialView("_UsersTable",_databaseFunctionService.GetEntries());
        }

        [HttpPost]
        public void AddUserToDB(UserInfo model)
        {
            _databaseFunctionService.CreateEntry(model);
        }

        
        public string GetUsers()
        {
            List<UserInfo> users = _databaseFunctionService.GetEntries();
            return JsonConvert.SerializeObject(users);
        }
    }
}