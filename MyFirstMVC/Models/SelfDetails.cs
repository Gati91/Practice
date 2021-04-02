using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Helper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyFirstMVC.Models
{
    public class SelfDetails
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="DOB")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [StringLength(20, MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]        
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string ContactNum { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Gender")]
        public Gender gender { get; set; }
        [Required]
        public List<DomainAreas> domainAreas { get; set; }
        
        public string HighPriorityReason { get; set; }

        public bool IsMale { get; set; }
    }

    public class DomainAreas
    {
        public int DomainID { get; set; }
        public string DomainName { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
