using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GreenTubeTask.Models;
using GreenTubeTask.Models.Dtos;
using GreenTubeTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenTubeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletsService walletsService;
        private readonly IMapper mapper;

        public WalletsController(IWalletsService walletsService, IMapper mapper)
        {
            this.walletsService = walletsService;
            this.mapper = mapper;
        }

        [HttpPost("{userGuid}")]
        public IActionResult MakeTransaction(string userGuid, [FromBody] TransactionDto transactionDto)
        {
            Transaction transaction = mapper.Map<Transaction>(transactionDto);
            if (!walletsService.MakeTransaction(transaction, userGuid))
            {
                return BadRequest("Transaction could not be processed");
            }

            return Accepted();
        }

        [HttpGet("{userGuid}")]
        public async Task<IActionResult> GetTransactions(string userGuid)
        {
            List<Transaction> transactions = await walletsService.GetTransactionsForPlayer(userGuid);

            List<TransactionDto> response = transactions.Select(mapper.Map<Transaction, TransactionDto>).ToList();

            return Ok(response);
        }
    }
}