using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Domain.Exceptions;

namespace VotingApp.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length >= 3)
                {
                    this.name = value;
                }
                else
                {
                    throw new IncorrectArgumentException("Name legth must be greater than 2");
                }
            }
        }
        public int Votes { get; set; }

        public Candidate(string name)
        {
            Name = name;
            Votes = 0;
        }
        public void AddVote()
        {
            this.Votes +=1;
        }
    }
}
