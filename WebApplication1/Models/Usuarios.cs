using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//esto es para hacer posible las validaciones
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Usuarios
    {
        [Required]
        public int userid { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string pass { get; set; }
        [Required]
        public string nivel { get; set; }

        public Usuarios()
        {
            //code
        }
        public Usuarios(int id, string us, string contra, string nivel)
        {
            this.userid = id;
            this.username = us;
            this.pass = contra;
            this.nivel = nivel;
        }


    }
}