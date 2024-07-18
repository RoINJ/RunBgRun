using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scripts.Authentication
{
    public class SignInHelper : MonoBehaviour
    {
        [SerializeField]
        private AuthUIManager _authUIManager;

        [SerializeField]
        private TextMeshProUGUI _emailField;

        [SerializeField]
        private TextMeshProUGUI _passwordField;

        public void SignIn()
        {
            if (ValidateFields())
            {
                var email = _emailField.text;
                var password = _passwordField.text;

                StartCoroutine(
                    FirebaseAuthenticationProvider.Instance.SignIn(
                        email, password, OnSignInSuccess, OnAuthFailure));
            }
        }

        private bool ValidateFields()
        {
            return true;
        }

        private void OnSignInSuccess(User user)
        {
            Debug.Log($"User {user.Username} signed in successfully");
            _authUIManager.HideAll();
        }

        private void OnAuthFailure(string message)
        {
            Debug.LogError(message);
        }
    }
}
