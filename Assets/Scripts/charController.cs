using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D rigidbody2D;
    private Animator _animator;
    Vector3 charPos;
    [SerializeField] GameObject _camera;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal")*speed * Time.deltaTime), charPos.y);
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        



    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);

    }
}
