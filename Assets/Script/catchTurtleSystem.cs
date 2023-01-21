using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catchTurtleSystem : MonoBehaviour
{
    public Button catchBtn;
    private bool canCatch;
    public int aimNumber;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        catchBtn.onClick.AddListener(catchBtnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void catchBtnClick()
    {
        print("clicked");
    }
}
