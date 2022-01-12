using System.Collections.Generic;
using UnityEngine;


namespace Actor.Application.Data
{
    [CreateAssetMenu(fileName =  "New ActorDataOverview", menuName = "DataOverview/ActorDataOverview")]
    public class ActorDataOverview : ScriptableObject
    {
        [SerializeField] private List<ActorData> datas;

        public ActorData GetData(string dataId) {
            return datas.Find(data => data.DataID.Equals(dataId));

        }

        public ActorData GetRandomData() {
            var randomNumber = Random.Range(0, datas.Count);
            return datas[randomNumber];
        }
    }
}
