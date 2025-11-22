# Contributing to NetSpeedMonitor

Thank you for your interest in contributing to NetSpeedMonitor! This document provides guidelines and instructions for contributing.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [How to Contribute](#how-to-contribute)
- [Development Setup](#development-setup)
- [Pull Request Process](#pull-request-process)
- [Coding Standards](#coding-standards)
- [Reporting Issues](#reporting-issues)

## Code of Conduct

- Be respectful and considerate
- Welcome newcomers and help them learn
- Focus on constructive feedback
- Respect different viewpoints and experiences

## How to Contribute

### Ways to Contribute

1. **Report Bugs**: Found a bug? Open an issue!
2. **Suggest Features**: Have an idea? Share it!
3. **Fix Bugs**: Submit a pull request
4. **Improve Documentation**: Help others understand the project
5. **Code Improvements**: Optimize, refactor, or enhance existing code

## Development Setup

### Prerequisites

1. **Visual Studio 2019+** or **Visual Studio Code**
2. **.NET Framework 4.8 Developer Pack**
3. **Git**

### Getting Started

1. **Fork the Repository**
   - Click "Fork" on GitHub
   - Clone your fork: `git clone https://github.com/alpharibbin/NetSpeedMonitor.git`

2. **Create a Branch**
   ```bash
   git checkout -b feature/your-feature-name
   # or
   git checkout -b fix/your-bug-fix
   ```

3. **Make Changes**
   - Follow coding standards (see below)
   - Test your changes thoroughly
   - Update documentation if needed

4. **Commit Changes**
   ```bash
   git add .
   git commit -m "Description of your changes"
   ```

5. **Push and Create Pull Request**
   ```bash
   git push origin feature/your-feature-name
   ```
   Then create a Pull Request on GitHub

## Pull Request Process

### Before Submitting

- [ ] Code compiles without errors or warnings
- [ ] Code follows the project's style guidelines
- [ ] Changes are tested and working
- [ ] Documentation is updated (if applicable)
- [ ] Commit messages are clear and descriptive

### Pull Request Template

When creating a PR, please include:

**Description:**
- What changes were made?
- Why were these changes needed?
- How were they tested?

**Type of Change:**
- [ ] Bug fix
- [ ] New feature
- [ ] Documentation update
- [ ] Code refactoring
- [ ] Performance improvement

**Testing:**
- How was this tested?
- What scenarios were covered?

### Review Process

1. Maintainers will review your PR
2. Address any feedback or requested changes
3. Once approved, your PR will be merged

## Coding Standards

### General Guidelines

- **Readability**: Write code that is easy to understand
- **Consistency**: Follow existing code patterns
- **Simplicity**: Prefer simple solutions over complex ones
- **Comments**: Add comments for complex logic, not obvious code

### C# Style Guide

**Naming Conventions:**
```csharp
// Classes: PascalCase
public class SpeedWindow { }

// Methods: PascalCase
private void UpdateText() { }

// Private fields: _camelCase with underscore prefix
private Timer _timer;
private Label _label;

// Local variables: camelCase
int counter = 0;
string message = "Hello";
```

**Formatting:**
```csharp
// Use braces for all control structures
if (condition)
{
    DoSomething();
}

// One statement per line
var result = Calculate();
var formatted = Format(result);
```

**Error Handling:**
```csharp
// Use try-catch for operations that may fail
try
{
    down = _down.Sum(c => c.NextValue());
}
catch
{
    // Handle error appropriately
    down = 0;
}
```

### Code Organization

- Group related methods together
- Keep methods focused and small
- Avoid deep nesting (max 3-4 levels)
- Extract complex logic into separate methods

### Example: Good Code

```csharp
private void UpdateText()
{
    float down = 0, up = 0;
    
    try 
    { 
        down = _down.Sum(c => c.NextValue()); 
    } 
    catch 
    { 
        // Performance counter may be unavailable
    }
    
    try 
    { 
        up = _up.Sum(c => c.NextValue()); 
    } 
    catch 
    { 
        // Performance counter may be unavailable
    }
    
    string speed = $"↓ {Format(down)}\n↑ {Format(up)}";
    _label.Text = speed;
    AdjustWindowSize();
}
```

## Reporting Issues

### Bug Reports

When reporting a bug, please include:

1. **Description**: Clear description of the bug
2. **Steps to Reproduce**: How to trigger the bug
3. **Expected Behavior**: What should happen
4. **Actual Behavior**: What actually happens
5. **Environment**:
   - Windows version
   - .NET Framework version
   - Application version
6. **Screenshots**: If applicable

### Feature Requests

When suggesting a feature:

1. **Description**: What feature would you like?
2. **Use Case**: Why is this feature useful?
3. **Proposed Solution**: How should it work?
4. **Alternatives**: Other approaches considered?

### Issue Template

```markdown
**Description:**
[Clear description of the issue]

**Steps to Reproduce:**
1. Step one
2. Step two
3. Step three

**Expected Behavior:**
[What should happen]

**Actual Behavior:**
[What actually happens]

**Environment:**
- Windows Version: [e.g., Windows 10 21H2]
- .NET Framework: [e.g., 4.8]
- Application Version: [e.g., 1.0.0]

**Additional Context:**
[Any other relevant information]
```

## Testing Guidelines

### Manual Testing

Before submitting code:

- [ ] Test on Windows 10/11
- [ ] Verify network monitoring works
- [ ] Test window dragging and positioning
- [ ] Test system tray interactions
- [ ] Verify no crashes or errors
- [ ] Test with different network configurations

### Test Scenarios

**Basic Functionality:**
- Application starts correctly
- Speed window displays
- Speeds update every second
- Window can be moved
- Exit works properly

**Edge Cases:**
- No network connection
- Multiple network interfaces
- Window positioning at screen edges
- Rapid show/hide operations

## Documentation

### When to Update Documentation

- Adding new features → Update README.md and USAGE.md
- Changing behavior → Update relevant guides
- Fixing bugs → Update if it affects user experience
- Code changes → Update DEVELOPMENT.md if architecture changes

### Documentation Style

- Use clear, concise language
- Include code examples when helpful
- Add screenshots for UI changes
- Keep formatting consistent

## Commit Messages

### Format

```
Type: Short description

Longer explanation if needed
```

### Types

- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

### Examples

```
feat: Add window position persistence

Saves window position to settings file and restores on startup.
```

```
fix: Handle missing network interfaces gracefully

Prevents crash when no network interfaces are available.
```

## Questions?

- Open an issue for questions
- Check existing documentation first
- Be patient for responses

## License

By contributing, you agree that your contributions will be licensed under the same license as the project.

---

Thank you for contributing to NetSpeedMonitor! 🎉

