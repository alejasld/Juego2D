using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType { Apple, Banana }
    public ItemType type = ItemType.Apple;
    public int itemValue = 1;
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (sound != null)
            AudioSource.PlayClipAtPoint(sound, transform.position);

        switch (type)
        {
            case ItemType.Apple:
                GameManager.Instance.AddApple(itemValue);
                break;
            case ItemType.Banana:
                GameManager.Instance.AddBanana(itemValue);
                break;
        }

        Destroy(gameObject);
    }
}
