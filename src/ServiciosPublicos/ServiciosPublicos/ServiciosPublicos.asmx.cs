using ServiciosPublicos.DataAccess;
using ServiciosPublicos.DataAccess.Modelos;
using ServiciosPublicos.DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosPublicos
{
    /// <summary>
    /// Summary description for ServiciosPublicos
    /// </summary>
    [WebService(Namespace = "http://unapec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServiciosPublicos : WebService
    {

        #region Servicios de Historial Crediticio
        [WebMethod]
        public HistorialCrediticio ObtenerHistorialCrediticio(string cedula)
        {
            var repo = new RepositorioHistorialCrediticio();
            var result = repo.Obtener(cedula);
            return result;
        }

        [WebMethod]
        public HistorialCrediticio[] ObtenerHistorialesCrediticios()
        {
            var repo = new RepositorioHistorialCrediticio();
            return repo.ObtenerTodos().ToArray();
        }
        #endregion

        #region Servicios de Salud Financiera
        [WebMethod]
        public SaludFinanciera ObtenerSaludFinanciera(string cedula)
        {
            var repo = new RepositorioSaludFinanciera();
            return repo.Obtener(cedula);
        }

        [WebMethod]
        public SaludFinanciera[] ObtenerSaludFinancieras()
        {
            var repo = new RepositorioSaludFinanciera();
            return repo.ObtenerTodos().ToArray();
        }
        #endregion


        #region servicio de tasa cambiaria
        [WebMethod]
        public double ObtenerTasaCambiaria(String code)
        {
            var repo = new RepositorioTasaCambiaria();
            return repo.Obtener(code).Monto;
        }
        #endregion


        #region Servicio de Indice Inflacion 
        [WebMethod]
        public double ObtenerIndiceInflacion(string periodo)
        {
            var repo = new RepositorioIndiceInflacion();
            return repo.Obtener(periodo).Indice;
        }

        #endregion

    }
}
