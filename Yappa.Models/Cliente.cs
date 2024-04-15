using System;
using System.ComponentModel.DataAnnotations;

namespace Yappa.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string CUIT { get; set; }

        public string Domicilio { get; set; }

        [Required]
        public string TelefonoCelular { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
