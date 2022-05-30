using AutoMapper;
using Directory.Business.Abstract;
using Directory.Core.Dto.InfoTypeDtos;
using Directory.Core.Dto.ResponseResult;
using Directory.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Directory.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InfoTypeController : BaseCustomController
    {
        private readonly IInfoTypeService _ınfoTypeService;
        private readonly IMapper _mapper;
        public InfoTypeController(IMapper mapper, IInfoTypeService ınfoTypeService)
        {
            _ınfoTypeService = ınfoTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _ınfoTypeService.GetAll();
            return CreateActionResult(Response<List<InfoTypeDto>>.Success(_mapper.Map<List<InfoTypeDto>>(list), 200));
        }
        [HttpPost]
        public IActionResult Add(InfoTypeDto ınfoTypeDto)
        {
            _ınfoTypeService.Create(_mapper.Map<InfoType>(ınfoTypeDto));
            return CreateActionResult(Response<InfoTypeDto>.Success(200));
        }
    }
}
