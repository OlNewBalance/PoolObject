using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerModel>(out PlayerModel playerModel))
        {
            playerModel.ChangeColor();
        }
    }
}
