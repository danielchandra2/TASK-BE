using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_BE.Models
{
    [Table("TB_M_Unit")]
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="Panjang nama unit tidak boleh lebih dari 20!!!")]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
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
        public ICollection<Pegawai> Pegawai { get; set; }
    }
}
