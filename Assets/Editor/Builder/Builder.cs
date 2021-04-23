using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

class Builder
{
    public static void BuildWin()
    {
        var buildPath = Path.Combine(Application.dataPath, "./../../Build/Win/Game_Win64.exe");
        Debug.Log("BUILD PATH: " + buildPath); // visible in editor.txt file 

        BuildPlayerOptions bpo = new BuildPlayerOptions();
        bpo.scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray();
        bpo.target = BuildTarget.StandaloneWindows64;
        bpo.targetGroup = BuildTargetGroup.Standalone;
        bpo.locationPathName = buildPath;
        LaunchBuild(bpo);
    }

    public static void BuildWebGL()
    {
        var buildPath = Path.Combine(Application.dataPath, "./../../Build/WebGL/");
        Debug.Log("BUILD PATH: " + buildPath); // visible in editor.txt file 

        BuildPlayerOptions bpo = new BuildPlayerOptions();
        bpo.scenes = EditorBuildSettings.scenes.Select(s => s.path).ToArray();
        bpo.target = BuildTarget.WebGL;
        bpo.targetGroup = BuildTargetGroup.WebGL;
        bpo.locationPathName = buildPath;
        LaunchBuild(bpo);
    }

    private static void LaunchBuild(BuildPlayerOptions bpo)
    {
        BuildReport report = BuildPipeline.BuildPlayer(bpo);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Cancelled)
        {
            Debug.Log("Build canceled");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
            Debug.Log(summary.options);
            Debug.Log(summary.result);
            Debug.Log(summary.totalErrors);
        }
        if (summary.result == BuildResult.Unknown)
        {
            Debug.Log(summary.options);
            Debug.Log(summary.result);
            Debug.Log(summary.totalErrors);
        }


        Debug.Log("Total Time: " + summary.totalTime);
    }

    [MenuItem("HelperFunctions / Build")]
    private static void LaunchBuilder()
    {
        try
        {
            System.Diagnostics.Process proc = null;
            string batDir = Path.Combine(Application.dataPath, "Editor/Builder");
            Debug.Log(batDir);
            proc = new System.Diagnostics.Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = "BuildWin.cmd";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();

        }catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }
    [MenuItem("HelperFunctions / PushToItch")]
    private static void PublishToItch()
    {
        try
        {
            System.Diagnostics.Process proc = null;
            string batDir = Path.Combine(Application.dataPath, "Editor/Builder");
            proc = new System.Diagnostics.Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = "PublishToItch.cmd";
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
