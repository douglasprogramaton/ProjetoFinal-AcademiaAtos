﻿using ControleDeContatos.Enuns;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        [EmailAddress(ErrorMessage = "E-mail inválido ")]
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio!")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
