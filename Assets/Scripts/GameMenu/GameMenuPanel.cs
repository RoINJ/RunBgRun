using UnityEngine;

namespace Scripts.GameMenu
{
    public class GameMenuPanel : MonoBehaviour
    {
        [SerializeField]
        private EGameMenuState _menuState;

        public EGameMenuState MenuState => _menuState;
    }
}
