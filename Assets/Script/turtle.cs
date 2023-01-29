using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turtle : CatchAnimal
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
