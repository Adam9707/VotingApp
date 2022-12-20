using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.DataTransferObjects
{
    public class HttpResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
