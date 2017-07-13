# Vehicle Document Parser
This is a C# console application to collect the vehicle documents found
on Snap-on Verus and Verdict devices and format and display them in CSV
format.

# How to use
After building the project, the application can be run through the
console, passing an argument which will denote the directory path of the
vehicle documents folder.

If a command line is not passed, the application will use the current
directory as the path of the vehicle documents folder.

# What is displayed
Currently the application will display the following details of each
vehicle in the CSV:
* Year
* Make
* Model
* Engine Size
* VIN
* Available Systems
* BEN