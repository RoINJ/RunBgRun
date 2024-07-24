using TMPro;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignInHelper : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _emailField;

        [SerializeField]
        private TMP_InputField _passwordField;

        private IAuthenticationProvider _authProvider;
        private AuthUIManager _authUIManager;
        private GameManager _gameManager;

        [Inject]
        private void Init(IAuthenticationProvider authProvider, AuthUIManager authUIManager, GameManager gameManager)
        {
            _authProvider = authProvider;
            _authUIManager = authUIManager;
            _gameManager = gameManager;
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
                        email, password, OnSignInSuccess, OnAuthFailure));
            }
        }

        private bool ValidateFields()
        {
            return true;
        }

        private void OnSignInSuccess(User user)
        {
            _emailField.text = string.Empty;
            _passwordField.text = string.Empty;

            Debug.Log($"User {user.Username} signed in successfully");
            _authUIManager.HideAll();
            _gameManager.ToMainMenu();
        }

        private void OnAuthFailure(string message)
        {
            Debug.LogError(message);
        }
    }
}
