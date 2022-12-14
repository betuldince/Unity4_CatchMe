using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] TextMeshProUGUI m_Object;
SpawnManager spawnManager;
    public bool gameOver=false;
    public GameObject player;
    public GameObject replay;
    public GameObject lost;
    static int age = 21;
    public static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

            }
            return instance;
        }

    }

    private void Awake()
    {
        instance = this;
    }




void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -3)
        {
            gameOver = true;
            m_Object.text = "Yaşın:"+age;
            replay.SetActive(true);
            

        }
        if (age == 0)
        {
            lost.SetActive(true);
            replay.SetActive(false);
        }
                
        
    }
 

    public void Replay()
    {
        SceneManager.LoadScene(0);
        //decreaseAge();
        age--;
    }
}
