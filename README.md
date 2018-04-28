Nina Nguyen
April 27, 2018
Spring 2018

# encryptWord_csharp
This project is for CPSC 5051 Software Engineering Fundamental

Part I: Class Design
Design an encapsulated class for an encryptWord. Each encryptWord object encapsulates a private,
undisclosed Caesar cipher shift. With a shift of ‘3’, for example, the letter ‘a’ will be encrypted as ‘d’; ‘b’
encrypted as ‘e’, … ,‘w’ as ‘z’, ‘x’ as ‘a’, ‘y’ as ‘b’ and ‘z’ as ‘c’. An application programmer may pass a
word to an encryptWord object in order to receive encrypted output: words less than 4 characters long
should be rejected. The application programmer may also query an encryptWord object as to whether a
passed integer is, in fact, the correct shift value. An encryptWord object may be ‘off’ or ‘on’, and, also,
may be ‘reset’. An encryptWord object also yields statistics -- number of queries, high guesses, low
guesses and average ‘guess value’.
This assignment is a partial realization of a guessing game, targeted to elementary school students. With
the interface described above, your design should support ‘decoding’.
Part II: Driver (External Perspective of Application Programmer)
• Design a driver to demonstrate the program requirements. Clearly specify the intent and structure
of your driver.
• You should have collections of distinct objects, initialized appropriately, i.e. random distribution
of shifts, initial states, etc.
• Your collection of distinct objects should be sufficiently tested with random input, and seamless
alteration of the state of some objects

# Built with
Runs on console .NET visual studio

