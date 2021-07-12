using CrudOperations.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = CrudOperations.Model.Task;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly TODO _TODOService;

        public ListController(TODO TODOService)
        {
            _TODOService = TODOService;
        }

        [HttpGet]
        public ActionResult<List<Task>> Get()
        {
            return _TODOService.Get();
        }
       
    }
}
