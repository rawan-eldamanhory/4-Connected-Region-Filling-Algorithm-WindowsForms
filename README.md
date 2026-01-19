# 4-Connected Region Filling Algorithm

This project demonstrates the **4-connected region filling (flood fill) algorithm** using **C# and Windows Forms**.

The application draws a polygon and fills its interior using a stack-based 4-connected fill approach.

## 📌 Features
- Stack-based (non-recursive) flood fill
- 4-connected pixel connectivity (up, down, left, right)
- Bounding-box optimization
- Simple visualization using Windows Forms

## 🧠 Algorithm Overview
The 4-connected fill algorithm starts from a seed point and recursively (or iteratively) fills neighboring pixels in four directions:
- Left
- Right
- Up
- Down

In this implementation:
- A stack is used instead of recursion
- A bounding box limits the fill area
- Each visited pixel is tracked to avoid repetition

## 🎨 Visualization
- Black outline: polygon boundary
- Blue fill: region filled using 4-connected connectivity

## 🛠️ Technologies Used
- C#
- .NET
- Windows Forms
- Graphics (GDI+)

## ▶️ How to Run
1. Open `WindowsFormsApp1.sln` in Visual Studio
2. Build and run the project
3. The polygon is filled automatically when the form is rendered

## 🎓 Purpose
This project was created as part of a **computer graphics coursework** to demonstrate region filling algorithms.

## 📄 License
Educational use only.
