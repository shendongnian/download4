    var config = new MapperConfiguration(
        cfg => {
            cfg.CreateMap<Customer, CustomerDto>();
            cfg.CreateMap<Customer, DetailedCustomerDto>();
            cfg.CreateMap<Order, OrderDto>()
                 .ForMember(dst => dst.Customer, src => src.ResolveUsing((order, orderDto, i, context) => {
                    return order.Type == 1
                    ? context.Mapper.Map<Customer, CustomerDto>(order.Customer)
                    : context.Mapper.Map<Customer, DetailedCustomerDto>(order.Customer);
            }));
     });
     var orderTypeOne = new Order();
     orderTypeOne.Type = 1;
     orderTypeOne.Customer = new Customer() {
        Id = 1
     };
     var dto = config.CreateMapper().Map<Order, OrderDto>(orderTypeOne);
     Debug.Assert(dto.Customer.GetType() == typeof (CustomerDto));
     var orderTypeTwo = new Order();
     orderTypeTwo.Type = 2;
     orderTypeTwo.Customer = new Customer() {
         Id = 1
     };
     dto = config.CreateMapper().Map<Order, OrderDto>(orderTypeTwo);
     Debug.Assert(dto.Customer.GetType() == typeof (DetailedCustomerDto));
