using UnityEngine;
using Zenject;

public class ProjectFlow: IInitializable
{

    public void Initialize() {
        Application.targetFrameRate = 60;
    }
}