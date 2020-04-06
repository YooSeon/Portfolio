using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    //public float jumpAgle = 0f;
    //public float maxAngle = 6f;
    //public float plusJump = 4f;

    //public float rot = 0f;

    //public float restPos = 0f;



    //Transform tr;
    //Quaternion oldQut;
    //HingeJoint hin;
    //Rigidbody rb;


    //void Start()
    //{
    //    tr = this.GetComponent<Transform>();
    //    rb = this.GetComponent<Rigidbody>();
    //    oldQut = tr.rotation;

    //}

    //void Update()
    //{
    //    JointSpring spring = new JointSpring();

    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        if(jumpAgle >= maxAngle)
    //        {
    //            jumpAgle = maxAngle;
    //        }

    //        jumpAgle += plusJump * Time.deltaTime * 5f;   

    //        rot = (plusJump*5f) * (this.gameObject.GetComponent<HingeJoint>().limits.max/ maxAngle) * Time.deltaTime;

    //        tr.Rotate(rot, 0, 0);
    //    }

    //    else if(Input.GetKeyUp(KeyCode.Space))
    //    {
    //        jumpAgle = 0f;
    //        rot = 0f;
    //        spring.targetPosition = restPos;
    //    }

    //    hin.spring = spring;
    //    mat.material.SetFloat("_Amplitude", -jumpAgle);

    //}


    public MeshRenderer mat;

    public float restPosition = 0f;
    public float pressedPosition = 0f;
    public float hitStrenght = 10000f;
    public float flipperDamper = 150f;
    HingeJoint hinge;

    public bool Shake = false;
    public bool shot = false;

    public float mousPosY;
    public float nowMousePos;
    public float mousDown;




    // Start is called before the first frame update
    void Start()
    {

        mat = GetComponent<MeshRenderer>();

        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        mousPosY = 0;
        nowMousePos = 0;
        mousDown = 0;
    }

    // Update is called once per frame

    private void Update()  
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        if (Input.GetMouseButtonDown(0) && GameManager.instance.currentPlayerState != PlayerState._CATCH)
        {
            mousPosY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0) && GameManager.instance.currentPlayerState == PlayerState._STAY)
        {
            nowMousePos = Input.mousePosition.y;

            mousDown = (mousPosY - nowMousePos);
            if (mousDown > 150)
            {
                mousDown = 150;
            }
            else if (mousDown < 0)
            {
                mousDown = 0;
            }

            Shake = true;
            if (pressedPosition > 35f)
            {
                pressedPosition = 35f;
            }

            //pressedPosition += (20f + (mousDown / 150f)) * Time.deltaTime;

            pressedPosition = (mousDown*35 / 150);

            Debug.Log(mousDown);

            spring.targetPosition = pressedPosition;

        }
        if (Input.GetMouseButtonUp(0) && GameManager.instance.currentPlayerState == PlayerState._STAY && mousDown != 0)
        {
            mousPosY = 0;
            mousDown = 0;
            spring.targetPosition = restPosition;
            pressedPosition = 0f;
            GameManager.instance.currentPlayerState = PlayerState._JUMP;
            Shake = false;
        }
        else if (mousDown == 0)
        {
            Shake = false;

        }




        hinge.useLimits = true;
        hinge.spring = spring;
    }

    private void OnDestroy()
    {
        DontDestroyOnLoad(this);
    }
}
