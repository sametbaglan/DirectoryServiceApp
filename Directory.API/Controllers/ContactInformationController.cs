using AutoMapper;
using Directory.Business.Abstract;
using Directory.Core.Dto.ContactInformationDtos;
using Directory.Core.Dto.ResponseResult;
using Directory.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Directory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : BaseCustomController
    {
        private readonly IContactInformationService _contactInformationService;
        private readonly IMapper _mapper;
        public ContactInformationController(IContactInformationService contactInformationService, IMapper mapper)
        {
            _contactInformationService = contactInformationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _contactInformationService.GetAll();
            return CreateActionResult(Response<List<ContactInformationDto>>.Success(_mapper.Map<List<ContactInformationDto>>(list), 200));

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _contactInformationService.GetById(id);
            return CreateActionResult(Response<ContactInformationDto>.Success(_mapper.Map<ContactInformationDto>(entity), 200));

        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _contactInformationService.GetById(id);
            entity.Delete = false;
            _contactInformationService.Update(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Update(ContactInformationDto contactInformationDto)
        {
            var entity = _contactInformationService.GetById(contactInformationDto.id);
            entity.ModifyDate = System.DateTime.Now;
            entity.InfoContent = contactInformationDto.InfoContent;
            entity.InfoType = contactInformationDto.InfoType;
            entity.ModifyDate = System.DateTime.Now;
            entity.personid = contactInformationDto.personid;
            _contactInformationService.Update(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Add(ContactInformationDto contactInformationDto)
        {
            var entity = new ContactInformation
            {
                InfoType=contactInformationDto.InfoType,
                InfoContent=contactInformationDto.InfoContent,
                personid=contactInformationDto.personid,
            };
            _contactInformationService.Create(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
    }
}
