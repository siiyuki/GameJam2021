using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

/// <summary>
/// キーボード入力のオンオフをするためのクラス
/// </summary>
class Get : MonoBehaviour
{
    public static bool Set = true;

    public static bool Key(KeyCode key)
    {
        return Set && Input.GetKey(key);
    }

    public static bool KeyDown(KeyCode key)
    {
        return Set && Input.GetKeyDown(key);
    }

    public static bool KeyUp(KeyCode key)
    {
        return Set && Input.GetKeyUp(key);
    }

    public static bool MouseButton(int i)
    {
        return Set && Input.GetMouseButton(i);
    }

    public static bool MouseButtonDown(int i)
    {
        return Set && Input.GetMouseButtonDown(i);
    }

    public static bool MouseButtonUp(int i)
    {
        return Set && Input.GetMouseButtonUp(i);
    }
}
