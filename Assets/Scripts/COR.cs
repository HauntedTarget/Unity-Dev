using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = StartCoroutine(Timer(time));
        StartCoroutine("Test");
        StartCoroutine("WaitAction");
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;

        //if (time <= 0)
        //{
        //    Debug.Log("Timer Over");
        //    time = MAX_TIME;
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Debug.Log("Timer Over");

        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Test"); 
        yield return new WaitForSeconds(3);
        Debug.Log("Test 2");
        yield return new WaitForSeconds(3);
        Debug.Log("Test 3");
        go = true;

        StopCoroutine(timer);

        yield return null;
    }

    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
        Debug.Log("Going");
        yield return null;
    }
}
