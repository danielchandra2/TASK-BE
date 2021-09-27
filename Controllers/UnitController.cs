using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Base;
using TASK_BE.Models;
using TASK_BE.Repository.Data;
using TASK_BE.Repository.Interfaces;

namespace TASK_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : BaseController<Unit, UnitRepository, int>
    {
        public UnitController(UnitRepository repository) : base(repository)
        {
        }
    }
}
