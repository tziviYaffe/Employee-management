using Common.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public DateTime Created { get; set; }=DateTime.UtcNow;
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;


        //  יוצג שם המנהל אם יש
        public string? ManagerName { get; set; }

        //  יוצג שם התפקיד של העובד
        public string RoleName { get; set; }
    }

}
