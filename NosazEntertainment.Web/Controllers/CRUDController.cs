using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NosazEntertainment.Dto;
using NosazEntertainment.Model;
using NosazEntertainment.Service;
using NosazEntertainment.Web.Filters;
using NosazEntertainment.Web.Models;
using System;
using System.Threading.Tasks;

namespace NosazEntertainment.Web.Controllers
{
    [Route("[controller]")]
    public class CRUDController<TService, TEntity, TDto> : ControllerBase where TService : IBaseService<TEntity> 
                                                                          where TEntity: BaseEntity 
                                                                          where TDto: IBaseDto
    {
        private readonly TService _Service;
        private readonly IMapper _mapper;

        public CRUDController(TService Service, IMapper mapper)
        {
            _Service = Service;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        [ValidationModel]
        public virtual async Task<ApiResult> Add([FromBody] TDto dto)
        {
            dto.Id = Guid.NewGuid();
            await _Service.InsertAsync(_mapper.Map<TEntity>(dto));
            return new ApiResult
            {
                Status = ApiResultStatus.success,
                Data = dto,
                Message = "با موفقیت انجام شد"
            };
        }

        [HttpPost("Update")]
        [ValidationModel]
        public virtual async Task<ApiResult> Update([FromBody] TDto dto)
        {
            await _Service.UpdateAsync(_mapper.Map<TEntity>(dto), true);
            return new ApiResult
            {
                Status = ApiResultStatus.success,
                Data = dto,
                Message = "با موفقیت انجام شد"
            };
        }

        [HttpPost("Delete/{id}")]
        public virtual async Task<ApiResult> Delete(Guid id)
        {
            await _Service.DeleteAsync(id);
            return new ApiResult
            {
                Status = ApiResultStatus.success,
                Data = id,
                Message = "با موفقیت انجام شد"
            };
        }

        [HttpGet("{id}")]
        public virtual async Task<ApiResult> Get(Guid id)
        {
            var model = await _Service.FindAsyncAsNoTracking(x => x.Id == id);
            return new ApiResult
            {
                Status = model==null?ApiResultStatus.logical : ApiResultStatus.success,
                Data = _mapper.Map<TDto>(model)
            };
        }
    }
}
