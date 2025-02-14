using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; } //  הוספת מפתח ראשי
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        // קשר 1 - לכל תפקיד יש רשימת עובדים
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
