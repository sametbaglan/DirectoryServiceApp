using AutoMapper;
using Directory.Business.Abstract;
using Directory.Core.Dto.PersonsDtos;
using Directory.Core.Dto.ResponseResult;
using Directory.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Directory.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PersonController : BaseCustomController
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _mapper = mapper;
            _personService = personService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _personService.GetAll();
            return CreateActionResult(Response<List<PersonAddDto>>.Success(_mapper.Map<List<PersonAddDto>>(list),200));

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _personService.GetById(id);
            return CreateActionResult(Response<PersonAddDto>.Success(_mapper.Map<PersonAddDto>(entity),200));

        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _personService.GetById(id);
            entity.Delete = false;
            _personService.Update(entity);
            return CreateActionResult(Response<PersonsDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Update(PersonAddDto personsDto)
        {
            var entity = _personService.GetById(personsDto.id);
            entity.ModifyDate = System.DateTime.Now;
            entity.Name = personsDto.Name;
            entity.Surname = personsDto.Surname;
            entity.Company = personsDto.Company;
            _personService.Update(entity);
            return CreateActionResult(Response<PersonsDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Add(PersonAddDto personsDto)
        {
            var entity = new Persons
            {
                Surname = personsDto.Surname,
                CreateDate = System.DateTime.Now,
                ModifyDate = System.DateTime.Now,
                Delete = false,
                Name = personsDto.Name,
                Company = personsDto.Company
            };
            _personService.Create(entity);
            return CreateActionResult(Response<PersonsDto>.Success(200));
        }
    }
}
