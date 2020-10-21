using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbilObjek : MonoBehaviour
{
    public GameObject bola;
    public GameObject tangan;
    public GameObject telapak;
    public Text imgText;
    bool tertangkap;
    public Vector3 posisiBola;

    private Coroutine currentCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!tertangkap)
            {
                bola.transform.SetParent(tangan.transform);
                bola.transform.localPosition = new Vector3(telapak.transform.localPosition.x + .15f, telapak.transform.localPosition.y - .2f, telapak.transform.localPosition.z + .6f);
                bola.GetComponent<Renderer>().material.color = Color.blue;

                imgText.text = "Bola ditangkap";
                imgText.gameObject.SetActive(true);

                if (currentCoroutine != null)
                    StopCoroutine(currentCoroutine);
                currentCoroutine = StartCoroutine(deactivateText());
            }
            else if (tertangkap)
            {
                bola.transform.SetParent(null);
                bola.transform.localPosition = posisiBola;
                bola.GetComponent<Renderer>().material.color = Color.red;

                imgText.text = "Bola dilepas";
                imgText.gameObject.SetActive(true);

                if (currentCoroutine != null)
                    StopCoroutine(currentCoroutine);
                currentCoroutine = StartCoroutine(deactivateText());
            }
            tertangkap = !tertangkap;
        }
    }

    IEnumerator deactivateText()
    {

        yield return new WaitForSeconds(3);

        imgText.gameObject.SetActive(false);
    }
}
