using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System;
using System.IO;

/// <summary>
/// Automated build script for Unity 2D projects
/// This script demonstrates basic build automation concepts
/// </summary>
public class AutoBuildScript
{
    // Build configuration
    private static readonly string BUILD_PATH = "Builds";
    private static readonly string COMPANY_NAME = "YourCompany";
    private static readonly string PRODUCT_NAME = "YourGame";
    
    /// <summary>
    /// Build for Windows platform
    /// Can be called from command line: Unity -batchmode -quit -executeMethod AutoBuildScript.BuildWindows
    /// </summary>
    [MenuItem("Build/Build Windows")]
    public static void BuildWindows()
    {
        BuildGame(BuildTarget.StandaloneWindows64, "Windows");
    }
    
    /// <summary>
    /// Build for macOS platform
    /// </summary>
    [MenuItem("Build/Build macOS")]
    public static void BuildMacOS()
    {
        BuildGame(BuildTarget.StandaloneOSX, "macOS");
    }
    
    /// <summary>
    /// Build for Linux platform
    /// </summary>
    [MenuItem("Build/Build Linux")]
    public static void BuildLinux()
    {
        BuildGame(BuildTarget.StandaloneLinux64, "Linux");
    }
    
    /// <summary>
    /// Build for all supported platforms
    /// </summary>
    [MenuItem("Build/Build All Platforms")]
    public static void BuildAllPlatforms()
    {
        Debug.Log("Starting multi-platform build...");
        
        BuildWindows();
        BuildMacOS();
        BuildLinux();
        
        Debug.Log("Multi-platform build completed!");
    }
    
    /// <summary>
    /// Core build method
    /// </summary>
    private static void BuildGame(BuildTarget target, string platformName)
    {
        Debug.Log($"Starting build for {platformName}...");
        
        // Set up build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetEnabledScenes();
        buildPlayerOptions.locationPathName = GetBuildPath(target, platformName);
        buildPlayerOptions.target = target;
        buildPlayerOptions.options = BuildOptions.None;
        
        // Configure player settings
        ConfigurePlayerSettings();
        
        // Execute build
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        // Handle build result
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log($"{platformName} build succeeded: {summary.totalSize} bytes");
            Debug.Log($"Build location: {buildPlayerOptions.locationPathName}");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError($"{platformName} build failed!");
            
            // Log build errors for debugging
            foreach (BuildStep step in report.steps)
            {
                foreach (BuildStepMessage message in step.messages)
                {
                    if (message.type == LogType.Error || message.type == LogType.Exception)
                    {
                        Debug.LogError($"Build Error: {message.content}");
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// Get all enabled scenes in build settings
    /// </summary>
    private static string[] GetEnabledScenes()
    {
        var scenes = new string[EditorBuildSettings.scenes.Length];
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }
        return scenes;
    }
    
    /// <summary>
    /// Generate build path based on target platform
    /// </summary>
    private static string GetBuildPath(BuildTarget target, string platformName)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string fileName = PRODUCT_NAME;
        
        // Add platform-specific file extension
        switch (target)
        {
            case BuildTarget.StandaloneWindows64:
                fileName += ".exe";
                break;
            case BuildTarget.StandaloneOSX:
                fileName += ".app";
                break;
            case BuildTarget.StandaloneLinux64:
                // Linux executables typically don't have extensions
                break;
        }
        
        return Path.Combine(BUILD_PATH, platformName, timestamp, fileName);
    }
    
    /// <summary>
    /// Configure player settings for build
    /// </summary>
    private static void ConfigurePlayerSettings()
    {
        // Set company and product name
        PlayerSettings.companyName = COMPANY_NAME;
        PlayerSettings.productName = PRODUCT_NAME;
        
        // Auto-increment version (simple example)
        string currentVersion = PlayerSettings.bundleVersion;
        if (string.IsNullOrEmpty(currentVersion))
        {
            PlayerSettings.bundleVersion = "1.0.0";
        }
        else
        {
            // Simple version increment (patch level)
            var versionParts = currentVersion.Split('.');
            if (versionParts.Length >= 3 && int.TryParse(versionParts[2], out int patch))
            {
                versionParts[2] = (patch + 1).ToString();
                PlayerSettings.bundleVersion = string.Join(".", versionParts);
            }
        }
        
        // Set other common settings
        PlayerSettings.defaultIsNativeResolution = true;
        PlayerSettings.runInBackground = false;
        
        Debug.Log($"Build version: {PlayerSettings.bundleVersion}");
    }
    
    /// <summary>
    /// Clean build directory
    /// </summary>
    [MenuItem("Build/Clean Build Directory")]
    public static void CleanBuildDirectory()
    {
        if (Directory.Exists(BUILD_PATH))
        {
            Directory.Delete(BUILD_PATH, true);
            Debug.Log("Build directory cleaned.");
        }
        else
        {
            Debug.Log("Build directory doesn't exist - nothing to clean.");
        }
    }
    
    /// <summary>
    /// Open build directory in file explorer
    /// </summary>
    [MenuItem("Build/Open Build Directory")]
    public static void OpenBuildDirectory()
    {
        if (!Directory.Exists(BUILD_PATH))
        {
            Directory.CreateDirectory(BUILD_PATH);
        }
        
        EditorUtility.RevealInFinder(BUILD_PATH);
    }
}