using Application.Employees.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Employees
{
    public class EmployeesController : ApiController
    {

        private readonly IGetEmployeesListQuery _query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            _query = query;
        }

        public IHttpActionResult Get()
        {
            return Ok();
            //return Ok(_query.Execute());
        }
    }
}


