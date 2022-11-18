using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Auth;
using Grpc.Core;
using RpcApi;

namespace Blazor.Services
{
    public class ConferenceApiService : IConferenceService
    {
        private readonly Conferences.ConferencesClient client;
        private readonly TokenProvider provider;

        public ConferenceApiService(Conferences.ConferencesClient client, TokenProvider provider)
        {
            this.client = client;
            this.provider = provider;
        }
        public async Task<IEnumerable<Conference>> GetAll()
        {
            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {provider.AccessToken}");
            var response = await client.GetAllAsync(
                new GetAllConferencesRequest(), headers);
            return response.Conferences;
        }

        public async Task Add(Conference model)
        {
            await client.AddAsync(
                new AddConferenceRequest { Conference = model });
        }
    }
}
