using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperSocket.Channel;

namespace SuperSocket
{
    public class SyncToAsyncSessionContainerWraper : IAsyncSessionContainer
    {
        ISessionContainer _syncSessionContainer;

        public SyncToAsyncSessionContainerWraper(ISessionContainer syncSessionContainer)
        {
            _syncSessionContainer = syncSessionContainer;
        }

        public ValueTask<IAppSession> GetSessionByIDAsync(string sessionID)
        {
            return new ValueTask<IAppSession>(_syncSessionContainer.GetSessionByID(sessionID));
        }

        public ValueTask<int> GetSessionCountAsync()
        {
            return new ValueTask<int>(_syncSessionContainer.GetSessionCount());
        }

        public ValueTask<IEnumerable<IAppSession>> GetSessionsAsync(Predicate<IAppSession> critera = null)
        {
            return new ValueTask<IEnumerable<IAppSession>>(_syncSessionContainer.GetSessions(critera));
        }

        public ValueTask<IEnumerable<TAppSession>> GetSessionsAsync<TAppSession>(Predicate<TAppSession> critera = null) where TAppSession : IAppSession
        {
            return new ValueTask<IEnumerable<TAppSession>>(_syncSessionContainer.GetSessions<TAppSession>(critera));
        }
    }
}