using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TpPrevio.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Ingrese username")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage ="Ingrese password")]
        //[Required]   
        [StringLength(100,ErrorMessage ="Password debe ser al menos de 6 caracteres",MinimumLength =6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}