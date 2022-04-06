using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5;
    public bool isMoving;
    public Renderer rend;
    public Material normMat;
    public Material hoverMat;
    public Material moveMat;

    public Vector3 roundedPos;
    public float xPos;
    public float yPos;

    public float normalSizeX;
    public float normalSizeY;

    private void Awake()
    {
        Invoke("roundPosition", .2f);
        normalSizeX = transform.localScale.x;
        normalSizeY = transform.localScale.y;
    }
    private void OnMouseOver()
    {
        if (!GameManagerScript.instance.IsThereMovement)
        {
            rend.material = hoverMat;
            if (Input.GetKeyDown(KeyCode.A))
            {
                shrinkMover();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(-1 * speed, 0);
                //isMoving = true;
                GameManagerScript.instance.IsThereMovement = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                shrinkMover();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(1 * speed, 0);
                //isMoving = true;
                GameManagerScript.instance.IsThereMovement = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                shrinkMover();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(0, -1 * speed);
                //isMoving = true;
                GameManagerScript.instance.IsThereMovement = true;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                shrinkMover();
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = new Vector2(0, 1 * speed);
                //isMoving = true;
                GameManagerScript.instance.IsThereMovement = true;
            }
        }
        
    }
    private void OnMouseExit()
    {
        rend.material = normMat;
    }
    public void Update()
    {
        if(rb.velocity.magnitude > .1)
        {
            rend.material = moveMat;
        }
        if(rb.velocity.magnitude < .1 && rb.bodyType == RigidbodyType2D.Dynamic)
        {
            rb.velocity = new Vector2(0, 0);
            rend.material = normMat;
            //isMoving = false;
            GameManagerScript.instance.IsThereMovement = false;
            rb.bodyType = RigidbodyType2D.Static;
            roundPosition();
            unShrinkMover();
            
        }
    }
    void roundPosition()
    {
        xPos = rb.position.x * 4;
        yPos = rb.position.y * 4;

        roundedPos.x = Mathf.Round(xPos);
        roundedPos.y = Mathf.Round(yPos);
        roundedPos.x = roundedPos.x/4;
        roundedPos.y = roundedPos.y/4;
        transform.position = roundedPos;
    }
    void shrinkMover()
    {
        transform.localScale = new Vector3(normalSizeX * .95f, normalSizeY * .95f, 1);
    }
    void unShrinkMover()
    {
        transform.localScale = new Vector3(normalSizeX, normalSizeY, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {

            SceneManager.LoadScene(GameManagerScript.instance.sceneName);
        }

    }
}
