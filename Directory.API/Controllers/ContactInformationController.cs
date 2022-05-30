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
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactInformationController : BaseCustomController
    {
        private readonly IContactInformationService _contactInformationService;
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;
        public ContactInformationController(IContactInformationService contactInformationService, IMapper mapper, ILocationService locationService)
        {
            _contactInformationService = contactInformationService;
            _mapper = mapper;
            _locationService = locationService;
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
            entity.Delete = true;
            _contactInformationService.Update(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Update(ContactInformationAddDto contactInformationDto)
        {
            var entity = _contactInformationService.GetById(contactInformationDto.id);
            entity.ModifyDate = System.DateTime.Now;
            entity.InfoContent = contactInformationDto.InfoContent;
            entity.infotypeid = contactInformationDto.infotypeid;
            entity.ModifyDate = System.DateTime.Now;
            entity.personid = contactInformationDto.personid;
            _contactInformationService.Update(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Add(ContactInformationAddDto contactInformationDto)
        {
            var entity = new ContactInformation
            {
                infotypeid = contactInformationDto.infotypeid,
                CreateDate = System.DateTime.Now,
                Delete = false,
                InfoContent = contactInformationDto.InfoContent,
                personid = contactInformationDto.personid,
            };
            _contactInformationService.Create(entity);
            return CreateActionResult(Response<ContactInformationDto>.Success(200));
        }
        [HttpGet("{id}")]
        public IActionResult GetPersonContactid(int id)
        {
            var entity = _contactInformationService.GetPersonContactid(id);
            var locations = _locationService.GetLocationsByContactid(entity.id);
            entity.Locations = locations;
            return CreateActionResult(Response<ContactInformation>.Success(entity, 200));
        }
    }
}
