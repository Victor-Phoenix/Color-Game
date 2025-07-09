using Unity.VisualScripting;
using UnityEngine;

public class PanelBehavior : MonoBehaviour
{

    Renderer rend;

    void Start()
    {

        rend = GetComponent<Renderer>();


    }

    public Color getColor()
    {
        return rend.material.color;
    }


    public void setColor(Color color)
    {
         rend.material.color = color;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Color color = getColor();
            Debug.Log("Player touched panel with color: " + color);
        }
    }
}
