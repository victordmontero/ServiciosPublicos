using log4net;
using ServiciosPublicos.DataAccess.Modelos;
using ServiciosPublicos.DataAccess.Repositorios;
using ServiciosPublicos.Logger;
using System.Linq;
using System.Web;
using System.Web.Services;

[assembly: log4net.Config.XmlConfigurator()]
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
        static readonly ILog loggger = LogManager.GetLogger(typeof(ServiciosPublicos));

        #region Servicios de Historial Crediticio
        [WebMethod]
        public HistorialCrediticio ObtenerHistorialCrediticio(string cedula)
        {
            try
            {
                var repo = new RepositorioHistorialCrediticio();
                var result = repo.Obtener(cedula);

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerHistorialCrediticio({0})", cedula));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error("Error al llamar ObtenerHistorialCrediticio", ex);
                throw;
            }
        }

        [WebMethod]
        public HistorialCrediticio[] ObtenerHistorialesCrediticios()
        {
            try
            {
                var repo = new RepositorioHistorialCrediticio();
                var result = repo.ObtenerTodos().ToArray();

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerHistorialesCrediticios()"));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error("Error al llamar ObtenerHistorialesCrediticios", ex);
                throw;
            }
        }
        #endregion

        #region Servicios de Salud Financiera
        [WebMethod]
        public SaludFinanciera ObtenerSaludFinanciera(string cedula)
        {
            try
            {
                var repo = new RepositorioSaludFinanciera();
                var result = repo.Obtener(cedula);

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerSaludFinanciera({0})", cedula));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error(string.Format("Error al llamar ObtenerSaludFinanciera({0})", cedula), ex);
                throw;
            }
        }

        [WebMethod]
        public SaludFinanciera[] ObtenerSaludFinancieras()
        {
            try
            {
                var repo = new RepositorioSaludFinanciera();
                var result = repo.ObtenerTodos().ToArray();

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerSaludFinancieras()"));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error(string.Format("Error al llamar ObtenerSaludFinanciera()"), ex);
                throw;
            }
        }
        #endregion


        #region servicio de tasa cambiaria
        [WebMethod]
        public double ObtenerTasaCambiaria(string code)
        {
            var repo = new RepositorioTasaCambiaria();
            try
            {
                double result = repo.Obtener(code).Monto;
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerTasaCambiaria({0})", code));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error("Error al llamar ObtenerTasaCambiaria", ex);
                throw;
            }
        }

        [WebMethod]
        public string[] ObtenerCodigosMonedas()
        {
            try
            {
                var repo = new RepositorioTasaCambiaria();
                var result = repo.ObtenerTodos().Select(tc => tc.CodMoneda).ToArray();

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerCodigosMonedas()"));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error("Error al llamar ObtenerCodigosMonedas", ex);
                throw;
            }
        }
        #endregion


        #region Servicio de Indice Inflacion
        [WebMethod]
        public double ObtenerIndiceInflacion(string periodo)
        {
            try
            {
                var repo = new RepositorioIndiceInflacion();
                var result = repo.Obtener(periodo).Indice;

                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Info(string.Format("Llamó ObtenerIndiceInflacion({0})", periodo));

                return result;
            }
            catch (System.Exception ex)
            {
                log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
                loggger.Error(string.Format("Error al llamar ObtenerIndiceInflacion({0})", periodo), ex);
                throw;
            }
        }

        #endregion

    }
}
