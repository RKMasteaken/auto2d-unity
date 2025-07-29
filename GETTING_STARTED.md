# Getting Started Guide

## System Requirements

### Minimum Requirements
- **Operating System:** Windows 10 64-bit, macOS 10.15+, or Ubuntu 18.04+
- **Processor:** Intel Core i3 or AMD equivalent
- **Memory:** 8 GB RAM
- **Graphics:** DirectX 11 compatible
- **Storage:** 10 GB available space
- **Network:** Internet connection required

### Recommended Requirements
- **Processor:** Intel Core i5 or AMD Ryzen 5
- **Memory:** 16 GB RAM
- **Graphics:** Dedicated GPU with 2GB+ VRAM
- **Storage:** SSD with 20 GB available space

## Installation Steps

### 1. Install Unity Hub
1. Download Unity Hub from [unity.com](https://unity.com/download)
2. Run the installer and follow the setup wizard
3. Create a Unity account or sign in

### 2. Install Unity Editor
1. Open Unity Hub
2. Go to "Installs" tab
3. Click "Install Editor"
4. Select Unity 2022.3 LTS (recommended version)
5. Add modules:
   - **Development Build Support** (for your target platform)
   - **Windows Build Support** (if on Windows)
   - **Mac Build Support** (if on Mac)
   - **Linux Build Support** (if on Linux)
   - **Documentation** (recommended)

### 3. Set Up Development Environment

#### Visual Studio Code (Recommended)
1. Download from [code.visualstudio.com](https://code.visualstudio.com/)
2. Install the following extensions:
   - C# for Visual Studio Code
   - Unity Code Snippets
   - Debugger for Unity
   - GitLens (for Git integration)

#### Alternative IDEs
- **Visual Studio Community** (Windows)
- **JetBrains Rider** (paid, all platforms)
- **MonoDevelop** (comes with Unity)

### 4. Git Setup
1. Install Git from [git-scm.com](https://git-scm.com/)
2. Configure your identity:
   ```bash
   git config --global user.name "Your Name"
   git config --global user.email "your.email@example.com"
   ```
3. Set up GitHub account if you don't have one

### 5. Clone Course Repository
```bash
git clone https://github.com/RKMasteaken/auto2d-unity.git
cd auto2d-unity
```

## First Unity Project

### Creating Your First 2D Project
1. Open Unity Hub
2. Click "New Project"
3. Select "2D Core" template
4. Choose project location
5. Name your project (e.g., "MyFirst2DGame")
6. Click "Create Project"

### Essential Unity Settings for 2D
Once your project opens:

1. **Player Settings:**
   - Go to Edit → Project Settings → Player
   - Set Company Name and Product Name
   - Configure icons and splash screen

2. **Quality Settings:**
   - Go to Edit → Project Settings → Quality
   - Review quality levels for target platforms

3. **Input Settings:**
   - Go to Edit → Project Settings → Input Manager
   - Familiarize yourself with input axes

4. **Physics2D Settings:**
   - Go to Edit → Project Settings → Physics2D
   - Understand gravity and collision settings

## Course Preparation Checklist

Before starting Week 1, ensure you have:

- [ ] Unity Hub installed
- [ ] Unity 2022.3 LTS installed with required modules
- [ ] Code editor set up (VS Code recommended)
- [ ] Git installed and configured
- [ ] GitHub account created
- [ ] Course repository cloned
- [ ] Created your first 2D Unity project
- [ ] Joined course discussion forum
- [ ] Reviewed course outline

## Troubleshooting Common Issues

### Unity Won't Start
- Check system requirements
- Update graphics drivers
- Run as administrator (Windows)
- Check antivirus software isn't blocking Unity

### Slow Performance
- Close unnecessary applications
- Increase virtual memory (Windows)
- Clear Unity cache: Delete `~/Library/Unity` (Mac) or `%LOCALAPPDATA%\\Unity` (Windows)

### Git Issues
- Ensure Git is in your system PATH
- Use Git Bash on Windows for better compatibility
- Check SSH key setup for GitHub

### Visual Studio Code Not Recognizing Unity
- Install C# extension
- Reload VS Code after installing Unity
- Check Unity preferences: External Tools → External Script Editor

## Next Steps

1. Read through the complete [Course Outline](./COURSE_OUTLINE.md)
2. Set up your workspace and organize files
3. Join the course discussion forum
4. Complete the Week 1 preparation activities
5. Attend the first live session or watch the recorded version

## Getting Help

If you encounter issues during setup:
1. Check this troubleshooting guide
2. Search the course discussion forum
3. Post a question with detailed error information
4. Attend office hours for live support

## Additional Resources

- [Unity Learn Platform](https://learn.unity.com/) - Free Unity tutorials
- [Unity Documentation](https://docs.unity3d.com/) - Complete reference
- [C# Fundamentals](https://docs.microsoft.com/en-us/dotnet/csharp/) - Programming basics
- [Git Tutorial](https://git-scm.com/docs/gittutorial) - Version control basics

Good luck with your Unity 2D automation journey!