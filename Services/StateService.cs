using System;

namespace EventEase.Services
{
    public class StateService
    {
        public string CurrentUser { get; private set; } = string.Empty;
        public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUser);

        public event Action? OnChange;

        public void Login(string username)
        {
            CurrentUser = username;
            NotifyStateChanged();
        }

        public void Logout()
        {
            CurrentUser = string.Empty;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}