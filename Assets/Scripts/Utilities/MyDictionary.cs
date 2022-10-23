using System.Collections;
using System;
using UnityEngine;

public class MyDictionary
{
    [Serializable]
    private struct Data {
        private object key;
        private object value;
    }
    private Data[] data;
}
