using System.Linq;
using System.Web.Http;
using Business.BusinessEntity;
using Business.Entity;
using Business.ValueObject;
using DAL;

namespace WebApi.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly BusinessUserEntity _businessUserEntity;

        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;;
            _businessUserEntity = new BusinessUserEntity(_unitOfWork);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var items = _businessUserEntity.GetAll().ToList();

            return Ok(items);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create()
        {
            var userEntity = _businessUserEntity.CreateUser(new UserEntity()
            {
                Name = new NameObject()
                {
                    Title = "Mr",
                    FirstName = "Peter"
                },
            });

            return Ok(userEntity);
        }
    }
}
