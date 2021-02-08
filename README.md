# Mars Rover Project


## Requirements

To run this project you need:
* Visual Studio with .NET Core 3.1
* Internet access as the project references some remote CDN js files


## Technologies used

* .NET Core Web App 
* NUnit
* Vue JS with some third party JS libraris (axios and vue-toastr)
* CSS, HTML 

## Installation

Clone the repo
   ```sh
   git clone https://github.com/cosinus88/MarsRover.git
   ```

## How to run

* To run the rover app open the project in Visual Studio and run using IIS Express
* To run tests use VS Test Explorer 

## What can be improved 

* There's no storage atm, in a real life scenario I would store the state of the plateu and keep the track of rovers in a DB. Potentially using EF or Dapper as ORM.
* By introducing the storage there'll be no need in static mission control class (which is not thread safe atm). The mission control could be transformed into a wrapper class that can be 'IoC-ed' into our mission controller. 
* Add a global error handler  
* Add webpack support and install packages using npm (so, the vue app can be split into a number of modules, so called "one file components" to improve the quality of the code).
* Potentially could use Typescript coupled with Vue  
* Move css to SASS
* Minify JS & CSS (using webpack plugins)
* Generate API documentation using NSWAG
