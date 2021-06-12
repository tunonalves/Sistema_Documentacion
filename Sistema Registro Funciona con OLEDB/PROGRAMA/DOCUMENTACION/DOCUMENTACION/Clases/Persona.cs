using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOCUMENTACION.Clases
{
    class Persona
    {
        int matricula;
        string nombre;
        string apellido;
        string direccion;
        string localidad;
        int provincia;
        Int64 telefono;

        //MODIFICAR_PERSONA

        public Persona(int MATRICULA)
        {
            matricula = MATRICULA;
        }

        // CARGAR, BUSCAR_STOCK, MODIFICAR_STOCK

        public Persona(string NOMBRE, string APELLIDO)
        {
            nombre = NOMBRE;
            apellido = APELLIDO;
        }

        // ENTREGAR (HISTORICOS)

        public Persona(int MATRICULA, string DIRECCION, string LOCALIDAD, int PROVINCIA, Int64 TELEFONO)
        {
            matricula = MATRICULA;
            direccion = DIRECCION;
            localidad = LOCALIDAD;
            provincia = PROVINCIA;
            telefono = TELEFONO;
        }

        //BUSCAR_ENTREGA, MODIFICAR_ENTREGA, MODIFICAR_PERSONA

        public Persona(int MATRICULA, string NOMBRE, string APELLIDO, string DIRECCION, string LOCALIDAD, int PROVINCIA)
        {
            matricula = MATRICULA;
            nombre = NOMBRE;
            apellido = APELLIDO;
            direccion = DIRECCION;
            localidad = LOCALIDAD;
            provincia = PROVINCIA;
        }

        //MODIFICAR_PERSONA

        public Persona(int MATRICULA, string NOMBRE, string APELLIDO, string DIRECCION, string LOCALIDAD, int PROVINCIA, Int64 TELEFONO)
        {
            matricula = MATRICULA;
            nombre = NOMBRE;
            apellido = APELLIDO;
            direccion = DIRECCION;
            localidad = LOCALIDAD;
            provincia = PROVINCIA;
            telefono = TELEFONO;
        }

        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public int Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        public Int64 Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}
