using System;
using System.Collections;

namespace Scripts.Authentication
{
    public interface IAuthenticationProvider
    {
        bool IsInitialized { get; }
        User CurrentUser { get; }
        IEnumerator SignIn(string email, string password, Action<User> onSuccess, Action<string> onFailure);
        IEnumerator SignUp(string email, string password, string username, Action<User> onSuccess, Action<string> onFailure);
        void SignOut();
    }
}
