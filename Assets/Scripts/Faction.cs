using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faction : MonoBehaviour
{
    public string FactionName;

    public FactionType InternalType;

    [SerializeField]
    List<FactionTypeAndInt> FactionReputation = new List<FactionTypeAndInt>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
