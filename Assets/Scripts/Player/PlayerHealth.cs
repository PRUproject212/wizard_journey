using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static event System.Action PlayerMoveToPointStart;
    public GameObject popupYouDie;
    public bool isDie = false;

    public GameObject EffectJump;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            AudioManager.Instance.PlaySfx("kill");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.DecreaseHealth();
            GetComponent<PlayerController>().UpdateAnimation();
            TutorialSceneController.Instance?.TutorialText.gameObject.SetActive(false);
            AudioManager.Instance.PlaySfx("die");
            isDie = true;

            StartCoroutine(deplay());
            if (GameManager.Instance.health == 0)
            {
                popupYouDie.SetActive(true);
            }
            else
            {
                isDie = false;
                PlayerMoveToPointStart?.Invoke();
            }
        }
    }

    IEnumerator deplay(){
        yield return new WaitForSeconds(6f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            AudioManager.Instance.PlaySfx("kill");
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else if (other.gameObject.tag == "ChainSaw")
        {
            GameManager.Instance.DecreaseHealth();
            AudioManager.Instance.PlaySfx("die");
            GetComponent<PlayerController>().UpdateAnimation();
            isDie = true;

            StartCoroutine(deplay());
            if (GameManager.Instance.health == 0)
            {
                popupYouDie.SetActive(true);
            }
            else
            {
                isDie = false;
                PlayerMoveToPointStart?.Invoke();
            }
        }
    }
}
