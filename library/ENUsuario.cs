using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENUsuario
    {
        private string nif;
        private string nombre;
        private int edad;

        //propiedades publicas para exponer el estado del producto
        public string nifUsuario { get { return nif; } set { nif = value; } }
        public string nombreUsuario { get { return nombre; } set { nombre = value; } }
        public int edadUsuario { get { return edad; } set { edad = value; } }


        public ENUsuario()
        {
            nif = nombre= "";
            edad = 0;

        }
        public ENUsuario(string nif, string nombre, int edad)
        {
            this.nif = nif;
            this.nombre = nombre;
            this.edad = edad;

        }
        public bool createUsuario()
        {
            CADUsuario c = new CADUsuario();

            return c.createUsuario(this);            ;

        }

        public bool readUsuario()
        {
            CADUsuario c = new CADUsuario();
            
            return c.readUsuario(this); 
        }

        public bool readFirstUsuario()
        {
            CADUsuario c = new CADUsuario();

            return c.readFirstUsuario(this);

        }

        public bool readNextUsuario()
        {
            CADUsuario c = new CADUsuario();

            if (c.readUsuario(this))
                return c.readNextUsuario(this);

            return false;
        }

        public bool readPrevUsuario()
        {
            CADUsuario c = new CADUsuario();
            ENUsuario auxUsuario = new ENUsuario(nif, nombre, edad);

            if (c.readFirstUsuario(auxUsuario) && nifUsuario != auxUsuario.nifUsuario)
                return c.readPrevUsuario(this);

            return false;
        }

        public bool updateUsuario()
        {
            ENUsuario auxUsuario = new ENUsuario(this.nif, this.nombre, this.edad);
            CADUsuario c = new CADUsuario();

            if (c.readUsuario(this))
            {
                this.nombre = auxUsuario.nombre;
                this.nif = auxUsuario.nif;
                this.edad = auxUsuario.edad;
                return c.updateUsuario(this);
            }

            return false;


        }
        public bool deleteUsuario()
        {
            CADUsuario c = new CADUsuario();

            if (c.readUsuario(this))
                return c.deleteUsuario(this);

            return false;


        }

    }
}
