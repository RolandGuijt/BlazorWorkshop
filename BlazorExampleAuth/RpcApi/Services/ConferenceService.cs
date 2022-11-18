using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using RpcApi.Repositories;

namespace RpcApi.Services
{
    [Authorize]
    public class ConferenceService: Conferences.ConferencesBase
    {
        private readonly IConferenceRepo repo;

        public ConferenceService(IConferenceRepo repo)
        {
            this.repo = repo;
        }

        [Authorize(Policy = "Basic")]
        public override Task<GetAllConferencesResponse> GetAll(
            GetAllConferencesRequest request, ServerCallContext context)
        {
            var result = new GetAllConferencesResponse();
            result.Conferences.Add(repo.GetAll());
            return Task.FromResult(result);
        }

        public override Task<AddConferenceResponse> Add(
            AddConferenceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AddConferenceResponse
            {
                Conference = repo.Add(request.Conference)
            });
        }
    }
}
