using AutoMoq;
using Persistence.Shared.EntityFramework;
using System;

namespace Specification.Shared
{

    public class AppContext
    {
        public AutoMoqer Mocker;
        public IDatabaseContext DatabaseContext;

        public AppContext()
        {
            SetUpAutoMocker();

            SetUpMockDatabase();




            //SetUpIocContainer();
        }

        private void SetUpAutoMocker()
        {
            Mocker = new AutoMoqer();
        }

        public void SetUpMockDatabase()
        {
            var mockDatabase = Mocker.GetMock<IDatabaseContext>();

            var intitializer = new DatabaseInitializer(mockDatabase);

            intitializer.Seed();

            DatabaseContext = mockDatabase.Object;
        }



        //private void SetUpIocContainer()
        //{
        //    Container = IoC.Initialize(this);
        //}
    }
}
