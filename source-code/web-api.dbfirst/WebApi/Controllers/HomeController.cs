using System.Linq;
using System.Web.Http;
using DAL;

namespace WebApi.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : ApiController 
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public void Get()
        {
            var items = _unitOfWork.UserRepository.GetAll().ToList();
        }
    }
}
