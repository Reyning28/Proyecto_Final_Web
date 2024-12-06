using System;

namespace Digesett.Services
{
    public class SessionService
    {
        public event Action OnChange;
        
        private string _currentAgentId;
        private string _currentAgentName;
        private bool _isSuperUser = false;
        
        public string CurrentAgentId 
        { 
            get => _currentAgentId;
            private set
            {
                if (_currentAgentId != value)
                {
                    _currentAgentId = value;
                    NotifyStateChanged();
                }
            }
        }
        
        public string CurrentAgentName
        {
            get => _currentAgentName;
            private set
            {
                if (_currentAgentName != value)
                {
                    _currentAgentName = value;
                    NotifyStateChanged();
                }
            }
        }
        
        public bool IsAuthenticated => !string.IsNullOrEmpty(CurrentAgentId);

        public void SetCurrentAgent(string agentId, string agentName)
        {
            CurrentAgentId = agentId;
            CurrentAgentName = agentName;
        }

        public void ClearSession()
        {
            CurrentAgentId = null;
            CurrentAgentName = null;
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();

        public async Task<bool> GetSuperUserSessionAsync()
        {
            return _isSuperUser;
        }

        public async Task SetSuperUserSessionAsync(bool value)
        {
            _isSuperUser = value;
        }
    }
}
