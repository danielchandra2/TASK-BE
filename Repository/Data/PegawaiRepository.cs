using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_BE.Context;
using TASK_BE.Models;

namespace TASK_BE.Repository.Data
{
    public class PegawaiRepository : GeneralRepository<Pegawai, int>
    {
        public PegawaiRepository(MyContext context) : base(context)
        {
        }
    }
}
