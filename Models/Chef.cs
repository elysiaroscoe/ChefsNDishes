using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Display(Name = "First Name: ")]
        [Required(ErrorMessage = "Please enter the chef's first name")]
        public string FirstName {get;set;}

        [Display(Name = "Last Name: ")]
        [Required(ErrorMessage = "Please enter the chef's last name")]
        public string LastName {get;set;}

        [Display(Name = "Date of Birth: ")]
        [Required(ErrorMessage = "Please enter the chef's birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday {get;set;}


        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;


        public List<Dish> CreatedDishes {get;set;}
    }
}