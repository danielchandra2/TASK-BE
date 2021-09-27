﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Repository.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using TASK_BE.Context;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using TASK_BE.Models;

namespace TASK_BE.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, TId> : ControllerBase
        where Entity : class
        where Repository : IGenericRepository<Entity, TId>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            try
            {
                var get = repository.GetAll();

                return Ok(new { Success = "true", Message = "Success", Data = get });
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException);
            }
        }


        [HttpGet("{id}")]
        public ActionResult Get(TId id)
        {
            try
            {
                var getById = repository.GetById(id);
                return Ok(getById);
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException);
            }
        }

        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            try
            {
                var result = repository.Post(entity) > 0 ? (ActionResult)Ok("Data has been successfully inserted.") : BadRequest("Data can't be inserted");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            try
            {
                var result = repository.Put(entity) > 0 ? (ActionResult)Ok("Data has been successfully updated.") : BadRequest("Data can't be updated.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(TId id)
        {
            try
            {
                var result = repository.Delete(id) > 0 ? (ActionResult)Ok("Data has been successfully deleted.") : BadRequest("Data can't be deleted.");
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
    }
}