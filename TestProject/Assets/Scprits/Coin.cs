using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private float time;
    
    private Animator _animator;
    private Transform _transform;
    private bool _isEntered;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player) && !_isEntered)
        {
            player.ApplyScore(score);
            _animator.SetTrigger("took");

            StartCoroutine(DoFade());
            _isEntered = true;
        }
    }

    IEnumerator DoFade()
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            float value = Mathf.Lerp(1, 0, elapsedTime / time);

            _transform.localScale = new Vector3(value, value);
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}