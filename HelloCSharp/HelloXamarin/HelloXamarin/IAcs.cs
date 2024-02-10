﻿using System;
using System.Threading.Tasks;

namespace HelloXamarin
{
    public interface IAcs
    {
        Task Initialize(string acsConnectionString);
        Task<string> CreateUserAccessToken(string acsUserId, TimeSpan tokenDuration);
        Task<string> StartCall(string callerAcsUserId, string calleeAcsId, TimeSpan callTokenDuration);
        Task EndCall(string callId);
    }
}
