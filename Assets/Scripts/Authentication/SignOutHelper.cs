using Scripts.GameMenu;
using UnityEngine;
using Zenject;

namespace Scripts.Authentication
{
    public class SignOutHelper : MonoBehaviour
    {
        private IAuthenticationProvider _authProvider;
        private AuthUIManager _authUIManager;
        private GameMenuUIManager _gameMenuUIManager;

        public void SignOut()
        {
            _authProvider.SignOut();
            _gameMenuUIManager.SetActivePanel(EGameMenuState.None);
            _authUIManager.ShowSignInPanel();
        }

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
    }
}
