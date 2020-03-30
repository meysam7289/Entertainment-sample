using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NosazEntertainment.Data;
using NosazEntertainment.Model;
using System;

namespace NosazEntertainment.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController: ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Category> _category;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _category = _uow.Set<Category>();
        }
        
    }
}
