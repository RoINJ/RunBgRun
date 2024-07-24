using UnityEngine;

namespace Scripts.Authentication
{
    public class AuthUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _canvas;

        [SerializeField]
        private GameObject _signInPanel;

        [SerializeField]
        private GameObject _signUpPanel;

        [SerializeField]
        private PopupHelper _errorPopup;

        public void ShowSignInPanel()
        {
            _canvas.SetActive(true);
            _signInPanel.SetActive(true);
            _signUpPanel.SetActive(false);
        }

        public void ShowSignUpPanel()
        {
            _canvas.SetActive(true);
            _signInPanel.SetActive(false);
            _signUpPanel.SetActive(true);
        }

        public void HideAll()
        {
            _canvas.SetActive(false);
            _signInPanel.SetActive(false);
            _signUpPanel.SetActive(false);
        }

        public void ShowError(string message)
        {
            _errorPopup.gameObject.SetActive(true);
            _errorPopup.Text = message;
        }
    }
}
