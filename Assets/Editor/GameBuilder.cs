using System;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    [MenuItem("Build/Build Windows App")]
    public static void PerformWindowsBuild()
    {
        PlayerSettings.companyName = "maapiid";
        var buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new[] { 
                "Assets/Scenes/Menu.unity",
                "Assets/Scenes/Intro.unity",
                "Assets/Scenes/Game.unity" 
            },
            locationPathName = "build/windows/projectara.exe",
            target = BuildTarget.StandaloneWindows,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        var summary = report.summary;

        switch (summary.result)
        {
            case BuildResult.Succeeded:
                Debug.Log("Windows exe build succeeded: " + summary.totalSize + " bytes");
                break;
            case BuildResult.Failed:
                Debug.Log("Build failed!");
                break;
            case BuildResult.Unknown:
                break;
            case BuildResult.Cancelled:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
