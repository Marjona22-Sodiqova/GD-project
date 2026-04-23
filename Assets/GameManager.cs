using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int world { get; private set; } = 1;
    public int stage { get; private set; } = 1;
    public GameObject[] elements;
    public int i=0;
    private Camera mainCamera;
    private Logic_element current;
    private float scroll;
    private Logic_element holding_element;
    public Player player;
    public bool isPaused = false;
    public bool is_available()
    {
        return (current != null);
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        // if (Instance != null) {
        //     DestroyImmediate(gameObject);
        // } else {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
    }

    private void OnDestroy()
    {
        // if (Instance == this) {
        //     Instance = null;
        // }
    }

    private void Start()
    {
        // Application.targetFrameRate = 60;
        // NewGame();
    }

    // public void NewGame()
    // {
    //     lives = 3;
    //     coins = 0;

    //     LoadLevel(1, 2);
    // }

    // public void GameOver()
    // {
    //     NewGame();
    // }

    // public void LoadLevel(int world, int stage)
    // {
    //     this.world = world;
    //     this.stage = stage;

    //     SceneManager.LoadScene($"{world}-{stage}");
    // }

    // public void NextLevel()
    // {
    //     LoadLevel(world, stage + 1);
    // }

    // public void ResetLevel(float delay)
    // {
    //     CancelInvoke(nameof(ResetLevel));
    //     Invoke(nameof(ResetLevel), delay);
    // }

    // public void ResetLevel()
    // {
    //     lives--;

    //     if (lives > 0) {
    //         LoadLevel(world, stage);
    //     } else {
    //         GameOver();
    //     }
    // }


    // public void AddLife()
    // {
    //     lives++;
    // }

    public void Create_element()
    {
        if(current == null)
        {
            GameObject gm = Instantiate(elements[i]);

            current = gm.GetComponent<Logic_element>();
        }
        
    }

    private void current_id()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (i<elements.Length-1){ i++;}
            else {i=0;}
            Debug.Log(i);
            Destroy(current.gameObject);
            GameObject gm = Instantiate(elements[i]);
            current = gm.GetComponent<Logic_element>();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (i>0) {i--;}
            else {i=elements.Length-1;}
            Debug.Log(i);
            Destroy(current.gameObject);
            GameObject gm = Instantiate(elements[i]);
            current = gm.GetComponent<Logic_element>();
        }

    }

    private void Update()
    {
        if (current != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                // int x = Mathf.RoundToInt(worldPosition.x);
                // int y = Mathf.RoundToInt(worldPosition.z);

                Vector3 pos = new Vector3(Mathf.Round(worldPosition.x*10)/10, 0.5f, Mathf.Round(worldPosition.z*10)/10);


                //current.gameObject.transform.position = pos;
                // scroll += Input.GetAxis("Mouse ScrollWheel");
                // Debug.Log(scroll);
                float angle = 900 * Input.GetAxis("Mouse ScrollWheel") ;
                current.Replace(pos, angle);

                current_id();

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(current.gameObject);
                    Destroy(current.gameObject);
                    current = null;
                }
                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(current.gameObject);
                    current = null;
                }

            }
        }
        else if (current == null && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                // Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Debug.Log("Попал в: " + hit.collider.name);
                    // Debug.Log(hit.collider.gameObject.transform.position);
                    //grab_object = hit.collider.gameObject;
                    if(hit.collider.tag == "Chest")
                    {
                        //player.can_move_set(false);
                        hit.collider.gameObject.GetComponent<chest>().Open();

                    }
                }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Debug.Log("Pause");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Debug.Log(" Paused: ");
        }
        else
        {
            Debug.Log("Not Paused: ");
        }
        

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
