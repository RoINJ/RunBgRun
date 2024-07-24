using System.Collections;
using Scripts.Authentication;
using UnityEngine;
using Zenject;

namespace Scripts
{
    public class AuthenticationChecker : MonoBehaviour
    {
        private AuthUIManager _authUIManager;

        private GameMenuUIManager _gameMenuUIManager;

        private IAuthenticationProvider _authenticationProvider;

        [Inject]
        private void Init(
            IAuthenticationProvider authenticationProvider,
            GameMenuUIManager gameMenuUIManager,
            AuthUIManager authUIManager)
        {
            _authenticationProvider = authenticationProvider;
            _gameMenuUIManager = gameMenuUIManager;
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
                _gameMenuUIManager.ShowMainMenu();
            }
        }
    }
}
