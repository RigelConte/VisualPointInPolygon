
**** Rigel Conte 06/03/2024 ****

This is a program that calculates the classic geometry program of finding the point within the polygon with three widely used approaches, they are:

1. Ray Casting Algorithm
   Works by drawing an imaginary ray from the point in question to infinity and counting how many times the ray intersects with the polygon's edges.
   The main condition is If the number of intersections is odd, the point is inside the polygon; if even, the point is outside.

3. Winding Number Algorithm
The winding number algorithm determines how many times the polygon winds around the point.
The main condition is If the winding number is non-zero, the point is inside the polygon; if zero, it is outside. This method is more complex but can handle some cases that the ray casting algorithm may struggle with, especially for polygons with self-intersections.

5. Angle Summation Algorithm
This method sums the angles made by the point with each pair of consecutive vertices of the polygon. If the total angle is approximately 2π (or 360∘), the point is inside the polygon. Otherwise, it is outside. (this was refined using the EPSILON technique)

 - A small threshold value (1e-10) to handle floating-point precision issues. This ensures that the angle sum is considered non-zero only if it is significantly different from zero.
   Angle Calculation:
   Adjusts the angle calculation to always return a value within the range (-π, π), accounting for the wrap-around that can happen with the Atan2 function.
   Ensures the angle summation accounts for angles that might cross the ±π boundary.
  

