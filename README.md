# NetSpeedMonitor

A lightweight Windows desktop application that displays real-time network speed (download and upload) in a floating, draggable window. The application runs in the system tray and provides an always-on-top overlay showing your current network activity.

![NetSpeedMonitor](https://img.shields.io/badge/.NET-Framework%204.8-blue)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)

## Features

- 📊 **Real-time Network Monitoring**: Displays current download (↓) and upload (↑) speeds
- 🖱️ **Draggable Window**: Click and drag the speed display anywhere on your screen
- 🔝 **Always on Top**: Stays visible above other windows
- 🎯 **System Tray Integration**: Runs quietly in the background
- 🎨 **Modern UI**: Dark-themed, semi-transparent overlay
- ⚡ **Lightweight**: Minimal resource usage
- 🔄 **Auto-positioning**: Automatically positions in the bottom-right corner on first launch

## Quick Start

1. **Download** the latest release from the [Releases](https://github.com/alpharibbin/NetSpeedMonitor/releases) page
2. **Run** `NetSpeedMonitor.exe`
3. The speed monitor window will appear in the bottom-right corner
4. Double-click the system tray icon to show/hide the window
5. Right-click the system tray icon and select "Exit" to close the application

For detailed setup instructions, see [SETUP.md](docs/SETUP.md)

## Screenshots

The application displays network speed in the following format:
```
↓ 2.5 MB/s
↑ 0.8 MB/s
```

## Requirements

- **Operating System**: Windows 7 or later
- **.NET Framework**: Version 4.8 or later
- **Permissions**: Standard user permissions (no admin required)

## Installation

### Option 1: Pre-built Binary
1. Download `NetSpeedMonitor.exe` from the [Releases](https://github.com/alpharibbin/NetSpeedMonitor/releases) page
2. Place it in your desired location
3. Double-click to run

### Option 2: Build from Source
See [BUILD.md](docs/BUILD.md) for step-by-step build instructions.

## Usage

For detailed usage instructions, see [USAGE.md](docs/USAGE.md)

### Basic Operations
- **Show/Hide Window**: Double-click the system tray icon
- **Move Window**: Click and drag the speed display window
- **Exit Application**: Right-click system tray icon → Exit

## Project Structure

```
NetSpeedMonitor/
├── Program.cs          # Application entry point
├── TrayApp.cs          # System tray integration
├── SpeedWindow.cs      # Main speed display window
├── Form1.cs            # (Unused form - legacy)
└── Properties/         # Application properties and resources
```

## How It Works

The application uses Windows Performance Counters to monitor network interface statistics:
- Monitors all active network interfaces
- Aggregates bytes received/sent per second
- Updates the display every second
- Formats speeds in B/s, KB/s, or MB/s

## Documentation

Comprehensive documentation is available in the [`docs/`](docs/) directory:

- **[Documentation Index](docs/README.md)** - Overview of all documentation
- **[Setup Guide](docs/SETUP.md)** - Installation and configuration
- **[Build Guide](docs/BUILD.md)** - Building from source code
- **[Usage Guide](docs/USAGE.md)** - How to use the application
- **[Development Guide](docs/DEVELOPMENT.md)** - Development environment and architecture
- **[Contributing Guide](docs/CONTRIBUTING.md)** - Contribution guidelines

## Development

For development setup and contribution guidelines, see:
- [DEVELOPMENT.md](docs/DEVELOPMENT.md) - Development environment setup
- [BUILD.md](docs/BUILD.md) - Detailed build instructions

## Building the Project

See [BUILD.md](docs/BUILD.md) for a complete step-by-step guide.

### Quick Build
```bash
# Using Visual Studio
1. Open NetSpeedMonitor.slnx
2. Build → Build Solution (Ctrl+Shift+B)
3. Output: bin\Debug\NetSpeedMonitor.exe

# Using MSBuild
msbuild NetSpeedMonitor.csproj /p:Configuration=Release
```

## Troubleshooting

### The window doesn't appear
- Check if the application is running in the system tray
- Double-click the system tray icon to show the window

### Speed shows 0.0 B/s
- Ensure you have an active network connection
- Check if Windows Performance Counters are accessible
- Some virtual network adapters may not report statistics correctly

### Window position resets
- The window auto-positions on first launch
- After positioning manually, it should remember your preference

## License

[Add your license here - e.g., MIT, GPL, etc.]

## Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](docs/CONTRIBUTING.md) for guidelines.

## Acknowledgments

- Built with Windows Forms (.NET Framework 4.8)
- Uses Windows Performance Counters for network monitoring

---

**Note**: Replace `alpharibbin` in the GitHub links with your actual GitHub username when publishing.

