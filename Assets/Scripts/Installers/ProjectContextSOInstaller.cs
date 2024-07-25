using Scripts;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ProjectContextSOInstaller", menuName = "Installers/ProjectContextSOInstaller")]
public class ProjectContextSOInstaller : ScriptableObjectInstaller<ProjectContextSOInstaller>
{
    [SerializeField]
    private GameConfiguration _gameConfiguration;

    public override void InstallBindings()
    {
        Container
            .BindInstance(_gameConfiguration)
            .AsSingle();
    }
}