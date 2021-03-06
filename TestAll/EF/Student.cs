//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestAll.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student
    {
        [Required, RegularExpression(@"^([a-zA-Z\s]+)$", ErrorMessage = "Name must be alphabatic")]
        public string Name { get; set; }
        public int Serial { get; set; }

        [Required, RegularExpression(@"^([0-9]{2}-[0-9]{5}-[1-3]{1})+$", ErrorMessage = "Id must be xx-xxxxx-x this format")]
        public string Id { get; set; }
        [Required]
        public string Dob { get; set; }

        [Required, RegularExpression(@"^((male)|(female)|(other))+$")]
        public string Gender { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, RegularExpression(@"^((cs)|(eee))+$")]
        public string Dept { get; set; }
    }
}
