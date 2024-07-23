using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignUpHelper : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _usernameField;

        [SerializeField]
        private TMP_InputField _emailField;

        [SerializeField]
        private TMP_InputField _passwordField;

        [SerializeField]
        private TMP_InputField _confirmPasswordField;

        private IAuthenticationProvider _authProvider;
        private AuthUIManager _authUIManager;

        [Inject]
        private void Init(IAuthenticationProvider authProvider, AuthUIManager authUIManager)
        {
            _authProvider = authProvider;
            _authUIManager = authUIManager;
        }

        private void Start()
        {
            _passwordField.inputType = TMP_InputField.InputType.Password;
            _confirmPasswordField.inputType = TMP_InputField.InputType.Password;
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
