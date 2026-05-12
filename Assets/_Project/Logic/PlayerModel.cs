using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class PlayerModel : MonoBehaviour
{
    private Renderer _renderer;
    private Color[] _colors = new Color[5] { Color.red, Color.green, Color.blue, Color.white, Color.yellow };

    private void Awake()
    {
        _renderer = GetComponent<Renderer> ();
    }

    public void ChangeColor()
    {
        Color color;
        int colorIndex = Random.Range(0, _colors.Length);

        switch (colorIndex)
        {
            case 0:
                color = _colors[colorIndex];
                break;
            case 1:
                color = _colors[colorIndex];
                break;
            case 2:
                color = _colors[colorIndex];
                break;
            case 3:
                color = _colors[colorIndex];
                break;
            case 4:
                color = _colors[colorIndex];
                break;
            case 5:
                color = _colors[colorIndex];
                break;
            default:
                color = Color.plum;
                break;
        }

        _renderer.material.color = color;
    }
}
