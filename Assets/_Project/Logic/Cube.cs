using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 0.005f;

    private Renderer _renderer;
    private Color _color;
    private Color _startColor;
    private bool _isFading = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
        _startColor = _color;
    }

    public void OnOffFading()
    {
        if (_isFading)
        {
            _isFading = false;
            return;
        }

        _isFading = true;
        StartCoroutine(Fading());
    }

    public void ResetFading()
    {
        _renderer.material.color = _startColor;
    }

    private IEnumerator Fading()
    {
        float timeCount = 0f;

        while (timeCount < _fadeTime && _isFading)
        {
            _color.a = Mathf.Lerp(_color.a, 0f, timeCount / _fadeTime);
            _renderer.material.color = _color;

            timeCount += Time.deltaTime;
            yield return null;
        }
    }
}
