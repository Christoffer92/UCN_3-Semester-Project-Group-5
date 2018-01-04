# Solvr, a 3rd Semester-Project made by Group-5

Solvr is an Ask/Answer website, where users with everyday issues, can post their problems on a forum and receive help. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them

```
Without Kraka (Only Local Database) 
* Visual Studio 2017 [https://www.visualstudio.com/downloads/]
* SQL Management Studio [https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms]
* IIS [https://www.iis.net/downloads] (Should be activated through windows)
```
```
With Kraka but no web server
* Solvr.exe for the desktop clients (Admins only)
* Visual Studio 2017 [https://www.visualstudio.com/downloads/]
* IIS [https://www.iis.net/downloads] (Should be activated through windows)
```

### Setup

A step by step series of examples that tells you what you need to do, in order to run the desktop/web client locally. 

```
1. Start up Visual Studio 2017 in Administrator mode and SQL Management Studio.
```
```
2.  Within the project DbHandler --> DB Script lies the script "Create Tables.sql". 
Double Click and execute the script (Ctrl + shift + E)
```
```
3. Right click on DbHandler and press "Set as StartUp Project", and the Run the program.
```
```
4. After all the test data has been inserted, close the command console.
```
```
5. Right click on the solution 'SolvrSolution', within the Solution explorer, and select Properties.
```
```
5. Under Common Properties --> StartUp Project select 'Multiple Start Up Projects'. 
```
```
6. First choose SolvrServiceConsoleApp and select 'Start'. 
Secondly, while still highlighting SolrServiceConsoleApp, 
Click on the up arrow on the right hand side, untill the project lies on top
```
```
7. Hereafter set SolvrDesktopClient and SolvrWebClient to 'Start without debugging'and click 'Ok'.
```

Now the program can run by clicking Ctrl + F5.

## Running the tests

In order to run the tests, follow these steps.
```
1. Open Visual studio in Administrator mode.
```
```
2. On the top bar click Test --> Windows --> Test Explorer and then 'Run All' tests.
```
NB! If no tests show up, make sure that MSTest.TestAdapter and MSTest.TestFramework are installed in the NuGet Package manager.

## Features not implemented yet

```
1. Search feature, located on home page
```
```
2. Bump feature for posts
```
```
3. Cannot resolve Reports on Comments and Users, only Posts.
```
```
4. Personal profile settings
```
```
5. Admin profile settings
```
```
5. Login for Admins, only a .exe file for now.
```
```
6. Convert basicHTTP to wsHTTP binding
```
```
7. Tooltips
```
```
8. Activity history
```
```
9. Upvote/Downvote system
```

## Error Codes 

```
0916: Standard error
```
```
0917: Concurrency
```
```
0918: ID Argument error
```
```
0919: DB Connection error
```

## Built With

* [Visual Studio Enterprise 2017](https://www.microsoft.com/) - The Framework used
* [SQL Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) - The DB builder used
* [Internet Information Services](https://www.iis.net/downloads) - The Internet Service used
* [GitHub](https://github.com/) - Change Management
* [Trello](https://trello.com/) - SCRUM board

## Authors

* **Anders Gert Birkbak Nielsen** - *Student* - [Sruffen](https://github.com/Sruffen)
* **Christoffer Lund Sørensen** - *Student* - [Christoffer92](https://github.com/Christoffer92)
* **Daniel Grønhøj Lindgreen** - *Student* - [Nycheia](https://github.com/Nycheia)
* **Daniel Søgaard Jakobsen** - *Student* - [Darkuun](https://github.com/Darkuun)
* **David Christopher Hutchinson** - *Student* - [Manadin](https://github.com/Manadin)
* **Tim Mikkelsen** - *Student* - [Timx0915](https://github.com/Timx0915)

See also the list of [contributors] https://github.com/Christoffer92/UCN_3-Semester-Project-Group-5/graphs/contributors who participated in this project.

## Acknowledgments

* Michael Holm Andersen
* Mogens Holm Iversen
* Rasmus Christiansen Knap
