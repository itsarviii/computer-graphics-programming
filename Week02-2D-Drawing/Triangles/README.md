# Week 2 – 2D Drawing (Recursive Triangles)

## Module
Computer Graphics Programming

## Task
Draw a series of triangles where each new triangle is formed from the midpoints
of the sides of the previous triangle using C# Windows Forms.

## Description
This exercise builds on basic 2D drawing techniques by introducing recursion.
Starting from an initial triangle defined by three points, the midpoints of each
side are calculated to form a new, smaller triangle. This process is repeated
recursively until the size of the triangle is smaller than one pixel.

## Concepts Demonstrated
- 2D graphics drawing using WinForms
- Use of the Graphics object in `OnPaint()`
- Recursive algorithms in computer graphics
- Midpoint calculation between two points
- Use of stopping conditions in recursion
- Hierarchical coordinate system

## Files Included
- `Triangles.cs` – source code implementing the recursive triangle drawing
- `Program.cs` – application entry point
- `CGP.exe` – compiled executable

## Output
Running the executable displays a large triangle with progressively smaller
triangles drawn inside it, each formed from the midpoints of the previous one.
