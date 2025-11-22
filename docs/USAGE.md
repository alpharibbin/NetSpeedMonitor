# Usage Guide

This guide explains how to use NetSpeedMonitor effectively.

## Table of Contents

- [Getting Started](#getting-started)
- [Basic Operations](#basic-operations)
- [Understanding the Display](#understanding-the-display)
- [Window Management](#window-management)
- [Tips and Tricks](#tips-and-tricks)
- [Common Scenarios](#common-scenarios)

## Getting Started

### Launching the Application

1. **Start NetSpeedMonitor**
   - Double-click `NetSpeedMonitor.exe`
   - The application starts and minimizes to the system tray

2. **Locate the Speed Window**
   - The speed display appears in the bottom-right corner
   - Shows current download (↓) and upload (↑) speeds

3. **Check System Tray**
   - Look for the blue information icon in your system tray
   - Hover over it to see "Net Speed Monitor" tooltip

## Basic Operations

### Showing/Hiding the Window

**Method 1: System Tray Double-Click**
- Double-click the system tray icon
- Window toggles between visible and hidden

**Method 2: System Tray Right-Click**
- Right-click the system tray icon
- Currently shows "Exit" option (window visibility toggle may be added in future)

### Moving the Window

1. **Click and Drag**
   - Click anywhere on the speed display window
   - Hold and drag to your desired location
   - Release to drop

2. **Position Constraints**
   - The window automatically stays within screen bounds
   - Cannot be dragged off-screen

### Exiting the Application

1. **Right-click** the system tray icon
2. Select **"Exit"**
3. The window closes and the application terminates

## Understanding the Display

### Speed Format

The window displays network speed in two lines:

```
↓ 2.5 MB/s
↑ 0.8 MB/s
```

- **↓ (Down Arrow)**: Download speed (data received)
- **↑ (Up Arrow)**: Upload speed (data sent)

### Speed Units

Speeds are automatically formatted for readability:

- **B/s** (Bytes per second): For speeds < 1 KB/s
  - Example: `↓ 512.0 B/s`

- **KB/s** (Kilobytes per second): For speeds 1 KB/s - 1 MB/s
  - Example: `↓ 256.5 KB/s`

- **MB/s** (Megabytes per second): For speeds ≥ 1 MB/s
  - Example: `↓ 2.5 MB/s`

### Update Frequency

- The display updates **every 1 second**
- Values represent average speed over the last second
- Real-time monitoring of all network interfaces

## Window Management

### Window Properties

- **Always on Top**: Stays visible above other windows
- **Semi-transparent**: 92% opacity for subtle overlay
- **No Border**: Clean, minimal appearance
- **Auto-sizing**: Window adjusts to fit content

### Positioning

**Initial Position:**
- Automatically positions in bottom-right corner on first launch
- Respects screen working area (excludes taskbar)

**Manual Positioning:**
- Drag to any location on your screen
- Position is remembered during the session
- Resets to bottom-right on application restart

### Window Behavior

- **Click-through**: Window can be clicked through (if needed)
- **Draggable**: Click and drag to move
- **Resizable**: Automatically sizes to content (not manually resizable)

## Tips and Tricks

### Optimal Placement

**Recommended Positions:**
- **Bottom-right corner**: Default, unobtrusive
- **Top-right corner**: Easy to see while working
- **Secondary monitor**: If using multiple displays

**Avoid:**
- Overlapping with frequently used UI elements
- Areas where you frequently click or type

### Monitoring Different Activities

**Download Monitoring:**
- Watch download speed when downloading files
- Monitor streaming quality indicators
- Track software update progress

**Upload Monitoring:**
- Monitor when uploading files or photos
- Check cloud sync activity
- Verify backup processes

**Both Directions:**
- Monitor overall network activity
- Detect unexpected network usage
- Track bandwidth consumption

### Performance Considerations

- **Low Resource Usage**: Minimal CPU and memory footprint
- **Background Operation**: Runs quietly in system tray
- **No Network Impact**: Only monitors, doesn't affect network performance

## Common Scenarios

### Scenario 1: Monitoring File Downloads

1. Start NetSpeedMonitor
2. Begin downloading a file
3. Watch the ↓ (download) speed increase
4. Verify download is progressing normally

### Scenario 2: Checking Upload Speed

1. Position window where you can see it
2. Start uploading a file (e.g., to cloud storage)
3. Monitor ↑ (upload) speed
4. Verify upload is using expected bandwidth

### Scenario 3: Detecting Network Activity

1. Keep window visible during normal computer use
2. Observe speed values
3. Identify unexpected network activity
4. Investigate if speeds are higher than expected

### Scenario 4: Gaming or Streaming

1. Position window in corner (not blocking game/stream)
2. Monitor network usage during gaming/streaming
3. Check if network is the bottleneck
4. Verify stable connection speeds

### Scenario 5: Troubleshooting Network Issues

1. Monitor speeds during network problems
2. Check if speeds drop to zero (connection issue)
3. Verify if speeds are unusually low
4. Use data to diagnose network problems

## Advanced Usage

### Multiple Network Interfaces

NetSpeedMonitor automatically:
- Detects all active network interfaces
- Aggregates speeds from all interfaces
- Shows combined total speed

**Note**: Virtual adapters (VPNs, VMs) may not always report correctly.

### Understanding Speed Values

**What the numbers mean:**
- **0.0 B/s**: No network activity on that interface
- **Low values (< 1 KB/s)**: Minimal background activity
- **High values**: Active file transfer, streaming, or download

**Real-world examples:**
- Web browsing: Usually < 1 MB/s
- Video streaming: 2-10 MB/s depending on quality
- File downloads: Varies by connection speed
- Large file uploads: Depends on upload bandwidth

## Troubleshooting Usage Issues

### Window Disappeared

**Solution:**
1. Check system tray for the icon
2. Double-click to show window
3. Window may be positioned off-screen (try moving it)

### Can't Move Window

**Solution:**
1. Click directly on the text/background of the window
2. Ensure you're clicking the window itself, not another application
3. Try clicking different areas of the window

### Speed Always Shows Zero

**Possible causes:**
- No active network connection
- Network adapter disabled
- Performance counter access issues

**Solutions:**
- Check network connection status
- Enable network adapter if disabled
- Try running as Administrator

### Window Blocks Content

**Solution:**
- Drag window to a different location
- Position in corner or edge of screen
- Hide window when not needed (double-click tray icon)

## Keyboard Shortcuts

Currently, NetSpeedMonitor doesn't support keyboard shortcuts. Future versions may include:
- Hotkeys to show/hide window
- Hotkeys to toggle always-on-top
- Customizable shortcuts

## Next Steps

- Learn about setup: [SETUP.md](SETUP.md)
- Build from source: [BUILD.md](BUILD.md)
- Contribute: [DEVELOPMENT.md](DEVELOPMENT.md)

---

**Need Help?** Check the main [README.md](../README.md) or open an issue on GitHub.

