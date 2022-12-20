using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Domain.Exceptions;

namespace VotingApp.Domain.Entities
{
    public class Voter
    {
        public int Id { get; set; }

        private string name;
        public string Name {
            get
            {
                return name;
            }
            set
            {
                if(value.Length >= 3)
                {
                    this.name = value;
                }
                else
                {
                    throw new IncorrectArgumentException("Name legth must be greater than 2");
                }
            } 
        }
        public bool HasVoted { get;  set; }

        public Voter(string name)
        {
            Name = name;
        }

        public void Vote()
        {
            if (this.HasVoted)
            {
                throw new IncorrectActionException($"Voter {Name} has already voted!");
            }
            else
            {
                this.HasVoted = true;   
            }
        }
    }
}
