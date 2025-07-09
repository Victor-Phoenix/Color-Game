using Unity.VisualScripting;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{

    public Color[] color = new Color[9];
    private float timer = 3f;
    public Color choosenColor;
    PlayerMovement[] playerObjects;
    public GameObject player;

    private GameObject panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fillColorArray(this.color);

        panel = GameObject.Find("Dance Floor");


        playerObjects = FindObjectsByType<PlayerMovement>(FindObjectsSortMode.None);
        choosenColor = randomColor();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = 3.0f;
            Debug.Log("TIMER RESET");

            Color color = randomColor();


            foreach (PlayerMovement objects in playerObjects)
            {
                Color laColor = objects.GetCurrentPanelColor();
                Debug.Log($"Player Contact  : {laColor}");
                if (objects.GetCurrentPanelColor() != choosenColor)
                {
                    objects.DestroyPlayer();
                }

            }


            PanelBehavior[] panels = FindObjectsByType<PanelBehavior>(FindObjectsSortMode.None);
            foreach (PanelBehavior panel in panels)
            {
                panel.setColor(randomColor());
            }
            choosenColor = randomColor();

        }
    }

    void fillColorArray(Color[] color)
    {
        color[0] = Color.red;
        color[1] = Color.green;
        color[2] = Color.blue;
        color[3] = Color.white;
        color[4] = Color.pink;
        color[5] = Color.yellow;
        color[6] = Color.purple;
        color[7] = Color.black;
        color[8] = Color.orange;
    }

    public Color randomColor()
    {

        choosenColor = color[Random.Range(0, color.Length)];
        Debug.Log($"Choosen Color: {choosenColor}");
        return choosenColor;
    }
}
