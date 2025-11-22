# Setup Guide

This guide will help you set up and install NetSpeedMonitor on your Windows system.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation Methods](#installation-methods)
- [First Run](#first-run)
- [Configuration](#configuration)
- [Troubleshooting](#troubleshooting)

## Prerequisites

Before installing NetSpeedMonitor, ensure your system meets the following requirements:

### System Requirements

- **Operating System**: Windows 7, 8, 8.1, 10, or 11
- **.NET Framework**: Version 4.8 or later
  - Most modern Windows systems have this pre-installed
  - If needed, download from [Microsoft's website](https://dotnet.microsoft.com/download/dotnet-framework/net48)

### Checking .NET Framework Version

1. Open **Control Panel** → **Programs** → **Programs and Features**
2. Look for "Microsoft .NET Framework 4.8" or higher
3. If not found, download and install from Microsoft

## Installation Methods

### Method 1: Using Pre-built Executable (Recommended)

This is the easiest method for end users.

#### Step 1: Download
1. Go to the [Releases](https://github.com/alpharibbin/NetSpeedMonitor/releases) page
2. Download the latest `NetSpeedMonitor.exe` file
3. Or download the entire release package

#### Step 2: Extract (if downloaded as ZIP)
1. Extract the ZIP file to a folder of your choice
2. Recommended location: `C:\Program Files\NetSpeedMonitor\` or your user folder

#### Step 3: Run
1. Double-click `NetSpeedMonitor.exe`
2. The application will start and appear in your system tray

**Note**: Windows Defender or antivirus may warn about an unknown executable. This is normal for unsigned applications. You may need to allow it through your antivirus.

### Method 2: Build from Source

If you want to build the application yourself, see [BUILD.md](BUILD.md) for detailed instructions.

## First Run

### Initial Setup

1. **Launch the Application**
   - Double-click `NetSpeedMonitor.exe`
   - The application will start and minimize to the system tray

2. **Locate the Speed Window**
   - The speed display window should appear in the bottom-right corner of your screen
   - If you don't see it, double-click the system tray icon

3. **Verify Network Monitoring**
   - The window should display:
     ```
     ↓ 0.0 B/s
     ↑ 0.0 B/s
     ```
   - If you have active network traffic, you should see values updating

4. **Position the Window** (Optional)
   - Click and drag the speed window to your preferred location
   - The window will stay in this position

### System Tray Icon

- **Icon**: Information icon (blue "i" in a circle)
- **Tooltip**: "Net Speed Monitor"
- **Location**: System tray (notification area) in the taskbar

## Configuration

Currently, NetSpeedMonitor runs with default settings. The application:

- Updates every 1 second
- Shows speeds in B/s, KB/s, or MB/s (auto-formatted)
- Monitors all active network interfaces
- Uses a dark theme with 92% opacity
- Positions in bottom-right corner on first launch

### Window Behavior

- **Always on Top**: The window stays above other applications
- **No Border**: Clean, minimal appearance
- **Draggable**: Click and drag to move anywhere on screen
- **Auto-sizing**: Window size adjusts to content

## Troubleshooting

### Application Won't Start

**Problem**: Double-clicking the executable does nothing.

**Solutions**:
1. Check if .NET Framework 4.8 is installed
2. Right-click → Properties → Check "Unblock" if present
3. Run as Administrator (right-click → Run as Administrator)
4. Check Windows Event Viewer for error messages

### Window Doesn't Appear

**Problem**: Application runs but no window is visible.

**Solutions**:
1. Check the system tray for the NetSpeedMonitor icon
2. Double-click the system tray icon
3. Check if the window is positioned off-screen (try moving it)
4. Restart the application

### Speed Shows 0.0 B/s

**Problem**: Network speed always shows zero.

**Solutions**:
1. Ensure you have an active network connection
2. Check if your network adapter is enabled
3. Some virtual adapters (VPNs, virtual machines) may not report correctly
4. Try disconnecting and reconnecting your network

### Performance Counter Errors

**Problem**: Application crashes or shows errors related to Performance Counters.

**Solutions**:
1. Run as Administrator (may be required for Performance Counter access)
2. Check Windows Performance Monitor to verify counters are accessible
3. Some Windows installations may have Performance Counters disabled

### Antivirus Blocking

**Problem**: Antivirus software blocks or quarantines the application.

**Solutions**:
1. Add NetSpeedMonitor.exe to your antivirus exclusion list
2. If using Windows Defender:
   - Open Windows Security
   - Go to Virus & threat protection
   - Add exclusion for the NetSpeedMonitor folder

### Window Position Issues

**Problem**: Window position resets or appears off-screen.

**Solutions**:
1. The window auto-positions on first launch
2. After manually positioning, it should stay in place
3. If it resets, try closing and reopening the application

## Uninstallation

To uninstall NetSpeedMonitor:

1. Right-click the system tray icon
2. Select "Exit"
3. Delete the `NetSpeedMonitor.exe` file
4. (Optional) Delete any configuration files if they exist

## Next Steps

- Learn how to use the application: [USAGE.md](USAGE.md)
- Build from source: [BUILD.md](BUILD.md)
- Contribute to development: [DEVELOPMENT.md](DEVELOPMENT.md)

---

**Need Help?** Open an issue on GitHub or check the main [README.md](../README.md) for more information.

