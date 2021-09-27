using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Context;
using TASK_BE.Models;

namespace TASK_BE.Repository.Data
{
    public class UnitRepository : GeneralRepository<Unit, int>
    {
        public UnitRepository(MyContext context) : base(context)
        {
        }
    }
}
