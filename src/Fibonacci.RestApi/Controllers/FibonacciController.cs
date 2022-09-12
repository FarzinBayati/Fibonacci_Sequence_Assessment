using Fibonacci.Infrastructure.Entities;
using Fibonacci.Infrastructure.Repositories;
using Fibonacci.RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SyncVR.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IRequestedNumbersHistoryRepository _requestedNumbersHistoryRepository;

        public FibonacciController(IRequestedNumbersHistoryRepository requestedNumbersHistoryRepository)
        {
            _requestedNumbersHistoryRepository = requestedNumbersHistoryRepository ??
                throw new ArgumentNullException(nameof(requestedNumbersHistoryRepository));
        }

        [HttpGet("GetNthNumberFromFibonacciSequence/{nth}")]
        public ActionResult<FibonacciDto> GetNthNumberFromFibonacciSequence(int nth)
        {
            if (nth < 0)
                return BadRequest();

            var fiboNumber = Helpers.FibonacciCalculator.GetNthFibonacci(nth);

            var result = new FibonacciDto
            {
                RequestedNumber = nth,
                Result = fiboNumber,
                RequestedDateTime = DateTime.Now
            };

            _requestedNumbersHistoryRepository.AddHistory(new Fibonacci.Infrastructure.Entities.RequestedNumbersHistory
            {
                RequestedNumber = nth,
                Result = fiboNumber
            });

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RequestedNumbersHistory>> GetHistory()
        {
            return Ok(_requestedNumbersHistoryRepository.GetAllHistories());
        }
    }
}