using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            return _context.Quotes
                .Where(x => x.Episode == _randomService
                .RandomInteger(_context.Quotes
                .Max(ep => ep.Episode)))
                .Select(x => x).First();
        }

        public Quote GetAnyQuote(string actor)
        {

            var listActor = _context.Quotes
                .Where(ac => ac.Actor == actor)
                .Select(x => x)
                .ToList();

            var maxrandom = listActor.Count();

            if (maxrandom == 0)
            {
                return null;
            }

            return listActor[_randomService.RandomInteger(maxrandom)];
        }
    }
}