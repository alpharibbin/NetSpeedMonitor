# Build Guide

This guide provides step-by-step instructions for building NetSpeedMonitor from source code.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Building with Visual Studio](#building-with-visual-studio)
- [Building with Command Line](#building-with-command-line)
- [Building with Visual Studio Code](#building-with-visual-studio-code)
- [Troubleshooting](#troubleshooting)

## Prerequisites

### Required Software

1. **Visual Studio 2019 or later** (Community edition is free)
   - Download from [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
   - Or use **Visual Studio Code** with C# extension
   - Or use **MSBuild** command line tools

2. **.NET Framework 4.8 Developer Pack**
   - Usually included with Visual Studio
   - If not, download from [Microsoft](https://dotnet.microsoft.com/download/dotnet-framework/net48)

3. **Git** (optional, for cloning the repository)
   - Download from [Git Downloads](https://git-scm.com/downloads)

### Verify Prerequisites

```powershell
# Check if .NET Framework is installed
Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\" | Select-Object -ExpandProperty Release

# Check MSBuild (if using command line)
msbuild -version
```

## Building with Visual Studio

This is the recommended method for most users.

### Step 1: Open the Solution

1. **Clone or Download** the repository
   ```bash
   git clone https://github.com/alpharibbin/NetSpeedMonitor.git
   cd NetSpeedMonitor
   ```
   Or download and extract the ZIP file

2. **Open Visual Studio**
   - Launch Visual Studio
   - File → Open → Project/Solution
   - Navigate to `NetSpeedMonitor.slnx` and open it

### Step 2: Restore Dependencies

Visual Studio should automatically restore NuGet packages (if any). If not:
- Right-click the solution → Restore NuGet Packages

### Step 3: Build the Project

**Option A: Using Menu**
1. Go to **Build** → **Build Solution** (or press `Ctrl+Shift+B`)
2. Wait for the build to complete
3. Check the Output window for any errors

**Option B: Using Configuration Manager**
1. Build → Configuration Manager
2. Select **Debug** or **Release** configuration
3. Click **Build**

### Step 4: Locate the Output

The compiled executable will be in:
- **Debug**: `bin\Debug\NetSpeedMonitor.exe`
- **Release**: `bin\Release\NetSpeedMonitor.exe` (if Release was built)

### Step 5: Run the Application

1. Right-click the project → **Set as StartUp Project**
2. Press `F5` to run, or `Ctrl+F5` to run without debugging
3. Or navigate to the output folder and double-click `NetSpeedMonitor.exe`

## Building with Command Line

Use this method if you prefer command-line tools or are setting up CI/CD.

### Step 1: Open Developer Command Prompt

1. Open **Start Menu**
2. Search for "Developer Command Prompt for VS" or "x64 Native Tools Command Prompt"
3. Or use PowerShell with MSBuild in PATH

### Step 2: Navigate to Project Directory

```powershell
cd D:\Tools\NetSpeedMonitor
# Or your project path
```

### Step 3: Build with MSBuild

**Debug Build:**
```powershell
msbuild NetSpeedMonitor.csproj /p:Configuration=Debug
```

**Release Build:**
```powershell
msbuild NetSpeedMonitor.csproj /p:Configuration=Release
```

**Clean and Rebuild:**
```powershell
msbuild NetSpeedMonitor.csproj /t:Clean,Build /p:Configuration=Release
```

### Step 4: Verify Output

```powershell
# Check if executable was created
dir bin\Release\NetSpeedMonitor.exe
# or
dir bin\Debug\NetSpeedMonitor.exe
```

## Building with Visual Studio Code

### Step 1: Install Extensions

1. Install **C#** extension by Microsoft
2. Install **.NET Framework** support (if needed)

### Step 2: Open the Project

1. File → Open Folder
2. Select the NetSpeedMonitor directory

### Step 3: Build

1. Open Terminal (`` Ctrl+` ``)
2. Run:
   ```powershell
   msbuild NetSpeedMonitor.csproj /p:Configuration=Release
   ```

Or use the Command Palette (`Ctrl+Shift+P`):
- Type "Tasks: Run Task"
- Select "build" if available

## Build Configurations

### Debug Configuration

- **Optimization**: Disabled
- **Debug Symbols**: Full
- **Output**: `bin\Debug\`
- **Use for**: Development and testing

### Release Configuration

- **Optimization**: Enabled
- **Debug Symbols**: PDB only
- **Output**: `bin\Release\`
- **Use for**: Distribution and production

## Project Structure

Understanding the build output:

```
NetSpeedMonitor/
├── bin/
│   ├── Debug/
│   │   ├── NetSpeedMonitor.exe      # Main executable
│   │   ├── NetSpeedMonitor.pdb      # Debug symbols
│   │   └── NetSpeedMonitor.exe.config
│   └── Release/
│       ├── NetSpeedMonitor.exe
│       └── NetSpeedMonitor.pdb
├── obj/                              # Intermediate build files
└── Properties/                       # Resources and settings
```

## Advanced Build Options

### Building for Specific Platform

```powershell
msbuild NetSpeedMonitor.csproj /p:Platform=AnyCPU /p:Configuration=Release
```

### Building with Specific .NET Framework Version

The project targets .NET Framework 4.8. To change:
1. Edit `NetSpeedMonitor.csproj`
2. Modify `<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>`
3. Rebuild

### Creating a Standalone Executable

The current build produces a standard .NET executable. For a self-contained deployment:
- Consider using .NET Core/.NET 5+ (requires project migration)
- Or use tools like ILMerge (advanced)

## Troubleshooting

### Build Errors

**Error: "The type or namespace name could not be found"**
- Solution: Ensure all references are properly included
- Check that System.Windows.Forms and System.Drawing are referenced

**Error: "MSBuild not found"**
- Solution: Install Visual Studio Build Tools or add MSBuild to PATH
- Or use Visual Studio Developer Command Prompt

**Error: ".NET Framework 4.8 not found"**
- Solution: Install .NET Framework 4.8 Developer Pack
- Or change target framework in project file

### Missing References

If you see missing reference errors:
1. Right-click References in Solution Explorer
2. Check that System, System.Windows.Forms, System.Drawing are present
3. If missing, right-click → Add Reference → Select from .NET tab

### Output Not Found

If the executable isn't in the expected location:
1. Check Build Output window for actual output path
2. Verify Configuration Manager settings
3. Try Clean Solution, then rebuild

## Next Steps

After building successfully:
- Test the application: [USAGE.md](USAGE.md)
- Set up development environment: [DEVELOPMENT.md](DEVELOPMENT.md)
- Contribute improvements: [CONTRIBUTING.md](CONTRIBUTING.md)

## CI/CD Integration

### GitHub Actions Example

```yaml
name: Build
on: [push, pull_request]
jobs:
  build:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v2
      - name: Setup MSBuild
        uses: microsoft/setup-msbuild@v1
      - name: Build
        run: msbuild NetSpeedMonitor.csproj /p:Configuration=Release
```

---

**Questions?** Check the main [README.md](../README.md) or open an issue on GitHub.

