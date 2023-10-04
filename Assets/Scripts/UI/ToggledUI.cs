using UnityEngine;

namespace KarioMart.UI
{
    public class ToggledUI : MonoBehaviour
    {
        [SerializeField] private GameObject content;

        public void Hide() => content.SetActive(false);
        public void Show() => content.SetActive(true);
    }
}