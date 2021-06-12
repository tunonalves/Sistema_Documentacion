using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOCUMENTACION.Clases
{
    class Documentos
    {
        string codigo;
        DateTime fecha;
        DateTime fecha_entrega;
        int tipo;
        Persona persona;

        //CONSTRUCTOR PARA CARGAR, BUSCAR_STOCK, MODIFICAR_SOTCK, MODIFICAR_ENTREGA

        public Documentos(string CODIGO, Persona PER, DateTime FECHA, int TIPO)
        {
            codigo = CODIGO;
            persona = PER;
            fecha = FECHA;
            tipo = TIPO;
        }

        //CONSTRUCTOR PARA BUSCAR_ENTREGA (HISTORICOS)

        public Documentos(string CODIGO, Persona PER, DateTime FECHA, DateTime FECHA_ENTREGA, int TIPO)
        {
            codigo = CODIGO;
            persona = PER;
            fecha = FECHA;
            fecha_entrega = FECHA_ENTREGA;
            tipo = TIPO;
        }

        internal Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public DateTime Fecha_entrega
        {
            get { return fecha_entrega; }
            set {fecha_entrega = value; }
        }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
