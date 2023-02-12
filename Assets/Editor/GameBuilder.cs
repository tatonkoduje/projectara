using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    [MenuItem("Build/Build Windows App")]
    public static void PerformWindowsBuild()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { 
            "Assets/Scenes/Menu.unity",
            "Assets/Scenes/Intro.unity",
            "Assets/Scenes/Game.unity" 
        };
        buildPlayerOptions.locationPathName = "build/windows/projectara.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Windows exe build succeeded: " + summary.totalSize + " bytes");
        }
        
        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed!");
        }
    }
}
