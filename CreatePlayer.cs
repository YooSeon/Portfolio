using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviour
{
    //게임 시작 시 케릭터 생성을 위한 변수
    FixedJoystick fixedJoystick;
    public bool start = true;
    public GameObject sheep;
    public GameObject duck;
    public GameObject peng;

    //게임 진행 시 조이스틱 조작을 위한 변수
    Rigidbody Player;
    Transform tr;
    Animator anim;
    public bool isJump = false;
    public float speed;
    public float JumpPower;
    public float maxJump = 10f;

    public AudioSource audio;


    // Start is called before the first frame update

    //GameManager

    private void Awake()
    {
        if (start && SceneManager.GetActiveScene().name != "GameOver")
        {
            createPlayer();
        }

       
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.right * fixedJoystick.Horizontal;

        Player.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (fixedJoystick.Horizontal > 0)
        {
            tr.eulerAngles = new Vector3(0, 90, 0);
            anim.SetBool("Walk", true);
        }
        else if (fixedJoystick.Horizontal < 0)
        {
            tr.eulerAngles = new Vector3(0, 270, 0);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if(isJump)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (tr.position.y < -20f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Jump()
    {
        if (!isJump)
        {
            audio.Play();
            isJump = true;
            Player.AddForce(0f, JumpPower, 0f, ForceMode.Impulse);
        }
    }

    void createPlayer()
    {
        fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 1)
        {
            Instantiate(sheep, sheep.transform.position, sheep.transform.rotation);
            Player = GameObject.Find("Sheep(Clone)").GetComponent<Rigidbody>();
            anim = GameObject.Find("Sheep(Clone)").GetComponent<Animator>();
            tr = GameObject.Find("Sheep(Clone)").GetComponent<Transform>();
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 2)
        {
            Instantiate(duck, duck.transform.position, duck.transform.rotation);
            Player = GameObject.Find("Duck(Clone)").GetComponent<Rigidbody>();
            anim = GameObject.Find("Duck(Clone)").GetComponent<Animator>();
            tr = GameObject.Find("Duck(Clone)").GetComponent<Transform>();
        }
        else if (GameObject.Find("GameManager").GetComponent<Distroy>().Name == 3)
        {
            Instantiate(peng, peng.transform.position, peng.transform.rotation);
            Player = GameObject.Find("Peng(Clone)").GetComponent<Rigidbody>();
            anim = GameObject.Find("Peng(Clone)").GetComponent<Animator>();
            tr = GameObject.Find("Peng(Clone)").GetComponent<Transform>();

        }
        start = false;
    }
}
