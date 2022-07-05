using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clase7
{
    public class UsuarioAmigo
    {
        public int num_usr { get; set; }
        [ForeignKey(nameof(num_usr))]
        public Usuario user { get; set; }
        public int num_usr2 { get; set; }
        [ForeignKey(nameof(num_usr2))]
        public Usuario amigo { get; set; }

        public UsuarioAmigo() { }

        public UsuarioAmigo(Usuario ppal, Usuario segundo)
        {
            user = ppal;
            amigo = segundo;
        }
    }
}
