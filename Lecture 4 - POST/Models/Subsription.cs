using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lecture4.Models
{
    public class Subsription
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name="Имя и фамилия")]
        public string Name { get; set; }

        [Display(Name="Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name="О себе")]
        [UIHint("MultilineText")]
        public string About { get; set; }

        [Display(Name="Образование")]
        [UIHint("Education")]
        public Education Education { get; set; }
    }
}