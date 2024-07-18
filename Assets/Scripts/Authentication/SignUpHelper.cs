using TMPro;
using UnityEngine;

namespace Scripts.Authentication
{
    public class SignUpHelper : MonoBehaviour
    {
        [SerializeField]
        private AuthUIManager _authUIManager;

        [SerializeField]
        private TextMeshProUGUI _usernameField;

        [SerializeField]
        private TextMeshProUGUI _emailField;

        [SerializeField]
        private TextMeshProUGUI _passwordField;

        [SerializeField]
        private TextMeshProUGUI _confirmPasswordField;

        public void SignUp()
        {
            if (ValidateFields())
            {
                var email = _emailField.text;
                var password = _passwordField.text;
                var username = _usernameField.text;

                StartCoroutine(
                    FirebaseAuthenticationProvider.Instance.SignUp(
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
