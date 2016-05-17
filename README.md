# MARS ROVERS
### An artifact demonstrating that we were all once bad programmers

In 2009 I applied to work at ThoughtWorks. They gave me a code test with 3 problems to choose from; I chose Mars Rovers. I recently found a copy of the code that I submitted and felt that I should upload it to GitHub and make it visible to, and reviewable by, everybody.

This repo serves as both evidence and a reminder that skill is developed over time. As developers, we are not amazing at what we do from day 1. It takes effort, ethic, and time to develop a great set of skills. We were all once "bad" at this job. If you frame interactions with me such that you think I've always been a good developer, I invite you to browse this code.

When I review this code today, I cringe and laugh at myself. A good sign of progress to me has always been looking back at your prior work and wondering what the hell you were thinking; this no exception. Just check out this part of the `README.txt` of my submission:

> I have programmed my solution to follow object-oriented design patterns and best practices to the best of my current knowledge and ability, without adding un-necessary complexity.

Wow. Just wow. I over-engineered the hell out of this problem. I have done some terrible, crazy things in this code; and that's not including all the awful XML comments. I hope that you'll find it as amusing as I do, and please, for the love of all that is good, do not learn or take away any best practices from this repo.

Our careers are an ever-evolving path, unique to each of us and filled with uncertainty, curiousity, and growth. I have a ways to go, but am pleased to see progress in myself. In other words: in many ways I'm still a bad coder, but not nearly as bad as I was in 2009. Today's David Haney would certainly not hire 2009 David Haney. 

Oh, and in case you were wondering: they rejected my code solution and I did not get the job. At the time I was upset but today I am very glad. 

## Mars Rovers Spec

A squad of robotic rovers are to be landed by NASA on a plateau on Mars.
This plateau, which is curiously rectangular, must be navigated by the
rovers so that their on-board cameras can get a complete view of the
surrounding terrain to send back to Earth.

A rover's position and location is represented by a combination of x and y
co-ordinates and a letter representing one of the four cardinal compass
points. The plateau is divided up into a grid to simplify navigation. An
example position might be 0, 0, N, which means the rover is in the bottom
left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The
possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90
degrees left or right respectively, without moving from its current spot.
'M' means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

### INPUT

The first line of input is the upper-right coordinates of the plateau, the
lower-left coordinates are assumed to be 0,0.

The rest of the input is information pertaining to the rovers that have
been deployed. Each rover has two lines of input. The first line gives the
rover's position, and the second line is a series of instructions telling
the rover how to explore the plateau.

The position is made up of two integers and a letter separated by spaces,
corresponding to the x and y co-ordinates and the rover's orientation.

Each rover will be finished sequentially, which means that the second rover
won't start to move until the first one has finished moving.

### OUTPUT

The output for each rover should be its final co-ordinates and heading.

### INPUT AND OUTPUT

Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Expected Output:
1 3 N
5 1 E

---

What follows is the verbatim write-up of the `README.txt` that I sent to ThoughtWorks when I submitted this code. Enjoy.

---

## Canada, Mars Rovers, C#

Solution coded entirely by David Haney
Solution Started: Monday, September 07, 2009
Solution Completed: Tuesday, September 08, 2009
Total Time: Approximately 11 hours (2 design, 8 coding, 1 testing)
Language: C#
IDE: Visual Studio 2008
OS: Windows 7 Professional 64-bit

## How To Run The Application

The application is a console app designed for the .NET 2.0 framework. It does not use any of the features 
of .NET 3.0 or 3.5, however can be configured to build for any desired .NET version within Visual Studio.

Compile the solution, and then run the application as follows:

`ThoughtWorksRovers.exe <windows-path-to-input-file>`

The input file path can be absolute or relative. Instructions are provided if no argument or more than 
one argument is supplied to the application.

## Design Explanation

I have programmed my solution to follow object-oriented design patterns and best practices to 
the best of my current knowledge and ability, without adding un-necessary complexity. All 
instantiated class objects implement an interface; this is done to enable scalability of code 
as well as future modifications to be completed easily without the need for heavy refactoring. 
The factory design pattern is used, however it is implemented as a factory method instead of a 
factory class (no need to add further complexity to the solution). The factories are important 
to de-couple methods for unit testing and mocking.

The solution consists of a parser, environment and program class which houses the static main method.

The parser checks the validity of the input and parses it, assigning it to data container objects.

The environment contains rover controllers which house rovers, the graph (which contains graph 
nodes), and a container for directions information. The directions container is injected into 
the constructors of the rover controllers and graph; they in turn use this information to define 
their own direction capabilities. In the case of the graph, the direction information defines the 
directions in which adjacent nodes are connected, and how each given direction translates to grid offsets 
(ie: "N" would be X offset 0, Y offset 1). In the case of the rover controllers, the directions 
information is used to determime the possible orientations of the rover (ie: the directions in which 
the rover can face, and thus move).

The program class checks for the correct number of input arguments, and then passes the file path argument 
to the parser to parse, and then passes those results to the environment to do the real work. The 
environment creates the graph and rover controllers, and then manipulates the controllers sequentially 
to solve the problem at hand and output to console as per the specifications.

I did not divide the class files into more than one project as that would be adding currently un-needed
complexity to my solution.

## Assumptions Made

The following assumptions were made while developing this solution:

1. The grid does not wrap, that is to say that the grid borders are hard borders that cannot be 
traversed. Thus, if a rover attempts to move off of the grid, it will simply not move, as if it 
had hit a wall. Other considerations were to throw an exception or wrap the grid.

2. As per the directions, I have assumed that the square directly North from (x, y) is (x, y+1), 
and thus that the other directions exist in parallel to real life cardinal compass points.

## Thanks

Thanks very much for your time and consideration, and have a terrific day!

Sincerely,

David Haney