
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameObject killPlayer;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" )
        {

           
                Destroy(collision.gameObject);
                FindObjectOfType<GameManager>().GameOver();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

    }

}
