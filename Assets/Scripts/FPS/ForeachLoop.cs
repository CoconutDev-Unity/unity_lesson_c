using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ForeachLoop : MonoBehaviour
{
    [SerializeField] private List<int> _integerList;
    [SerializeField] private int[] _integerArray = new int[] {6, 7, 8, 9, 10};

    private void Start()
    {
        //_integerList = new List<int>(Enumerable.Range(1, 10));
        //_integerList.Add(5);
        //_integerList.AddRange(_integerArray);

        //foreach (int integer in _integerList)
        //{
        //    Debug.Log(integer);
        //}
    }
}
