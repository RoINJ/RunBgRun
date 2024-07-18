using System.Collections;
using Firebase.Auth;
using UnityEngine;

namespace Scripts.Authentication
{
    public class FirebaseAuthentication : MonoBehaviour
    {
        private AuthUIManager _authUIManager;

        public FirebaseUser User { get; private set; }

        public IEnumerator SignIn(string email, string password)
        {
            return FirebaseAuthenticationProvider.Instance.SignIn(email, password, OnSignInSuccess, OnAuthFailure);
        }

        public IEnumerator SignUp(string email, string password, string username)
        {
            return FirebaseAuthenticationProvider.Instance.SignUp(email, password, username,OnSignUpSuccess,  OnAuthFailure);
        }

        private void OnSignInSuccess(User user)
        {

        }

        private void OnSignUpSuccess(User user)
        {
            _authUIManager.ShowSignInPanel();
        }

        private void OnAuthFailure(string message)
        {
            Debug.LogError(message);
        }
    }
}
