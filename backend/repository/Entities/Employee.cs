using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;
    using System.ComponentModel;

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        private string _idNumber = string.Empty;

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "מספר תעודת זהות חייב להיות בדיוק 9 ספרות")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "תעודת זהות חייבת להכיל רק ספרות")]
        public string IdNumber
        {
            get => _idNumber;
            set
            {
                string numericValue = Regex.Replace(value, @"\D", ""); // שמירת ספרות בלבד
                _idNumber = numericValue.PadLeft(9, '0'); // השלמה עם 0 אם חסר
            }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        //  לכל עובד יש תפקיד אחד בלבד
        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public  Role Role { get; set; } = null!; // חובה

        //  מנהל העובד (אם יש)
        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public  Employee Manager { get; set; }

        //  עובדים תחת המנהל
        public virtual ICollection<Employee> Subordinates { get; set; } = new HashSet<Employee>();
    }


}
