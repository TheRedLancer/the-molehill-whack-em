using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleDeath : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return StartCoroutine("waitForAnimation");
        Destroy(gameObject);
    }

    IEnumerator waitForAnimation()
    {
        yield return new WaitForSeconds(.5f);
    }
}
