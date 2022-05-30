using AutoMapper;
using Directory.API.Models.ReportView;
using Directory.Business.Abstract;
using Directory.Core.Dto.LocationDtos;
using Directory.Core.Dto.ResponseResult;
using Directory.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Directory.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LocationController : BaseCustomController
    {
        private readonly ILocationService _locationService;
        private readonly IPersonService _personService;
        private readonly IContactInformationService _contactInformationService;
        private readonly IMapper _mapper;

        public LocationController(IContactInformationService contactInformationService, IPersonService personService, ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
            _personService = personService;
            _contactInformationService = contactInformationService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _locationService.GetAll();
            return CreateActionResult(Response<List<LocationDto>>.Success(_mapper.Map<List<LocationDto>>(list), 200));

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _locationService.GetById(id);
            return CreateActionResult(Response<LocationDto>.Success(_mapper.Map<LocationDto>(entity), 200));

        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _locationService.GetById(id);

            _locationService.Update(entity);
            return CreateActionResult(Response<LocationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Update(LocationAddDto personsDto)
        {
            var entity = _locationService.GetById(personsDto.id);
            entity.County = personsDto.County;
            entity.country = personsDto.country;
            entity.contactinformationid = personsDto.contactinformationid;
            entity.city = personsDto.city;
            entity.street = personsDto.street;
            entity.zipcode = personsDto.zipcode;

            return CreateActionResult(Response<LocationDto>.Success(200));
        }
        [HttpPost]
        public IActionResult Add(LocationAddDto personsDto)
        {
            var entity = new Location
            {

                street = personsDto.street,
                city = personsDto.city,
                contactinformationid = personsDto.contactinformationid,
                country = personsDto.country,
                County = personsDto.County,
                zipcode = personsDto.zipcode
            };
            _locationService.Create(entity);
            return CreateActionResult(Response<LocationDto>.Success(200));
        }
        [HttpGet]
        public IActionResult GetReportByLocation()
        {
            JsonSerializer js = new JsonSerializer();
            var locationViews = new List<LocationViewModel>();
            var listperson = _contactInformationService.GetAll();
            foreach (var item in listperson)
            {
                var person = _personService.GetById(item.personid);
                item.persons = person;
                var locations = _locationService.GetLocationsByContactid(item.id);
                if (locations.Count > 0)
                {
                    foreach (var lct in locations)
                    {
                        var value = new LocationViewModel
                        {
                            street = lct.street,
                            surname = item.persons.Name,
                            name = item.persons.Surname,
                            city = lct.city,
                            country = lct.country,
                            County = lct.County,
                            zipcode = lct.zipcode
                        };
                        locationViews.Add(value);
                    }
                }
            }



            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://cstibavg:3OZD6aHrJzXJIAgcXZi5v6gkA3PWw45W@whale.rmq.cloudamqp.com/cstibavg");
            using (IConnection connection1 = factory.CreateConnection())
            using (IModel channel = connection1.CreateModel())
            {
                channel.QueueDeclare("Directory",
                    durable: false, exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var messageBody = new JavaScriptSerializer().Serialize(locationViews);
                var body = Encoding.UTF8.GetBytes(messageBody);

                channel.BasicPublish(exchange: "",
                    routingKey: "Directory",
                    basicProperties: null,
                    body: body);
            }



            return CreateActionResult(Response<List<LocationViewModel>>.Success(locationViews, 200));

        }
    }
}
