using UnityEngine;
using UnityEngine.UI;

public class Screen_Manager : MonoBehaviour
{
    public Player player;
    public Text health_bar;
    public Scrollbar scrollbar;
    public AudioSource source;
    public GameObject Panel;
    public GameObject Task;
    private BinaryPanel taskPanel;
    public GameObject GameOverPanel;
    public GameManager gameManager;
  
    private bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source.Play();
        taskPanel = Task.GetComponent<BinaryPanel>();
        taskPanel.receiver = player.inventory;
        Task.SetActive(false);

    }

    public void OpenTask()
    {
        Task.SetActive(true);
        player.can_move_set(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (taskPanel != null && taskPanel.isDone)
        {
            player.can_move_set(true);
        }
        if (player.health>0)
        {
            health_bar.text = player.health.ToString("0.");
            if (gameManager.isPaused)
            {
                Panel.SetActive(true);
            }
            else
            {
                Panel.SetActive(false);
            }
            source.volume = scrollbar.value;
        }
        else if(!isDead && player.health<=0)
        {

            GameOverPanel.SetActive(true);
            gameManager.TogglePause();
            isDead = true;
        }
        
        

    }
}
