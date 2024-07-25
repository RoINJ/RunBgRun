using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignUpHelper : MonoBehaviour
    {
        [SerializeField]
        private PopupHelper _popupPrefab;

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

        public void SignUp()
        {
            if (ValidateFields())
            {
                var email = _emailField.text;
                var password = _passwordField.text;
                var username = _usernameField.text;

                StartCoroutine(
                    _authProvider.SignUp(
                        email, password, username, OnSuccess, SetError));
            }
        }

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

        private bool ValidateFields()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(_usernameField.text))
            {
                errors.Add("Username is required");
            }

            if (string.IsNullOrWhiteSpace(_emailField.text))
            {
                errors.Add("Email is required");
            }
            else if (!Regex.IsMatch(_emailField.text, Constants.EmailRegex))
            {
                errors.Add("Email is invalid");
            }

            if (string.IsNullOrWhiteSpace(_passwordField.text))
            {
                errors.Add("Password is required");
            }
            else if (string.IsNullOrWhiteSpace(_confirmPasswordField.text))
            {
                errors.Add("Confirm Password is required");
            }
            else if (_passwordField.text != _confirmPasswordField.text)
            {
                errors.Add("Passwords do not match");
            }

            var isValid = !errors.Any();
            if (!isValid)
            {
                SetError(string.Join("\n", errors));
            }

            return isValid;
        }

        private void OnSuccess(User user)
        {
            _usernameField.text = string.Empty;
            _emailField.text = string.Empty;
            _passwordField.text = string.Empty;
            _confirmPasswordField.text = string.Empty;

            Debug.Log($"User {user.Username} signed in successfully");
            _authUIManager.ShowSignInPanel();
        }

        private void SetError(string message)
        {
            Debug.LogError(message);

            _authUIManager.ShowError(message);
        }
    }
}
