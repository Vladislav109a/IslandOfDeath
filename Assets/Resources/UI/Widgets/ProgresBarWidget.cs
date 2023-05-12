using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Widgets
{
    public class ProgresBarWidget : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        public void SetProgress(float progress)
        {
            _bar.fillAmount = progress;                                                                                                                                                                                                                                                  
        }
    }
}
