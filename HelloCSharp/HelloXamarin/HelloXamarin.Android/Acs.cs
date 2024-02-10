using Azure.Communication;
using Azure.Communication.Identity;
using System;
using System.Threading.Tasks;

namespace HelloXamarin.Droid
{
    public class Acs : IAcs
    {
        private string _acsConnectionString = null;

        public async Task<string> CreateUserAccessToken(string acsUserId, TimeSpan tokenDuration)
        {
            var identityClient = new CommunicationIdentityClient(_acsConnectionString);
            var token = await identityClient.GetTokenAsync(new CommunicationUserIdentifier(acsUserId), new[]
            {
                CommunicationTokenScope.VoIP,
            }, tokenDuration);
            return token.Value.Token;
        }

        public Task EndCall(string callId)
        {
            throw new NotImplementedException();
        }

        public Task Initialize(string acsConnectionString)
        {
            _acsConnectionString = acsConnectionString;
            return Task.CompletedTask;
        }

        public Task<string> StartCall(string callerAcsUserId, string calleeAcsId, TimeSpan callTokenDuration)
        {
            throw new NotImplementedException();
        }
    }
}