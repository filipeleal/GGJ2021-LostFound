using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public PlayerControls playerControls;
    public Tilemap tilemap;

    private Vector3 destination;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speed = 5f;

    private SheepBehaviour sheep;


    public SpriteRenderer renderer;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        playerControls.Mouse.MouseClick.performed += MouseClick_performed;
    }

    private void MouseClick_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        var pos = Camera.main.ScreenToWorldPoint(playerControls.Mouse.MousePosition.ReadValue<Vector2>());
        pos.z = 0;

        Vector3Int gridPosition = tilemap.WorldToCell(pos);

        if (tilemap.HasTile(gridPosition))
        {
            destination = pos;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            animator.SetBool("IsMoving", true);

            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            if (destination.x >= transform.position.x)
                renderer.flipX = false;
            else
                renderer.flipX = true;

        }
        else
        {
            animator.SetBool("IsMoving", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (sheep != null)
            return;
        
        SheepBehaviour sheepCollision;
        if (collision.gameObject.TryGetComponent(out sheepCollision))
        {
            if (!sheepCollision.IsSafe())
            {
                sheep = sheepCollision;
                animator.SetBool("IsCarryingSheep", true);
                collision.gameObject.SetActive(false);
                speed /= 2;
            }
            else
            {
                sheep = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sheep != null)
        {
            if (collision.tag == "SafeArea")
            {
                Vector3 pos = Random.insideUnitCircle * GameManager.Instance.Radius;
                animator.SetBool("IsCarryingSheep", false);
                sheep.transform.position = GameManager.Instance.SpawnCenter.transform.position + pos;
                sheep.gameObject.SetActive(true);
                sheep = null;
                speed *= 2;
            }
        }
    }
}
