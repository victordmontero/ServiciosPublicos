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
            var repo = new RepositorioHistorialCrediticio();
            var result = repo.Obtener(cedula);

            log4net.GlobalContext.Properties["IP"] = HttpContext.Current.Request.UserHostAddress;
            loggger.Info(string.Format("Llamó ObtenerHistorialCrediticio({0})", cedula));

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
                return 0;
            }
        }

        [WebMethod]
        public string[] ObtenerCodigosMonedas()
        {
            var repo = new RepositorioTasaCambiaria();
            return repo.ObtenerTodos().Select(tc => tc.CodMoneda).ToArray();
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
