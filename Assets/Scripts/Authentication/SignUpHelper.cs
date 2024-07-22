using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignUpHelper : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _usernameField;

        [SerializeField]
        private TextMeshProUGUI _emailField;

        [SerializeField]
        private TextMeshProUGUI _passwordField;

        [SerializeField]
        private TextMeshProUGUI _confirmPasswordField;

        private IAuthenticationProvider _authProvider;
        private AuthUIManager _authUIManager;

        [Inject]
        private void Init(IAuthenticationProvider authProvider, AuthUIManager authUIManager)
        {
            _authProvider = authProvider;
            _authUIManager = authUIManager;
        }

        public void SignUp()
        {
            if (ValidateFields())
            {
                var email = _emailField.text;
                var password = _passwordField.text;
                var username = _usernameField.text;

                StartCoroutine(
                    _authProvider.SignUp(
                        email, password, username, OnSuccess, OnFailure));
            }
        }

        private bool ValidateFields()
        {
            return true;
        }

        private void OnSuccess(User user)
        {
            Debug.Log($"User {user.Username} signed in successfully");
            _authUIManager.ShowSignInPanel();
        }

        private void OnFailure(string message)
        {
            Debug.LogError(message);
        }
    }
}
