    // AutoMapper Profile
    public class MyProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CountryData, Country>()
                .ForMember(d => d.Cities, opt => opt.Ignore())
                .AfterMap(AddOrUpdateCities);
        }
        private void AddOrUpdateCities(CountryData dto, Country country)
        {
            foreach (var cityDTO in dto.Cities)
            {
                if (cityDTO.Id == 0)
                {
                    country.Cities.Add(Mapper.Map<City>(cityDTO));
                }
                else
                {
                    Mapper.Map(cityDTO, country.Cities.SingleOrDefault(c => c.Id == cityDTO.Id));
                }
            }
        }
    }
