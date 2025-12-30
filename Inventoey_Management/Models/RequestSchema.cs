using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inventoey_Management.Models
{
    public class RequestSchema
    {
        public int Id { get; set; }
        public string Status { get; set; } = "newRequest";
        [Required(ErrorMessage = "اسم الموظف مطلوب")]
        public string ClientName { get; set; } = string.Empty;
        [Required(ErrorMessage = "رقم الموظف مطلوب"), RegularExpression(@"^[0-9]+", ErrorMessage = "رقم التواصل يحتوي ارقاما فقط")]
        public string ClientPhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "قسم الموظف مطلوب")]
        public string Department { get; set; } = string.Empty;
        [Required(ErrorMessage = "رقم المبنى مطلوب")]
        public int BuildingNumber { get; set; } 
        [Required(ErrorMessage = "اسم المبنى مطلوب")]
        public string BuildingName { get; set; } = string.Empty;
        [Required(ErrorMessage = "رقم المكتب مطلوب")]
        public string OfficeNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "نوع الجهاز مطلوب")]
        public string MachineType { get; set; } = string.Empty;
        [Required(ErrorMessage = "كود الجهاز مطلوب")]
        public string MachineCode { get; set; } = string.Empty;
        public string SpareCode { get; set; } = " - ";
        public string Note { get; set; } = string.Empty;
        public string TechnicianName { get; set; } = string.Empty;
        public string TechnicianPhoneNumber { get; set; } = string.Empty;

    }
}
