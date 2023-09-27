using System;
using KarioMart.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KarioMart.Menu.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class DataToggle<T> : MonoBehaviour where T: ScriptableObject
    {
        public event Action<T> OnDataChanged;

        [Header("Display")]
        [SerializeField] protected TextMeshProUGUI titleLabel;
        [SerializeField] protected Image displayImage;
        
        [Header("Toggle")]
        [SerializeField] private Image _backgroundImage;
        private Color _backgroundColor;
        protected T _data;
        
        protected Toggle Toggle { get; private set; }

        private void Awake()
        {
            // The #%/(#% toggles get disabled when they are instantiated
            // so i have to enable it AND the background image on init
            // i would prefer if i didnt have to do this manually
            // but i do.
            Toggle = GetComponent<Toggle>();
            Toggle.enabled = true;
            // disabling the standard color transition because it doesnt
            // blend correctly
            Toggle.transition = Selectable.Transition.None;
            Toggle.group = transform.parent.GetComponent<ToggleGroup>();
            
            if (_backgroundImage)
            {
                _backgroundImage.enabled = true;
                _backgroundColor = _backgroundImage.color;
            }
            
            Toggle.onValueChanged.AddListener(OnValueChanged);
        }

        public abstract void Init(T data);

        private void OnValueChanged(bool toggled)
        {
            SetColor(toggled);
            OnDataChanged?.Invoke(_data);
        }

        private void Reset()
        {
            if (TryGetComponent(out Image image))
            {
                Debug.Log("Auto set background image", image);
                _backgroundImage = image;
            }
        }
        
        // I also have to do this manually because the standard
        // color transition doesn't blend...

        private Color NormalColor => _backgroundColor * Toggle.colors.normalColor;
        private Color ToggledColor => _backgroundColor * Toggle.colors.selectedColor;
        protected void SetColor(bool toggled) => _backgroundImage.color = toggled ? ToggledColor : NormalColor;
    }
}