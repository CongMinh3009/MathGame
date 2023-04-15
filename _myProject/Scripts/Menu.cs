using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject FirstTimeMenu;
    public Transform Title;

	public Text M;

	public Text A;

	public Text T;

	public Text H;

	public Text G;

	public Text A_;

	public Text M_;

	public Text E;
	bool frisTime;

    private void Awake()
    {
		frisTime = true;
    }
    private void OnEnable()
    {
        foreach(Transform t in Title)
        {
            t.localScale = Vector3.one;
        }
        FirstTimeMenu.SetActive(frisTime);
        if(!frisTime)
        {
            M.text = "G";
            A.text = "A";
            T.text = "M";
            H.text = "E";
            G.text = "O";
            A_.text = "V";
            M_.text = "E";
            E.text = "R";
        } frisTime = false;
    }
    public void OnDisable()
    {
        foreach (Transform t in Title)
        {
            t.localScale = Vector3.one;
        }
    }
}
