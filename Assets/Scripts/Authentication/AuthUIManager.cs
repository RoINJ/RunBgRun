using UnityEngine;

namespace Scripts.Authentication
{
    public class AuthUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _signInPanel;

        [SerializeField]
        private GameObject _signUpPanel;

        public void ShowSignInPanel()
        {
            _signInPanel.SetActive(true);
            _signUpPanel.SetActive(false);
        }

        public void ShowSignUpPanel()
        {
            _signInPanel.SetActive(false);
            _signUpPanel.SetActive(true);
        }

        public void HideAll()
        {
            _signInPanel.SetActive(false);
            _signUpPanel.SetActive(false);
        }
    }
}
