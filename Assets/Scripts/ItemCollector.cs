using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private int fruitCount = 0;
    private bool death;

    [SerializeField] private AudioSource _death;
    [SerializeField] private AudioSource _collect;

    [SerializeField] private TMP_Text _textMesh;
    [SerializeField] private TMP_Text _lifeTextMesh;

    [SerializeField] private GameState _state;

    private void Start()
    {
        death = false;
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lifeTextMesh.text = _state.Life.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.CompareTag("Pineapple"))
        {
            Destroy(col.gameObject);
            fruitCount++;
            _collect.Play();
            _textMesh.text = fruitCount.ToString();
        } else if (col.gameObject.CompareTag("Traps") && !death)
        {
            death = true;
            Die();
        }
    }

    private void Die()
    {
        _animator.SetTrigger("Death");
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _death.Play();
    }

    public void LooseLife()
    {
        _state.LooseLife();
        _lifeTextMesh.text = _state.Life.ToString();
    }
}
