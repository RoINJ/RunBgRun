using UnityEngine;

namespace Scripts.Authentication
{
    public class AuthUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject signInPanel;

        [SerializeField]
        private GameObject signUpPanel;

        void Start()
        {
            ShowSignInPanel();
        }

        public void ShowSignInPanel()
        {
            signInPanel.SetActive(true);
            signUpPanel.SetActive(false);
        }

        public void ShowSignUpPanel()
        {
            signInPanel.SetActive(false);
            signUpPanel.SetActive(true);
        }

        public void HideAll()
        {
            signInPanel.SetActive(false);
            signUpPanel.SetActive(false);
        }
    }
}
