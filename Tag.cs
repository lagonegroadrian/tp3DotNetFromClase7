using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase7
{

    public class Tag
    {
        public int id { get; set; }
        public string palabras { get; set; }
        
        public List<Post> posts;

        public int Comentarioid { get; set; }
        public Comentario Comentario { get; set; }
        

        public Tag(){}
    }
}
