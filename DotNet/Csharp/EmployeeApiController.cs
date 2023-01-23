using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sabio.Services;
using Sabio.Services.Interfaces;
using Sabio.Web.Controllers;
using Sabio.Web.Models.Responses;
using System.Collections.Generic;
using System;
using Sabio.Models.Domain.Employee;
using Sabio.Models.Requests.Employee;
using Sabio.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeApiController : BaseApiController
    {
        private IEmployeeService _service = null;
        private IAuthenticationService<int> _authService = null;

        public EmployeeApiController(IEmployeeService service, ILogger<EmployeeApiController> logger
            , IAuthenticationService<int> authService) : base(logger)
        {
            _service = service;
            _authService = authService;
        }

        // GetById
        [HttpGet("{id:int}")]
        public ActionResult<ItemResponse<Employee>> Get(int id)
        {
            int iCode = 200;
            BaseResponse response = null;

            try
            {
                Employee employee = _service.Get(id);

                if (employee == null)
                {
                    iCode = 404;
                    response = new ErrorResponse("Application Resource not found.");
                }
                else
                {
                    response = new ItemResponse<Employee> { Item = employee };
                }
            }
            catch (Exception ex)
            {
                iCode = 500;
                base.Logger.LogError(ex.ToString());
                response = new ErrorResponse($"Generic Error: {ex.Message}");
            }
            return StatusCode(iCode, response);
        }

        // GetAll
        [HttpGet]
        public ActionResult<ItemsResponse<Employee>> GetAll()
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<Employee> list = _service.GetAll();

                if (list == null)
                {
                    code = 404;
                    response = new ErrorResponse("App Resource not found.");
                }
                else
                {
                    response = new ItemsResponse<Employee> { Items = list };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                base.Logger.LogError(ex.ToString());
            }
            return StatusCode(code, response);
        }

        // Create / Add
        [HttpPost]
        public ActionResult<ItemResponse<int>> Create(EmployeeAddRequest model)
        {
            ObjectResult result = null;

            try
            {

                int id = _service.Add(model);
                ItemResponse<int> response = new ItemResponse<int>() { Item = id };

                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }

            return result;
        }

        // Update
        [HttpPut("{id:int}")]
        public ActionResult<SuccessResponse> Update(EmployeeUpdateRequest model, int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Update(model, id);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(code, response);
        }

    }
}

