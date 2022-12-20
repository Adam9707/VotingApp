using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Domain.Entities;
using VotingApp.Application.Contracts;
using System.ComponentModel;
using VotingApp.Persistence.DbContexts;
using VotingApp.Application.Common;

namespace VotingApp.Persistence.Repositories
{
    public class CandidateRepository: ICandidateRepository
    {
        private readonly IMemoryCache memoryCache;
        private readonly VotingAppDbContext dbContext;

        public CandidateRepository(VotingAppDbContext dbContext, IMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
        }

        public void AddCandidate(Candidate newCandidate)
        {
            dbContext.Candidates.Add(newCandidate);
            dbContext.SaveChanges();
            RefreshCandidatesListInCache();
        }

        public ICollection<Candidate> GetCandidates()
        {
            if (!memoryCache.TryGetValue<List<Candidate>>(MemoryCacheKey.CANDIDATES, out var _))
            {
                RefreshCandidatesListInCache();
            }
            memoryCache.TryGetValue<List<Candidate>>(MemoryCacheKey.CANDIDATES, out var candidates);
            return candidates;
        }
        public void RefreshCandidatesListInCache()
        {
            var cachedList = dbContext.Candidates.OrderByDescending(c=>c.Votes).ToList();
            memoryCache.Set(MemoryCacheKey.CANDIDATES, cachedList);
        }
        public Candidate GetCandidate(int candidateId)
        {
            return dbContext.Candidates.Find(candidateId);
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
