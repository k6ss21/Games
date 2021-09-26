using UnityEngine;

public class ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float ballLaunchx = 2f ;
     [SerializeField] float ballLaunchy = 15f;
     [SerializeField] AudioClip[] ballSounds;
     [SerializeField] float randomFactor = 0.2f;
    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cache comp

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
           paddleToBallVector = transform.position - paddle1.transform.position;
            myAudioSource = GetComponent<AudioSource>();
            myRigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
         LockBallToPaddle();
         LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
         Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }
    private void LaunchOnMouseClick()
    {
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted =true;
                myRigidbody2D.velocity = new Vector2(ballLaunchx,ballLaunchy);
            }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Vector2 velocityTweak = new Vector2
        (Random.Range(0f , randomFactor),
         Random.Range(0f, randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    
    }

}
