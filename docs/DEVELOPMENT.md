# Development Guide

This guide is for developers who want to contribute to or modify NetSpeedMonitor.

## Table of Contents

- [Development Environment Setup](#development-environment-setup)
- [Project Architecture](#project-architecture)
- [Code Structure](#code-structure)
- [Key Components](#key-components)
- [Development Workflow](#development-workflow)
- [Testing](#testing)
- [Code Style](#code-style)
- [Adding Features](#adding-features)

## Development Environment Setup

### Required Tools

1. **Visual Studio 2019 or later** (Community edition is free)
   - Download: [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
   - Required workloads:
     - .NET desktop development
     - Windows Forms development

2. **.NET Framework 4.8 Developer Pack**
   - Usually included with Visual Studio
   - Standalone: [Microsoft Download](https://dotnet.microsoft.com/download/dotnet-framework/net48)

3. **Git** (for version control)
   - Download: [Git Downloads](https://git-scm.com/downloads)

### Setup Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/alpharibbin/NetSpeedMonitor.git
   cd NetSpeedMonitor
   ```

2. **Open in Visual Studio**
   - Open `NetSpeedMonitor.slnx`
   - Visual Studio will restore dependencies automatically

3. **Build the Project**
   - Press `Ctrl+Shift+B` or Build → Build Solution
   - Verify no errors

4. **Run the Application**
   - Press `F5` to run with debugging
   - Or `Ctrl+F5` to run without debugging

## Project Architecture

### Overview

NetSpeedMonitor is a Windows Forms application with the following architecture:

```
┌─────────────────┐
│   Program.cs    │  Entry point, initializes application
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   TrayApp.cs    │  System tray integration, application context
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  SpeedWindow.cs │  Main UI window, network monitoring logic
└─────────────────┘
```

### Application Flow

1. **Program.cs** → Creates and runs `TrayApp`
2. **TrayApp** → Creates system tray icon and `SpeedWindow`
3. **SpeedWindow** → Initializes Performance Counters and Timer
4. **Timer** → Updates speed display every second

## Code Structure

### Main Files

#### `Program.cs`
- Application entry point
- Sets up Windows Forms application
- Creates `TrayApp` instance

**Key Responsibilities:**
- Enable visual styles
- Set compatible text rendering
- Start application context

#### `TrayApp.cs`
- Manages system tray integration
- Handles application lifecycle
- Provides context menu

**Key Responsibilities:**
- Create and manage `NotifyIcon`
- Handle tray icon events (double-click, right-click)
- Manage `SpeedWindow` visibility
- Handle application exit

#### `SpeedWindow.cs`
- Main UI window
- Network speed monitoring
- Window positioning and dragging

**Key Responsibilities:**
- Initialize Performance Counters
- Update speed display
- Handle window dragging
- Format speed values
- Position window

#### `Form1.cs`
- Currently unused (legacy form)
- Can be removed or repurposed

## Key Components

### Performance Counters

```csharp
// Network Interface Performance Counters
var cat = new PerformanceCounterCategory("Network Interface");
var names = cat.GetInstanceNames();

_down = names.Select(n =>
    new PerformanceCounter("Network Interface", "Bytes Received/sec", n)
).ToArray();

_up = names.Select(n =>
    new PerformanceCounter("Network Interface", "Bytes Sent/sec", n)
).ToArray();
```

**How it works:**
- Queries Windows Performance Counters
- Monitors all network interfaces
- Aggregates bytes received/sent per second
- Updates every 1 second

### Timer-Based Updates

```csharp
_timer = new Timer();
_timer.Interval = 1000; // 1 second
_timer.Tick += (s, e) => UpdateText();
_timer.Start();
```

**Update Process:**
1. Timer fires every second
2. Reads current counter values
3. Aggregates across all interfaces
4. Formats and displays speeds

### Window Dragging

```csharp
private void DragStart(object sender, MouseEventArgs e)
{
    _dragging = true;
    _dragCursor = Cursor.Position;
    _dragForm = Location;
}
```

**Drag Logic:**
- Tracks mouse position relative to window
- Calculates new position on mouse move
- Constrains window to screen bounds
- Updates window location

## Development Workflow

### Making Changes

1. **Create a Branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

2. **Make Changes**
   - Edit code in Visual Studio
   - Test your changes (`F5` to run)

3. **Test Thoroughly**
   - Test on different Windows versions if possible
   - Verify network monitoring works correctly
   - Check window behavior (dragging, positioning)

4. **Commit Changes**
   ```bash
   git add .
   git commit -m "Description of changes"
   ```

5. **Push and Create Pull Request**
   ```bash
   git push origin feature/your-feature-name
   ```

### Debugging

**Using Visual Studio Debugger:**
1. Set breakpoints (click left margin or `F9`)
2. Press `F5` to start debugging
3. Use Debug windows:
   - **Watch**: Monitor variable values
   - **Locals**: See local variables
   - **Call Stack**: View method calls

**Common Debug Scenarios:**
- Performance Counter access issues
- Window positioning problems
- Timer update logic
- Drag and drop behavior

## Testing

### Manual Testing Checklist

- [ ] Application starts without errors
- [ ] System tray icon appears
- [ ] Speed window displays correctly
- [ ] Network speeds update every second
- [ ] Window can be dragged
- [ ] Window stays within screen bounds
- [ ] Double-click tray icon toggles visibility
- [ ] Right-click → Exit closes application
- [ ] Window positions correctly on first launch
- [ ] Works with multiple network interfaces

### Testing Network Monitoring

1. **Test with Active Downloads**
   - Start a large file download
   - Verify download speed increases
   - Check formatting (KB/s or MB/s)

2. **Test with Uploads**
   - Upload a file to cloud storage
   - Verify upload speed displays
   - Check accuracy

3. **Test with No Activity**
   - Disconnect network
   - Verify speeds show 0.0 B/s
   - Reconnect and verify updates

## Code Style

### Naming Conventions

- **Classes**: PascalCase (`SpeedWindow`, `TrayApp`)
- **Methods**: PascalCase (`UpdateText`, `InitializeForm`)
- **Variables**: camelCase (`_timer`, `_label`, `_dragging`)
- **Private Fields**: Prefix with underscore (`_timer`, `_label`)
- **Constants**: PascalCase (`K`, `M`)

### Code Organization

- Group related methods together
- Use regions for major sections (optional)
- Keep methods focused and small
- Add comments for complex logic

### Example Style

```csharp
// Good
private void UpdateText()
{
    float down = 0, up = 0;
    try { down = _down.Sum(c => c.NextValue()); } catch { }
    try { up = _up.Sum(c => c.NextValue()); } catch { }
    string speed = $"↓ {Format(down)}\n↑ {Format(up)}";
    _label.Text = speed;
}

// Avoid
private void UpdateText() { /* long method with multiple responsibilities */ }
```

## Adding Features

### Potential Enhancements

1. **Settings/Configuration**
   - Save window position
   - Customizable update interval
   - Color themes
   - Font size options

2. **Additional Display Options**
   - Show total data transferred
   - Show peak speeds
   - Graph/history view
   - Per-interface breakdown

3. **User Interface**
   - Settings window
   - Context menu options
   - Keyboard shortcuts
   - Minimize to tray option

4. **Performance**
   - Reduce CPU usage
   - Optimize counter queries
   - Add caching if needed

### Implementation Guidelines

**Adding a New Feature:**

1. **Plan the Feature**
   - Define requirements
   - Design UI/UX (if applicable)
   - Consider edge cases

2. **Implement**
   - Create feature branch
   - Write code following style guidelines
   - Add error handling

3. **Test**
   - Manual testing
   - Test edge cases
   - Verify no regressions

4. **Document**
   - Update README if needed
   - Add code comments
   - Update usage guide

### Example: Adding Settings

```csharp
// Create Settings.cs
public class AppSettings
{
    public Point WindowPosition { get; set; }
    public int UpdateInterval { get; set; } = 1000;
    // ... other settings
}

// Save on window move
private void DragEnd(object sender, MouseEventArgs e)
{
    _dragging = false;
    Settings.SaveWindowPosition(Location);
}
```

## Dependencies

### Current Dependencies

- **System.Windows.Forms**: UI framework
- **System.Diagnostics**: Performance Counters
- **System.Drawing**: Graphics and colors
- **System.Linq**: LINQ queries

### No External NuGet Packages

The project currently uses only .NET Framework built-in libraries. Consider adding:
- **Newtonsoft.Json**: For settings persistence (if needed)
- **NLog/Serilog**: For logging (if needed)

## Build Configuration

### Debug vs Release

- **Debug**: Full symbols, no optimization, detailed error info
- **Release**: Optimized, PDB only, production-ready

### Output Files

- `NetSpeedMonitor.exe`: Main executable
- `NetSpeedMonitor.pdb`: Debug symbols
- `NetSpeedMonitor.exe.config`: Configuration file

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for contribution guidelines.

### Before Submitting

- [ ] Code follows style guidelines
- [ ] All tests pass
- [ ] No compiler warnings
- [ ] Documentation updated
- [ ] Commit messages are clear

## Resources

- [Windows Forms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Performance Counters](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.performancecounter)
- [.NET Framework API Reference](https://docs.microsoft.com/en-us/dotnet/api/)

---

**Questions?** Open an issue or start a discussion on GitHub.

