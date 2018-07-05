using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetApi.Models
{
    public partial class Bet
    {
        public IQueryable<Bet> GetUserBets(int id)
        {
            SportsBetEntities sportsBetEntities = new SportsBetEntities();
            
            Bet b = new Bet();
            var data = from c in sportsBetEntities.Bets
                       where c.UserID == id
                       select c;

            return data;
        }
    }
}