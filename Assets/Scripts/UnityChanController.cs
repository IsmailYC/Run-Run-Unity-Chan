using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnityChanController : MonoBehaviour {
    
    public GameObject mainCanvas;
    public Text mainScoreDisplay;
    public Text mainCoinDisplay;
    public Text scoreAmpDisplay;
    public GameObject gameOverCanvas;
    public Text overScoreDisplay;
    public Text overCoinDisplay;
    public Text overHighScoreDisplay;

    public AudioClip coinSFX;
    public AudioClip boxSFX;
    public AudioClip startSFX;
    public AudioClip jumpSFX;
    public AudioClip damageSFX;

    public float startSpeed;
    public float jumpPower;
    public float accelerationRate;

    Animator animator;
    Rigidbody rigidBody;
    AudioSource audioSource;
    Vector3 endPos;
    bool isGrounded;
    float startTime;
    float speed;
    float x;
    Vector3 touchDisplacement;
    int scoreAmp;
    int highscore;
    int score;
    int coins;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        highscore = PlayerPrefManager.GetHighScore();
        scoreAmp = PlayerPrefManager.GetScoreAmp();
        scoreAmpDisplay.text = "X" + scoreAmp.ToString();
        coins = PlayerPrefManager.GetCoins();
        mainCoinDisplay.text = coins.ToString();
        startTime = Time.time;
        speed = startSpeed;
        x = 0f;
        audioSource.PlayOneShot(startSFX);
	}

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE || UNITY_WEBGL
        if (GameManager.instance.isAlive)
        {
            score = (int)((Time.time - startTime) * scoreAmp*10);
            float dx = x - transform.position.x;
            animator.SetFloat("dX", dx);
            if (dx > 0.2f)
                dx = speed * Time.deltaTime;
            else if(dx<-0.2f)
                dx = -speed * Time.deltaTime;
            transform.Translate(speed * Time.deltaTime * Vector3.forward
                +dx*Vector3.right);
            mainScoreDisplay.text = score.ToString();
            animator.SetFloat("Velocity", speed);
            speed += accelerationRate * Time.deltaTime;
#if UNITY_ANDROID || UNITY_IOS
            if(Input.touchCount>0)
            {
                Touch firstTouch = Input.touches[0];
                if (firstTouch.phase == TouchPhase.Began)
                    touchDisplacement = Vector3.zero;
                else if (firstTouch.phase == TouchPhase.Ended)
                {
                    if(Mathf.Abs(touchDisplacement.x)>Mathf.Abs(touchDisplacement.y))
                    {
                        if (touchDisplacement.x > 0)
                            GoRight();
                        else
                            GoLeft();
                    }
                    else
                    {
                        if (touchDisplacement.y > 0)
                            Jump();
                        else
                            Slide();
                    }
                }
                else
                    touchDisplacement = touchDisplacement + Camera.main.ScreenToWorldPoint(firstTouch.deltaPosition);

            }
#else
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                GoLeft();
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                GoRight();
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                Jump();
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                Slide();
#endif
        }
        else
        {
            transform.position = endPos;
        }
#else

#endif
        }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("Grounded", isGrounded);
        }
        else if(other.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(boxSFX);
            if(isGrounded || rigidBody.velocity.y>0)
            {
                audioSource.PlayOneShot(damageSFX);
                endPos = new Vector3(transform.position.x, 0f, transform.position.z);
                StartCoroutine(Lose());
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("Grounded", isGrounded);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            audioSource.PlayOneShot(coinSFX);
            Destroy(other.gameObject);
            coins++;
            mainCoinDisplay.text = coins.ToString();
        }
    }

    void GoLeft()
    {
        if (transform.position.x >= -0.1f)
            x = Mathf.Round(transform.position.x - 2f);
    }

    void GoRight()
    {
        if (transform.position.x <= 0.1f)
            x = Mathf.Round(transform.position.x + 2f);
    }

    void Jump()
    {
        if(isGrounded)
        {
            audioSource.PlayOneShot(jumpSFX);
            animator.SetTrigger("Jump");
            rigidBody.AddForce(jumpPower*Vector3.up, ForceMode.VelocityChange);
        }
    }

    void Slide()
    {
        if(isGrounded)
        {
            audioSource.PlayOneShot(jumpSFX);
            animator.SetTrigger("Slide");
        }
        
    }

    IEnumerator Lose()
    {
        animator.SetTrigger("Lose");
        GameManager.instance.Die();
        yield return new WaitForSeconds(2.0f);
        mainCanvas.SetActive(false);
        overScoreDisplay.text = score.ToString();
        overCoinDisplay.text = coins.ToString();
        gameOverCanvas.SetActive(true);
        PlayerPrefManager.SetCoins(coins);
        if(score>highscore)
        {
            overHighScoreDisplay.text = "Best";
            PlayerPrefManager.SetHighScore(score);
        }
        else
        {
            overScoreDisplay.color = new Color(0.75f, 0.75f, 0.75f);
            overHighScoreDisplay.text = highscore.ToString();
        }
    }
}
