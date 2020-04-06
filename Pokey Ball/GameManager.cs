using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//플레이어의 상태 확인
public enum PlayerState{ _JUMP, _CATCH ,_STAY , _GAMEOVER, _CLEAR }

public class GameManager : MonoBehaviour
{
    //게임 매니저 싱글톤 생성

    public static GameManager instance;
    public PlayerState currentPlayerState;

    GameObject player;
    GameObject bar;

    Transform RayPos;

    float nowTime;

    public int level;   //게임 레벨
    public int coin;    //획득 코인
    public int Score;   //획득 점수
    public bool OverPower = false; // 과녁중간 맞췄을때;

    public int getScore;
    public bool showScore = false;

    bool button;
   
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        currentPlayerState = PlayerState._STAY;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bar = GameObject.FindWithTag("Bar");
        bar.GetComponent<Transform>().position = new Vector3(GameObject.Find("StartPos").transform.position.x, GameObject.Find("StartPos").transform.position.y, 1.7f);
        button = true;
        nowTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState(currentPlayerState);
        GameObject.Find("RayPos").transform.position = new Vector3(player.transform.position.x,player.transform.position.y ,player.transform.position.z);

        if (currentPlayerState == PlayerState._STAY)
        {
            player.GetComponent<Transform>().position = GameObject.Find("PlayerPos").transform.position;
        }

    }

    


    void CheckGameState(PlayerState playerState)
    {

        if (playerState == PlayerState._JUMP)
        {
            Invoke("DisEnabledBar", 0.1f);
            currentPlayerState = PlayerState._CATCH;

        }
        else if (playerState == PlayerState._CATCH)
        {
            CatchPlayer();
        }

        else if (playerState == PlayerState._STAY)
        {
            bar.GetComponent<CapsuleCollider>().enabled = true;
            bar.GetComponent<MeshRenderer>().enabled = true;

        }
        else if (playerState == PlayerState._GAMEOVER)
        {
            GameOver();
        }
        else if (playerState == PlayerState._CLEAR) { }
    }



    void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    void DisEnabledBar()
    {
        bar.GetComponent<MeshRenderer>().enabled = false;
        bar.GetComponent<CapsuleCollider>().enabled = false;
    }
    void CatchPlayer()
    {
        if (button || currentPlayerState == PlayerState._CATCH)
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit();
                button = false;   
            }
        }
        else
        {
            nowTime += Time.deltaTime;
            if(nowTime > 0.5f)
            {
                button = true;
                nowTime = 0f;
            }
        }

    }

    void RaycastHit()
    {
        Ray ray = new Ray();
        RaycastHit hit;

        float newPosY = player.transform.position.y;    

        ray.origin = GameObject.Find("RayPos").transform.position;
        ray.direction = GameObject.Find("RayPos").transform.forward;

        bar.GetComponent<HingeJoint>().autoConfigureConnectedAnchor = false;
        bar.transform.position = new Vector3(bar.transform.position.x, newPosY, 1.7f);
        bar.GetComponent<HingeJoint>().autoConfigureConnectedAnchor = true;
        bar.GetComponent<MeshRenderer>().enabled = true;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f))
        {
            OverPower = false;
            Debug.Log(ray.origin.y);

            if (hit.collider.gameObject.tag == "GameOverCube")
            {
                currentPlayerState = PlayerState._GAMEOVER;
            }
            else if (hit.collider.gameObject.tag == "NomalCube" || hit.collider.gameObject.tag =="Target")
            {
                if (hit.collider.gameObject.tag == "NomalCube")
                {
                    GameObject.Find("HitPos").GetComponent<HitEffect>().OnEffect(newPosY, 1,hit.collider.transform);
                    StartCoroutine(CountingScore(150));
                }
                else
                {
                    GameObject.Find("HitPos").GetComponent<HitEffect>().OnEffect(newPosY, 2, hit.collider.transform);

                    StartCoroutine(CountingScore(hit.collider.gameObject.GetComponent<TargetScore>().Score));
                    if (hit.collider.gameObject.GetComponent<TargetScore>().Center) { OverPower = true; }
                }
                bar.transform.position = new Vector3(bar.transform.position.x, newPosY, 1.7f);
                bar.GetComponent<HingeJoint>().autoConfigureConnectedAnchor = true;
                currentPlayerState = PlayerState._STAY;
            }
            else if (hit.collider.gameObject.tag == "DestroyCube")
            {
                GameObject.Find("HitPos").GetComponent<HitEffect>().OnEffect(newPosY, 2, hit.collider.transform);

                StartCoroutine(CountingScore(250));
                hit.collider.GetComponent<ExpCube>().ExpCubeFx();              
                Invoke("DisEnabledBar", 0.05f);
                GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
            }          
            else
            {
                GameObject.Find("HitPos").GetComponent<HitEffect>().OnEffect(newPosY, 2, hit.collider.transform);

                Invoke("DisEnabledBar", 0.05f);
                GameObject.Find("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
        }
        else
        {
            Invoke("DisEnabledBar", 0.05f);
        }
    }

    IEnumerator CountingScore(int getscore)
    {
        getScore = getscore;

        showScore = true;

        int resultScore = Score + getscore;
        while(resultScore > Score)
        {
            Score += 10 ;
            yield return new WaitForSeconds(.00001f);
        }

    }

    

}
