using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrustedPartnersHomeAssignment.Models;

namespace TrustedPartnersHomeAssignment.Controllers
{
    [ApiController]
    [Route("api/agents")]
    public class MainController : ControllerBase
    {
        private SPToCoreContext _dbContext = new SPToCoreContext();

        [HttpGet]
        [Route("getAgentWithHighSell")]
        public async Task<string> GetAgentWithHighSell(int year)
        {
            var res =  await _dbContext.spGetAgentWithHighestSellForYearAsync(year);
            if (!res.Any()) return string.Empty;
            return res.First().Agent_Code;
        }        
        
        [HttpGet]
        [Route("getAgentOrdersByRank")]
        public async Task<IEnumerable<SPToCoreContext.spGetAgentOrdersByRankResult>> GetAgentOrdersByRank([FromQuery] string[] agentsList, int rowRank)
        {
            if (agentsList == null || !agentsList.Any()) return new List<SPToCoreContext.spGetAgentOrdersByRankResult>();
            var res =  await _dbContext.spGetAgentOrdersByRankAsync(string.Join(",", agentsList), rowRank);
            return res;
        }

        [HttpGet]
        [Route("getAgentsOrderOrderNumForYear")]
        public async Task<IEnumerable<SPToCoreContext.spGetAgentsWithOrdersNumForYearResult>> GetAgentsWithOrdersNumForYear(int minOrdersForAgent, int year)
        {
            var res = await _dbContext.spGetAgentsWithOrdersNumForYearAsync(minOrdersForAgent, year);
            return res;
        }

    }
}
