using AutoMapper;
using Directory.Core.Dto.ContactInformationDtos;
using Directory.Core.Dto.InfoTypeDtos;
using Directory.Core.Dto.LocationDtos;
using Directory.Core.Dto.PersonsDtos;
using Directory.Entity.Concrete;

namespace Directory.Core.Dto.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<ContactInformationDto, ContactInformation>().ReverseMap();
            CreateMap<PersonsDto, Persons>().ReverseMap();
            CreateMap<PersonAddDto, Persons>().ReverseMap();
            CreateMap<InfoTypeDto, InfoType>().ReverseMap();
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<ContactInformationAddDto, ContactInformation>().ReverseMap();
        }
    }
}
