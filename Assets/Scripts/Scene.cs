using TMPro;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Scene : MonoBehaviour
{
    [SerializeField] private TMP_Text _countOfRings;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _countOfRings.text = _slider.value.ToString();
    }

    public void OnPlayButtonClick()
    {
        MainGameplay.Load((int)_slider.value);
    }

    public void ChangeCountRings()
    {
        _countOfRings.text = _slider.value.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
