using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.SimpleLocalization.Scripts
{
    /// <summary>
    /// Localize TextMeshPro text component.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedTextTMP : MonoBehaviour
    {
        [SerializeField]
        private string LocalizationKey;

        private TextMeshProUGUI textMeshPro;

        public void Start()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            Localize();
            LocalizationManager.OnLocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.OnLocalizationChanged -= Localize;
        }

        private void Localize()
        {
            textMeshPro.text = LocalizationManager.Localize(LocalizationKey);
        }

        private void OnValidate()
        {
            LocalizationKey = this.name;
        }
    }
}
