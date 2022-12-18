using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DeathColider : MonoBehaviour
{
    [SerializeField] private PipeMover pipeMover;
    [SerializeField] private  GameObject deathEffect;
    private PlayerController playerController;
    private bool isDie;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        if (!isDie)
        {
            isDie = true;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        pipeMover.isActive = false;
        playerController.enabled = false;
        playerController.Stop();
        transform.DOScale(Vector3.zero, 0.3f);
        yield return new WaitForSeconds(0.1f);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("Game");
    }
}
