
namespace WebApiSite.Controllers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class PingController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(PingDto))]
        public async Task<IHttpActionResult> Get()
        {
            IHttpActionResult res = null;

            try
            {
                res = Content(HttpStatusCode.OK, new PingDto
                {
                    Status = PingStatus.Successful.GetValue()
                });
            }
            catch (Exception ex)
            {
                res = InternalServerError(ex);
            }

            return await Task.FromResult(res);
        }
    }

    public interface IBaseDto { }

    public class PingDto : IBaseDto
    {
        public DateTime Time => DateTime.UtcNow;

        public int Status { get; set; } = PingStatus.Unknown.GetValue();

        public ClientDto Client => ClientDto.Instance;
    }

    public enum PingStatus
    {
        Successful = 0,
        Unknown = -999
    }

    public static class PingStatusExtensions
    {
        public static int GetValue(this PingStatus obj) => (int)obj;
    }

    public class ClientDto
    {
        private ClientDto() { }

        public static readonly ClientDto Instance = new ClientDto();

        public string Address => HttpContext.Current?.Request.UserHostAddress;

        public string DNS => HttpContext.Current?.Request.UserHostName;

        public string Agent => HttpContext.Current?.Request.UserAgent;

        public string[] Languages => HttpContext.Current?.Request.UserLanguages;
    }
}
