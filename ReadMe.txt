5/22/2017

Added MemoryRepository for stubdata.

	// Autofac
    //  Using Stubdata
    builder.RegisterType<StubDataCustomerRepository>().As<ICustomerRepository>().SingleInstance();
    builder.RegisterType<MemoryRepository<Customer>>().As<MemoryRepository<Customer>>().SingleInstance();


Writing Test cases

Avoid Coupling to global state
Keep state local if possible
Inject via a wrapper class (DateTime.Now)

    public interface IDateTimeWrapper
    {
        DateTime GetDate();
    }

    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }


Use IoC/DI singleton instead of GoF singleton.

Autofac 
	.SingleInstance();


Maintain Single Responsibility
Identify responsibilities
Label Responsibilities
Decompose to SRP classes

TDD
http://misko.hevery.com
https://testing.googleblog.com


Create seams in code
Simplify construction (not mixing injectables and newables)
Work with dependencies
Decouple from global state
Maintain SRP
Use TDD


