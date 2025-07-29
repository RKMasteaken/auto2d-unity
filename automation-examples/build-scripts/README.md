# Build Automation Scripts

This folder contains automated build scripts for Unity 2D projects.

## Files

### AutoBuildScript.cs
A comprehensive build automation script that demonstrates:
- Multi-platform builds (Windows, macOS, Linux)
- Automatic version incrementing
- Build result logging and error handling
- Menu integration for easy access
- Command-line build support

## Usage

### In Unity Editor
1. Copy `AutoBuildScript.cs` to your project's `Editor` folder
2. Use the **Build** menu to access build functions:
   - Build → Build Windows
   - Build → Build macOS  
   - Build → Build Linux
   - Build → Build All Platforms
   - Build → Clean Build Directory
   - Build → Open Build Directory

### Command Line
Build from command line for CI/CD integration:

```bash
# Build for Windows
Unity -batchmode -quit -projectPath /path/to/project -executeMethod AutoBuildScript.BuildWindows

# Build for macOS
Unity -batchmode -quit -projectPath /path/to/project -executeMethod AutoBuildScript.BuildMacOS

# Build for Linux
Unity -batchmode -quit -projectPath /path/to/project -executeMethod AutoBuildScript.BuildLinux

# Build all platforms
Unity -batchmode -quit -projectPath /path/to/project -executeMethod AutoBuildScript.BuildAllPlatforms
```

## Features

### Automatic Version Management
- Reads current version from PlayerSettings
- Auto-increments patch version for each build
- Supports semantic versioning (major.minor.patch)

### Build Organization
- Creates timestamped build folders
- Organizes builds by platform
- Maintains build history

### Error Handling
- Comprehensive build result logging
- Error message extraction and display
- Build failure detection and reporting

### Customization
Modify these constants at the top of the script:
```csharp
private static readonly string BUILD_PATH = "Builds";
private static readonly string COMPANY_NAME = "YourCompany";
private static readonly string PRODUCT_NAME = "YourGame";
```

## Directory Structure
After running builds, you'll see:
```
Builds/
├── Windows/
│   └── 2024-01-15_14-30-45/
│       └── YourGame.exe
├── macOS/
│   └── 2024-01-15_14-32-10/
│       └── YourGame.app
└── Linux/
    └── 2024-01-15_14-33-25/
        └── YourGame
```

## Integration with CI/CD

This script is designed to work with continuous integration systems:

### GitHub Actions Example
```yaml
- name: Build Windows
  run: |
    Unity -batchmode -quit -projectPath . -executeMethod AutoBuildScript.BuildWindows
```

### Unity Cloud Build
Configure build methods in Unity Cloud Build settings:
- Target Method: `AutoBuildScript.BuildWindows`
- Target Method: `AutoBuildScript.BuildMacOS`
- Target Method: `AutoBuildScript.BuildLinux`

## Extending the Script

### Adding New Platforms
To add mobile platforms:
```csharp
[MenuItem("Build/Build Android")]
public static void BuildAndroid()
{
    BuildGame(BuildTarget.Android, "Android");
}

[MenuItem("Build/Build iOS")]
public static void BuildiOS()
{
    BuildGame(BuildTarget.iOS, "iOS");
}
```

### Custom Build Options
Modify `BuildPlayerOptions` for specific needs:
```csharp
buildPlayerOptions.options = BuildOptions.Development | BuildOptions.ConnectWithProfiler;
```

### Advanced Version Management
Implement Git-based versioning:
```csharp
private static string GetVersionFromGit()
{
    // Get version from Git tags
    // Implementation depends on your versioning strategy
}
```

## Best Practices

1. **Version Control**: Add `Builds/` to `.gitignore`
2. **Automation**: Use with CI/CD for consistent builds
3. **Testing**: Always test builds on target platforms
4. **Documentation**: Keep build logs for troubleshooting
5. **Security**: Don't include sensitive data in automated builds

## Troubleshooting

### Common Issues
- **Build fails**: Check console for specific error messages
- **Missing scenes**: Ensure all scenes are added to Build Settings
- **Platform not available**: Install required platform modules in Unity Hub
- **Permission errors**: Check write permissions for build directory

### Debug Tips
- Enable Development Build for debugging
- Use Build Settings validation before automated builds
- Check PlayerSettings for required configurations
- Verify all dependencies are included

This automation script serves as a foundation for more complex build pipelines and can be extended based on your project's specific requirements.