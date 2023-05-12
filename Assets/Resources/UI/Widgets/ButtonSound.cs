using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip _audioClip;
    private AudioSource _sourse;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_sourse == null)
           _sourse = GameObject.FindWithTag("SFxAudioSourse").GetComponent<AudioSource>();

        _sourse.PlayOneShot(_audioClip);
    }
}
