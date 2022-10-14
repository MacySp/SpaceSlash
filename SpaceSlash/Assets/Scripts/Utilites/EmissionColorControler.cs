using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionColorControler : MonoBehaviour
{
    [SerializeField] string chosenColor = "Black";
    // Start is called before the first frame update
    void Start()
    {
        // First you want to use the API with multiple materials
        // where 3 should be the index you want to use...
        var materials = GetComponent<Renderer>().materials;
        materials[3].SetColor("_EmissionColor", Color.chosenColor);

        // Another thing to note is that Unity 5 uses the concept of shader keywords extensively.
        // So if your material is initially configured to be without emission, then in order to enable emission, you need to enable // the keyword.
        materials[3].EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
