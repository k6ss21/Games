using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ref
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float topPadding = 5f;
    [SerializeField] float padding = 1f;
    [SerializeField] int playerHealth = 200;
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.75f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 25f;
    [SerializeField] float projectileFirePeriod= 0.05f;
   


    Coroutine FiringCoroutine;


    float xMin, xMax;
    float yMin, yMax;
    
    //start
    void Start()
    {
        SetUpMovebountaries();
       
    }

   

    //update
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
           FiringCoroutine = StartCoroutine(FireContinuosly());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(FiringCoroutine);
        }
    }
    IEnumerator FireContinuosly() 
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFirePeriod);
        }

    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        var newXpos =Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);


        transform.position = new Vector2(newXpos, newYpos);
        
    }

    private void SetUpMovebountaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - topPadding;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamageToPlayer();
        damageDealer.Hit();
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return playerHealth;
    }
    private void Die()
    {
        FindObjectOfType<level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
        
        
    }
}



