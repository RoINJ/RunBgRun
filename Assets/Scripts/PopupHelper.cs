using TMPro;
using UnityEngine;

namespace Scripts
{
    public class PopupHelper : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textLabel;

        public string Text
        {
            get => _textLabel.text;
            set => _textLabel.text = value;
        }

        public void ClosePopup() => gameObject.SetActive(false);
    }
}
