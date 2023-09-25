using UnityEngine;

namespace KarioMart.Menu
{
    public class SubMenu : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}