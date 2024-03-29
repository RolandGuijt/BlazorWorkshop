﻿using System.Threading.Tasks;
using Grpc.Core;
using RpcApi.Repositories;

namespace RpcApi.Services
{
    public class ProposalService: Proposals.ProposalsBase
    {
        private readonly IProposalRepo repo;

        public ProposalService(IProposalRepo repo)
        {
            this.repo = repo;
        }

        public override Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var result = new GetAllResponse();
            result.Proposals.Add(repo.GetAll());
            return Task.FromResult(result);
        }


        public override Task<GetByConferenceIdResponse> GetByConferenceId(
            GetByConferenceIdRequest request, ServerCallContext context)
        {
            var result = new GetByConferenceIdResponse();
            result.Proposals.Add(repo.GetAllForConference(request.ConferenceId));
            return Task.FromResult(result);
        }

        public override Task<AddProposalResponse> Add(
            AddProposalRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddProposalResponse
            {
                Proposal = repo.Add(request.Proposal)
            });
        }

        public override Task<ApproveResponse> Approve(ApproveRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ApproveResponse
            {
                Proposal = repo.Approve(request.Id)
            });
        }
    }
}
