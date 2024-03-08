using UnityEngine;

[RequireComponent(typeof(move))]
public class Savaan : MonoBehaviour
{
    public move movement { get; private set; }

    [SerializeField] private GameObject FoodBPrefab;
    [SerializeField] private Transform FoodPos;

    public float force = 20f;

    public GameManagerScript gameManager;
    private void Awake()
    {
        this.movement = GetComponent<move>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
           // this.movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
           // this.movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
           // this.movement.SetDirection(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //this.movement.SetDirection(Vector2.left);
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
       GameObject projectile = Instantiate(FoodBPrefab, FoodPos.position, FoodPos.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(FoodPos.up * force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            gameManager.gameOver();
        }
    }
}

