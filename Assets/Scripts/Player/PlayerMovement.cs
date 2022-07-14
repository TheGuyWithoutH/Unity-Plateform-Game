using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MovingObject
{
    [FormerlySerializedAs("rigidbody2D")] public Rigidbody2D _rigidbody2D;
    [SerializeField] private Joystick _joystick = null;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;
    private Animator anim;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float speed = 7f;

    [SerializeField] private AudioSource _jump;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            float dirX;
                
            if (_joystick == null)
            {
                dirX = Input.GetAxisRaw("Horizontal");
                _rigidbody2D.velocity = new Vector2(dirX * speed, _rigidbody2D.velocity.y);

                if (Input.GetButtonDown("Jump") && CheckGround())
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 2 * speed);
                    _jump.Play();
                }
            }
            else
            {
                dirX = _joystick.Horizontal;
                _rigidbody2D.velocity = new Vector2(dirX * speed, _rigidbody2D.velocity.y);

                if (_joystick.Vertical > .7f && CheckGround())
                {
                    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 2 * speed);
                    _jump.Play();
                }

            }
            
                UpdateAnimation(dirX);
        }
    }

    private void UpdateAnimation(float dirX)
    {
        if (_rigidbody2D.velocity.y > 0.1f || _rigidbody2D.velocity.y < -0.1f)
        {
            anim.SetInteger("State", (int)movementState.Jumping);
        } else if (dirX != 0f)
        {
            anim.SetInteger("State", (int)movementState.Running);
        }
        else
        {
            anim.SetInteger("State", (int)movementState.Idle);
        }
        
        _renderer.flipX = dirX < 0f;
    }

    public void EnableMoving(bool enable)
    {
        isActive = enable;
    }

    private bool CheckGround()
    {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, .1f, _groundLayer);
    }
    
    private enum movementState
    {
        Idle,
        Running,
        Jumping
    }
}
