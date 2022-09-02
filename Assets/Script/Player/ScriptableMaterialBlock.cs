using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;

[CreateAssetMenu]
public class ScriptableMaterialBlock : ScriptableObject
{
    [SerializeField]
    public List<PlayerMaterialBlock> materialProperty;
}
