using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public GameObject Leveler;
    public Vector3 localPosition;
    public int NowLevel { get; private set; } = 0;

    public void Switch()
    {
        var g = Instantiate(Leveler);
        g.GetComponent<Leveler>().Level = ++NowLevel;
        g.transform.parent = transform;
        g.transform.localPosition = localPosition;
    }
}
