# Week 7 – Simple Transformations

## Module
Computer Graphics Programming

## Task
Apply geometric transformations to a rectangle using the Matrix class in C# Windows Forms.

## Description
This exercise demonstrates how 2D transformations can be applied using
the `System.Drawing.Drawing2D.Matrix` class. A rectangle is drawn in its
original position and then transformed using rotation and translation
operations.

The practical explores rotation around the world origin (0,0), rotation
around an arbitrary point using `RotateAt()`, and translation using
matrix transformation methods.

## Concepts Demonstrated
- Use of the `Matrix` class
- Rotation around the world origin
- Rotation around an arbitrary point
- Translation transformation
- Matrix order (Append)
- 2D rotation formula using sine and cosine
- Understanding world vs object coordinates

## Files Included
- `SimpleTransformations.cs` – transformation implementation
- `Program.cs` – application entry point
- `CGP.exe` – compiled executable

## Output
Running the executable displays a rectangle drawn in four different
positions:
1. Original position
2. Rotated around the world origin
3. Rotated around its own centre
4. Translated horizontally

The output visually demonstrates how transformation matrices modify
object coordinates in 2D graphics.
