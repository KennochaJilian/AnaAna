using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IAnaAnaResultsService
    {
        Task CreateResultAsync(Guid pollId, int choiceId);
        Task<bool> currentUserHaveAlreadyVoted(Guid userId, Guid pollId); 
    }
}
