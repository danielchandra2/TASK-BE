using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Base;
using TASK_BE.Context;
using TASK_BE.Models;
using TASK_BE.Repository.Data;
using TASK_BE.Repository.Interfaces;
using TASK_BE.Services;
using TASK_BE.ViewModels;

namespace TASK_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : BaseController<Pegawai, PegawaiRepository, int>
    {
        private readonly PegawaiRepository repository;
        private readonly IGenericDapper dapper;
        private readonly MyContext context;
        private readonly IConfiguration config;
        public PegawaiController(PegawaiRepository repository, IGenericDapper dapper, MyContext context, IConfiguration config) : base(repository)
        {
            this.repository = repository;
            this.dapper = dapper;
            this.context = context;
            this.config = config;
        }

        [HttpPost("login")]
        public IActionResult LoginUser(Login login)
        {
            var jwt = new JwtService(config);
            try
            {
                var dbparams = new DynamicParameters();
                dbparams.Add("Name", login.Name, DbType.String);
                dynamic result = dapper.Get<dynamic>(
                    "[dbo].[SP_Login]",
                    dbparams,
                    CommandType.StoredProcedure
                    );

                if (login.Password == result.Password)
                {
                    var token = jwt.GenerateSecurityToken(result.Name, result.Password);
                    return Ok(token);
                }

                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("ListPegawai")]
        [Authorize]
        public List<dynamic> ListPegawai()
        {
            try
            {
                var dbparams = new DynamicParameters();
                List<dynamic> result = dapper.GetAll<dynamic>(
                    "[dbo].[SP_ListPegawai]",
                    dbparams,
                    CommandType.StoredProcedure
                    );
               
                    return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
