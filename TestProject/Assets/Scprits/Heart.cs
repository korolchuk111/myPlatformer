using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private void Start()
    {
        player.damaged += Damaged;
    }

    private void Damaged(float damage)
    {
        GetComponent<Image>().fillAmount = damage;
    }
}
