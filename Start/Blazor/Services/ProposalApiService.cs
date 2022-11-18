using System.Collections.Generic;
using System.Threading.Tasks;
using RpcApi;

namespace Blazor.Services
{  
    public class ProposalApiService : IProposalService
    {
        private readonly Proposals.ProposalsClient client;

        public ProposalApiService(Proposals.ProposalsClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Proposal>> GetAll()
        {
            var result = await client.GetAllAsync(new GetAllRequest());
            return result.Proposals;
        }

        public async Task<IEnumerable<Proposal>> GetByConferenceId(int conferenceId)
        {
            var result = await client.GetByConferenceIdAsync(
                new GetByConferenceIdRequest { ConferenceId = conferenceId });
            return result.Proposals;
        }

        public async Task Add(Proposal proposal)
        {
            await client.AddAsync(
                new AddProposalRequest { Proposal = proposal });
        }

        public async Task<Proposal> Approve(int proposalId)
        {
            var response = await client.ApproveAsync(new ApproveRequest { Id = proposalId });
            return response.Proposal;
        }
    }
}
