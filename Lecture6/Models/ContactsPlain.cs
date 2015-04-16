using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lecture06.Models
{
    public partial class ContactsPlain : IValidatableObject
    {
        const string EmailRegex = @"^\w+@\w+\.\w+$";
        const string PhoneRegex = @"^\+\d{11}$";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Street))
                yield return new ValidationResult("Поле является обязательным", new[] { "Street" });
            if (House < 1 || House > 1000)
                yield return new ValidationResult("Номер дома должен быть от 1 до 1000", new[] { "House" });
            if (EMail != null && !new Regex(EmailRegex).Match(EMail).Success)
                yield return new ValidationResult("Неверный формат электронной почты", new[] { "EMail" });
            if (Phone != null && !new Regex(PhoneRegex).Match(Phone).Success)
                yield return new ValidationResult("Неверный формат телефона", new[] { "Phone" });
            if (string.IsNullOrWhiteSpace(EMail) && string.IsNullOrWhiteSpace(Phone))
                yield return new ValidationResult("Нужно указать телефон или e-mail");
        }


        public string Street { get; set; }
        public int House { get; set; }
        public string EMail { get; set; }

        public string Phone { get; set; }
    }
}