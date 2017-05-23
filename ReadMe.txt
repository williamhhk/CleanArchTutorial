5/22/2017

Added MemoryRepository for stubdata.

	// Autofac
    //  Using Stubdata
    builder.RegisterType<StubDataCustomerRepository>().As<ICustomerRepository>().SingleInstance();
    builder.RegisterType<MemoryRepository<Customer>>().As<MemoryRepository<Customer>>().SingleInstance();
