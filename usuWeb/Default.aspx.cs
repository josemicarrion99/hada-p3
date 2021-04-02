using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using library;

namespace usuWeb
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarMensaje.Text = "";
        }

        protected void CrearUsuario(object sender, EventArgs e)
        {
            if (NIFTextBox.Text != "" && EdadTextBox.Text != "" && NombreTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario(NIFTextBox.Text, NombreTextBox.Text, int.Parse(EdadTextBox.Text));

                if (en.createUsuario())
                    mostrarMensaje.Text = "Usuario " + en.nombreUsuario + " creado con éxito.";
                else
                    mostrarMensaje.Text = "Error creando usuario";
            }
            else
            {
                mostrarMensaje.Text = "Error, revisa los campos rellenados";
            }


        }

        protected void LeerUsuario(object sender, EventArgs e)
        {
            if (NIFTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario();
                en.nifUsuario = NIFTextBox.Text;

                if (!en.readUsuario())
                    mostrarMensaje.Text = "No existe dicho usuario";
                else
                {
                    NombreTextBox.Text = en.nombreUsuario;
                    EdadTextBox.Text = en.edadUsuario.ToString();
                    NIFTextBox.Text = en.nifUsuario;
                    mostrarMensaje.Text = "Usuario encontrado: ";
                }
            }
            else
            {
                mostrarMensaje.Text = "No se ha introducido un NIF";
            }
        }

        protected void LeerPrimerUsuario(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
                if (!en.readFirstUsuario())
                    mostrarMensaje.Text = "BD vacia, por favor introduzca usuarios";
                else
                {
                    NombreTextBox.Text = en.nombreUsuario;
                    EdadTextBox.Text = en.edadUsuario.ToString();
                    NIFTextBox.Text = en.nifUsuario;
                    mostrarMensaje.Text = "Primer usuario encontrado: ";

                }
        }

        protected void LeerSiguienteUsuario(object sender, EventArgs e)
        {

            if (NIFTextBox.Text != "" && EdadTextBox.Text != "" && NombreTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario(NIFTextBox.Text, NombreTextBox.Text, int.Parse(EdadTextBox.Text));
                
                if (!en.readNextUsuario())
                    mostrarMensaje.Text = "O ha introducido el ultimo usuario o no hay usuarios o no existe el usuario";
                else
                {
                    NombreTextBox.Text = en.nombreUsuario;
                    EdadTextBox.Text = en.edadUsuario.ToString();
                    NIFTextBox.Text = en.nifUsuario;
                    mostrarMensaje.Text = "Siguiente usuario encontrado: ";

                }
            }
            else
            {
                mostrarMensaje.Text = "No se ha introducido un NIF";
            }
        }

        protected void LeerAnteriorUsuario(object sender, EventArgs e)
        {

            if (NIFTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario(NIFTextBox.Text, NombreTextBox.Text, int.Parse(EdadTextBox.Text));

                if (en.readPrevUsuario())
                {
                    NombreTextBox.Text = en.nombreUsuario;
                    EdadTextBox.Text = en.edadUsuario.ToString();
                    NIFTextBox.Text = en.nifUsuario;
                    mostrarMensaje.Text = "Anterior usuario encontrado: ";

                }
                else
                {
                    mostrarMensaje.Text = "No hay un usuario anterior";
                }
            }
            else
            {
                mostrarMensaje.Text = "No se ha introducido un NIF";
            }



        }

        protected void Actualizar(object sender, EventArgs e)
        {
            if (NIFTextBox.Text != "" && EdadTextBox.Text != "" && NombreTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario(NIFTextBox.Text, NombreTextBox.Text, int.Parse(EdadTextBox.Text));

                if (en.updateUsuario())
                    mostrarMensaje.Text = "Usuario " + en.nombreUsuario + " actualizado con éxito.";
                else
                    mostrarMensaje.Text = "Error actualizando usuario";
            }
            else
            {
                mostrarMensaje.Text = "Error, revisa los campos rellenados";
            }

        }

        protected void BorrarUsuario(object sender, EventArgs e)
        {
            if (NIFTextBox.Text != "" && EdadTextBox.Text != "" && NombreTextBox.Text != "")
            {
                ENUsuario en = new ENUsuario(NIFTextBox.Text, NombreTextBox.Text, int.Parse(EdadTextBox.Text));

                if (en.deleteUsuario())
                    mostrarMensaje.Text = "Usuario " + en.nombreUsuario + " borrado con éxito.";
                else
                    mostrarMensaje.Text = "Error borrando usuario";
            }
            else
            {
                mostrarMensaje.Text = "Error, revisa los campos rellenados";
            }

        }
    }
}