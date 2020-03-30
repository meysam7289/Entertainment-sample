using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NosazEntertainment.Dto;
using NosazEntertainment.Model;
using NosazEntertainment.Service;
using NosazEntertainment.Web.Models;
using System;
using System.Threading.Tasks;

namespace NosazEntertainment.Web.Controllers
{
    public class CategoryController : CRUDController<ICategoryService,Category,CategoryDto>
    {
        public CategoryController(ICategoryService service, IMapper mapper):base(service,mapper)
        {

        }

        public override Task<ApiResult> Add([FromBody] CategoryDto dto)
        {
            return base.Add(dto);
        }

        public override Task<ApiResult> Update([FromBody] CategoryDto dto)
        {
            return base.Update(dto);
        }

        public override Task<ApiResult> Delete(Guid id)
        {
            return base.Delete(id);
        }

        public override Task<ApiResult> Get(Guid id)
        {
            return base.Get(id);
        }
    }
}
