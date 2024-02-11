using Azure.Communication;
using Azure.Communication.Identity;
using System;
using System.Threading.Tasks;

namespace HelloXamarin.Droid
{
    public class Acs : IAcs
    {
        private string _acsConnectionString = null;
        private Com.Ocuvera.Hellojava.Acs _acs = null;

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
            _acs = new Com.Ocuvera.Hellojava.Acs();

            return Task.CompletedTask;
        }

        public async Task<string> StartCall(string callerAcsUserToken, string calleeAcsId, TimeSpan callTokenDuration)
        {
            // note: how do handle async between java/csharp.this method has an awaitable future in it in Java,
            // can the two work together? 

            string callId = null;
            await Task.Run(() =>
            {
                callId = _acs.StartCall(Android.App.Application.Context, callerAcsUserToken, calleeAcsId);
            });
            return callId;
        }
    }
}