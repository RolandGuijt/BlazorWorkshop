using System.Collections.Generic;

namespace RpcApi.Repositories
{
    public interface IProposalRepo
    {
        Proposal Add(Proposal proposal);
        Proposal Approve(int proposalId);
        IEnumerable<Proposal> GetAllForConference(int conferenceId);
        IEnumerable<Proposal> GetAll();
        Proposal GetById(int id);
    }
}