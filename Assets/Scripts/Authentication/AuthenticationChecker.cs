using System.Collections;
using Scripts.Authentication;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class AuthenticationChecker : MonoBehaviour
    {
        private AuthUIManager _authUIManager;

        private GameManager _gameManager;

        private IAuthenticationProvider _authenticationProvider;

        [Inject]
        private void Init(
            IAuthenticationProvider authenticationProvider,
            GameManager gameManager,
            AuthUIManager authUIManager)
        {
            _authenticationProvider = authenticationProvider;
            _gameManager = gameManager;
            _authUIManager = authUIManager;
        }

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => _authenticationProvider.IsInitialized);

            if (_authenticationProvider.CurrentUser is null)
            {
                _authUIManager.ShowSignInPanel();
            }
            else
            {
                _gameManager.ToMainMenu();
            }
        }
    }
}
