using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blade : MonoBehaviour
{
    public List<AudioClip> swing;

    public List<AudioClip> clash;

	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.

    private List<GameObject> enemyTouching;

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
        enemyTouching = new List<GameObject>();
	}


	void Update ()
	{
		// If the fire button is pressed...
		if(Input.GetButtonDown("Fire1"))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("Punch");
            
            if(enemyTouching.Count > 0)
            {
                foreach(GameObject g in enemyTouching)
                {
                    if(g != null)
                        g.GetComponent<Enemy>().Hurt();
                }
                GetComponent<AudioSource>().clip = chooseClash();
            }else
            {
                GetComponent<AudioSource>().clip = chooseSwing();
            }
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1.0f);
            GetComponent<AudioSource>().Play();
		}
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(!enemyTouching.Contains(collision.gameObject))
            {
                enemyTouching.Add(collision.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemyTouching.Remove(collision.gameObject);
        }
    }
    bool isPunching()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    AudioClip chooseClash()
    {
        int num = Random.Range(0, clash.Count - 1);
        return clash[num];        
    }
    AudioClip chooseSwing()
    {
        int num = Random.Range(0, swing.Count - 1);
        return swing[num];
    }
}
