using KarioMart.Menu.Submenus;
using UnityEngine;

namespace KarioMart.Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private SubMenu[] subMenus;

        public void ShowMenu(SubMenu selectedSubMenu)
        {
            HideSubMenus();
            selectedSubMenu.Show();
        }

        private void HideSubMenus()
        {
            for (int i = 0; i < subMenus.Length; i++)
                subMenus[i].Hide();
        }
    }
}
