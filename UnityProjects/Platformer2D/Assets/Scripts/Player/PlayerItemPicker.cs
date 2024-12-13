using UnityEngine;

public class PlayerItemPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ICollectable>(out ICollectable item))
        {
            item.Collect();
        }
    }
}