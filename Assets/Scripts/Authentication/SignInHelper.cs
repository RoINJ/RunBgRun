using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignInHelper : MonoBehaviour
    {
        [SerializeField]
        private PopupHelper _popupPrefab;

        [SerializeField]
        private TMP_InputField _emailField;

        [SerializeField]
        private TMP_InputField _passwordField;

        private IAuthenticationProvider _authProvider;
        private AuthUIManager _authUIManager;
        private GameMenuUIManager _gameMenuUIManager;

        [Inject]
        private void Init(
            IAuthenticationProvider authProvider, 
            AuthUIManager authUIManager,
            GameMenuUIManager gameMenuUIManager)
        {
            _authProvider = authProvider;
            _authUIManager = authUIManager;
            _gameMenuUIManager = gameMenuUIManager;
        }

        private void Start()
        {
            _passwordField.inputType = TMP_InputField.InputType.Password;
        }

        public void SignIn()
        {
            if (ValidateFields())
            {
                var email = _emailField.text;
                var password = _passwordField.text;

                StartCoroutine(
                    _authProvider.SignIn(
                        email, password, OnSignInSuccess, SetError));
            }
        }

        private bool ValidateFields()
        {
            var errors = new List<string>();

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

            var isValid = !errors.Any();
            if (!isValid)
            {
                SetError(string.Join("\n", errors));
            }

            return isValid;
        }

        private void OnSignInSuccess(User user)
        {
            _emailField.text = string.Empty;
            _passwordField.text = string.Empty;

            Debug.Log($"User {user.Username} signed in successfully");
            _authUIManager.HideAll();
            _gameMenuUIManager.ShowMainMenu();
        }

        private void SetError(string message)
        {
            Debug.LogError(message);

            _authUIManager.ShowError(message);
        }
    }
}
