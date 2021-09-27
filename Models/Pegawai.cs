using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_BE.Models
{
    [Table("TB_M_Pegawai")]
    public class Pegawai
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Panjang nama tidak boleh lebih dari 30 !!!")]
        public string Name { get; set; }
        [Required]
        public int Unit_Id { get; set; }
        [ForeignKey("Unit_Id")]
        [Required]
        public DateTime Created_At { get; set; }
        [Required]
        public string Created_By { get; set; }
        [Required]
        public Boolean IsActive { get; set; }
        [Required]
        public DateTime Update_At { get; set; }
        [Required]
        public string Update_By { get; set; }
        [Required]
        public Boolean IsDelete { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Panjang Password tidak boleh lebih dari 20 !!!")]
        public string Password { get; set; }
        public Unit Units { get; set; }
    }
}
