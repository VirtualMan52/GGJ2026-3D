using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private string loadType = "random";
    public string colorID = "none";
    [SerializeField] private Mesh[] bodyMeshes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GetComponentInChildren<Animator>()) GetComponentInChildren<Animator>().Play("salsa" + Random.Range(1,6));
        ResetCharacter();
    }

    public void ResetCharacter()
    {
        Renderer model = GetComponentInChildren<Renderer>();
        if (loadType == "player") model.materials[0].SetTexture("_BaseMap",Resources.Load<Texture2D>("clothing/clothingtex_black"));
        else if (loadType == "lover") model.materials[0].SetTexture("_BaseMap", Resources.Load<Texture2D>("clothing/clothingtex_white"));
        else
        {
            List<Material> mats = new List<Material>();

            model.materials[0].SetTexture("_BaseMap", Resources.Load<Texture2D>("clothing/clothingtex_" + colorID));

            mats.Add(model.materials[0]);
            mats.Add(Resources.Load<Material>("skin/skin" + Random.Range(1,7)));

            model.SetMaterials(mats);

            GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh = bodyMeshes[Random.Range(0, bodyMeshes.Length)];
        }
    }
}
