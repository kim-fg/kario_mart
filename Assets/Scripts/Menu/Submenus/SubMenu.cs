using UnityEngine;

namespace KarioMart.Menu.Submenus
{
    public class SubMenu : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}