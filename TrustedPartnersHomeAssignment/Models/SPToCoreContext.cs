using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrustedPartnersHomeAssignment.Models
{
    public partial class SPToCoreContext : CoreDbContext
    {
        private DbSet<spGetAgentOrdersByRankResult> spGetAgentOrdersByRank { get; set; }
        private DbSet<spGetAgentsWithOrdersNumForYearResult> spGetAgentsWithOrdersNumForYear { get; set; }
        private DbSet<spGetAgentWithHighestSellForYearResult> spGetAgentWithHighestSellForYear { get; set; }

        public SPToCoreContext()
        {
        }

        public SPToCoreContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }               

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            // No key            
            modelBuilder.Query<spGetAgentOrdersByRankResult>().HasNoKey();
            modelBuilder.Query<spGetAgentsWithOrdersNumForYearResult>().HasNoKey();
            modelBuilder.Query<spGetAgentWithHighestSellForYearResult>().HasNoKey();
            //Thanks Valecass!!!
            base.OnModelCreating(modelBuilder);
        }

        public async Task<List<spGetAgentOrdersByRankResult>> spGetAgentOrdersByRankAsync(string AgentsList,int? Rank)
        {
            //Initialize Result 
            List<spGetAgentOrdersByRankResult> lst = new List<spGetAgentOrdersByRankResult>();
            try
            {
                // Parameters
                SqlParameter p_AgentsList = new SqlParameter("@AgentsList", AgentsList ?? (object)DBNull.Value);
                p_AgentsList.Direction = ParameterDirection.Input;
                p_AgentsList.DbType = DbType.String;
                p_AgentsList.Size = -1;

                SqlParameter p_Rank = new SqlParameter("@Rank", Rank ?? (object)DBNull.Value);
                p_Rank.Direction = ParameterDirection.Input;
                p_Rank.DbType = DbType.Int32;
                p_Rank.Size = 4;


                // Processing 
                string sqlQuery = $@"EXEC [dbo].[spGetAgentOrdersByRank] @AgentsList, @Rank";
                
                //Output Data
                lst = await this.spGetAgentOrdersByRank.FromSqlRaw(sqlQuery , p_AgentsList , p_Rank ).ToListAsync();
            }
            catch (Exception ex){
                throw ex;
            }

            //Return
            return lst;
        }

        public async Task<List<spGetAgentsWithOrdersNumForYearResult>> spGetAgentsWithOrdersNumForYearAsync(int? OrdersNum,int? Year)
        {
            //Initialize Result 
            List<spGetAgentsWithOrdersNumForYearResult> lst = new List<spGetAgentsWithOrdersNumForYearResult>();
            try
            {
                // Parameters
                SqlParameter p_OrdersNum = new SqlParameter("@OrdersNum", OrdersNum ?? (object)DBNull.Value);
                p_OrdersNum.Direction = ParameterDirection.Input;
                p_OrdersNum.DbType = DbType.Int32;
                p_OrdersNum.Size = 4;

                SqlParameter p_Year = new SqlParameter("@Year", Year ?? (object)DBNull.Value);
                p_Year.Direction = ParameterDirection.Input;
                p_Year.DbType = DbType.Int32;
                p_Year.Size = 4;


                // Processing 
                string sqlQuery = $@"EXEC [dbo].[spGetAgentsWithOrdersNumForYear] @OrdersNum, @Year";
                
                //Output Data
                lst = await this.spGetAgentsWithOrdersNumForYear.FromSqlRaw(sqlQuery , p_OrdersNum , p_Year ).ToListAsync();
            }
            catch (Exception ex){
                throw ex;
            }

            //Return
            return lst;
        }

        public async Task<List<spGetAgentWithHighestSellForYearResult>> spGetAgentWithHighestSellForYearAsync(int? Year)
        {
            //Initialize Result 
            List<spGetAgentWithHighestSellForYearResult> lst = new List<spGetAgentWithHighestSellForYearResult>();
            try
            {
                // Parameters
                SqlParameter p_Year = new SqlParameter("@Year", Year ?? (object)DBNull.Value);
                p_Year.Direction = ParameterDirection.Input;
                p_Year.DbType = DbType.Int32;
                p_Year.Size = 4;


                // Processing 
                string sqlQuery = $@"EXEC [dbo].[spGetAgentWithHighestSellForYear] @Year";
                
                //Output Data
                lst = await this.spGetAgentWithHighestSellForYear.FromSqlRaw(sqlQuery , p_Year ).ToListAsync();
            }
            catch (Exception ex){
                throw ex;
            }

            //Return
            return lst;
        }


        public class spGetAgentOrdersByRankResult
        {
            public int ORD_NUM { get; set; }
            public double ORD_AMOUNT { get; set; }
            public double ADVANCE_AMOUNT { get; set; }
            public DateTime ORD_DATE { get; set; }
            public string CUST_CODE { get; set; }
            public string AGENT_CODE { get; set; }
            public string ORD_DESCRIPTION { get; set; }
        }

        public class spGetAgentsWithOrdersNumForYearResult
        {
            public string agent_code { get; set; }
            public string AGENT_NAME { get; set; }
            public string phone_no { get; set; }
        }

        public class spGetAgentWithHighestSellForYearResult
        {
            public string Agent_Code { get; set; }
            public double TotalAmount { get; set; }
        }

    }
}