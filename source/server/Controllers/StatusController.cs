using Microsoft.AspNetCore.Mvc;

namespace FQ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly RealmStatus _realmStatus;

        public StatusController(RealmStatus realmStatus)
        {
            _realmStatus = realmStatus;
        }

        [HttpGet(Name = "GetStatus")]
        public RealmStatusMessage Get()
        {
            return _realmStatus.Status();
        }
    }
}
