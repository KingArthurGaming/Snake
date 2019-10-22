using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    bool ate = false;
    private GameObject tails;
    public bool borderless= false;

    [HideInInspector]
    public bool isDied = false;
    public float time = 0.3f;
    public float rate = 0.3f;
    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;
    public Image image;
    public List<Sprite> sprites;
    public int score;
    private bool pause;
    private AudioManager audioManager;
    public Swipe swipe;
    public GameObject dead;
    public GameObject tailPrefab;

    Vector2 dir = Vector2.right;

    [HideInInspector]
    public List<Transform> tail = new List<Transform>();

    void Awake()
    {
        audioManager = gameObject.GetComponent<AudioManager>();
        tails = GameObject.FindGameObjectWithTag("Tails");
        InvokeRepeating("Move", time, rate);
        ate = true;
        Move();
        ate = true;
        Move();

    }
    public void UnPause()
    {
        pause = false;

        InvokeRepeating("Move", 0, 0.65f);
    }
    public void Pause()
    {
        pause = true;
    }

    void Update()
    {
        if (!isDied)
        {
            horizontal = Mathf.Ceil(Input.GetAxisRaw("Horizontal"));
            vertical = Mathf.Ceil(Input.GetAxisRaw("Vertical"));
             
            if (swipe.SwipeRight)
            {
                horizontal = 1;
                vertical = 0;
            }
            if (swipe.SwipeLeft)
            {
                horizontal = -1;
                vertical = 0;
            }
            if (swipe.SwipeUp)
            {
                horizontal = 0;
                vertical = 1;
            }
            if (swipe.SwipeDown)
            {
                horizontal = 0;
                vertical = -1;
            }
            
            if (horizontal > 0 && dir != Vector2.left)
            {
                dir = Vector2.right;
                image.sprite = sprites[1];
            }
            else if (horizontal < 0 && dir != Vector2.right)
            {
                dir = Vector2.left;
                image.sprite = sprites[0];

            }
            else if (vertical < 0 && dir != Vector2.up)
            {
                dir = Vector2.down;
                image.sprite = sprites[3];
            }
            else if (vertical > 0 && dir != Vector2.down)
            {
                dir = Vector2.up;

                image.sprite = sprites[2];
            }

            
        }
        
        else
        {
            dead.SetActive(true);

            FindObjectOfType<Score>().TopScore();
            if (Input.GetKey(KeyCode.R))
            {
                //clear the tail
                tail.Clear();

                //reset to origin
                transform.position = transform.TransformPoint(new Vector3(0, 85, 0));

                //make snake alive
                isDied = false;
            }
        }
    }

    void Move()
    {
        if (!isDied && !pause)
        {
            // Save current position (gap will be here)
            Vector2 v = transform.position;

            // Move head into new direction (now there is a gap)
            transform.Translate(dir * 20);

            // Ate something? Then insert new Element into gap
            if (ate)
            {
                for (int i = 0; i < 4; i++)
                {

                    GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity, tails.transform);

                    tail.Insert(0, g.transform);
                }

                // Reset the flag
                ate = false;
            }
            else if (tail.Count > 0)
            {   // Do we have a Tail?
                // Move last Tail Element to where the Head was
                tail.Last().position = v;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.name.StartsWith("Food"))
        {
            audioManager.Play("Bite");
            ate = true;
            score++;
            Destroy(coll.gameObject);
        }
        else if (coll.name.StartsWith("Up")&& borderless)
        {
            gameObject.transform.position = gameObject.transform.position-new Vector3(0,930,0);
        }
        else if (coll.name.StartsWith("Down")&&borderless)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 930, 0);
        }
        else if (coll.name.StartsWith("Right")&&borderless)
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(900, 0, 0);
        }
        else if (coll.name.StartsWith("Left")&&borderless)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(900, 0, 0);
        }
        else
        {

            isDied = true;
        }
    }
}
