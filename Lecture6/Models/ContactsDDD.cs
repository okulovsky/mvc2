using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lecture06.Models
{
    public partial class ContactsDDD : IValidatableObject
    {
        const string EmailRegex = @"^\w+@\w+\.\w+$";
        const string PhoneRegex  = @"^\+\d{11}$";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(EMail) && string.IsNullOrWhiteSpace(Phone))
                yield return new ValidationResult("Нужно указать телефон или e-mail");
        }

        [Required(ErrorMessage = "Название улицы обязательно для заполнения")]
        public string Street { get; set; }
        [Range(1, 1000, ErrorMessage = "Номер дома должен от 1 до 1000")]
        public int House { get; set; }
        [RegularExpression(EmailRegex, ErrorMessage = "Неверный формат e-mail")]
        public string EMail { get; set; }
        [RegularExpression(PhoneRegex, ErrorMessage = "Неверный формат телефона")]
       
        public string Phone { get; set; }

        
    }
}
