# Week 4 – Double Buffering

## Module
Computer Graphics Programming

## Task
Create an animated WinForms application that uses double buffering to
eliminate flickering during redraws.

## Description
This exercise demonstrates the use of double buffering to improve
rendering performance in animated graphics. All drawing is performed
off-screen and then rendered to the display in a single operation,
resulting in smooth, flicker-free animation.

## Concepts Demonstrated
- Double buffering in WinForms
- Flicker reduction techniques
- Timer-based animation
- Continuous rendering using OnPaint()
- Efficient redraw using Invalidate()

## Files Included
- `DoubleBuffering.cs` – flicker-free animation logic
- `Program.cs` – application entry point
- `CGP.exe` – compiled executable

## Output
Running the executable displays a smoothly animated circle moving
across the window without visible flicker.
