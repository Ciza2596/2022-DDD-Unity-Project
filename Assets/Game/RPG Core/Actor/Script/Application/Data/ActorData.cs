using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Actor.Application.Data
{
    
    [CreateAssetMenu(fileName =  "New ActorData", menuName = "Data/ActorData")]
    public class ActorData : ScriptableObject
    {
        public string DataID;
        public Sprite MainSprite;

    }
}
