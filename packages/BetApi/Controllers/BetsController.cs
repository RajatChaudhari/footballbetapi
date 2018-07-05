using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BetApi.Models;

namespace BetApi.Controllers
{
    public class BetsController : ApiController
    {
        private SportsBetEntities db = new SportsBetEntities();

        // GET: api/Bets
        public IQueryable<Bet> GetBets()
        {
            return db.Bets;
        }

        // GET: api/Bets/5
        [ResponseType(typeof(Bet))]
        public async Task<IHttpActionResult> GetBet(int id)
        {
            Bet bet = await db.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            return Ok(bet);
        }
        
        public IQueryable<Bet> GetUserBet(int id)
        {
            Bet betObj = new Bet();
            IQueryable<Bet> bets = betObj.GetUserBets(id);
            return bets;
        }

        // PUT: api/Bets/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBet(int id, Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bet.ID)
            {
                return BadRequest();
            }

            db.Entry(bet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bets
        [ActionName("Add")]
        [ResponseType(typeof(Bet))]
        public async Task<IHttpActionResult> PostBet(Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bets.Add(bet);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bet.ID }, bet);
        }

        // DELETE: api/Bets/5
        [ResponseType(typeof(Bet))]
        public async Task<IHttpActionResult> DeleteBet(int id)
        {
            Bet bet = await db.Bets.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            db.Bets.Remove(bet);
            await db.SaveChangesAsync();

            return Ok(bet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BetExists(int id)
        {
            return db.Bets.Count(e => e.ID == id) > 0;
        }
    }
}