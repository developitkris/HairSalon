#Hair Salon
<hr>

##### **Use this app to manage your stylists and clients information 5/4/2018**
##### **By Kristi Hwang**

###Description
<hr>
This website will use MySql Database to store information about your stylists and their client contacts.  It will make efficient, saving and searching through the system via stylist and specialty.

###Setup/Installation Requirements
<hr>

1. Clone this repository
2. On your device terminal, navigate into the cloned folder, "HairSalon.Solution"
3. If you don't already have Microsoft.AspNetCore StaticFiles installed, Run >dotnet add package Microsoft.AspNetCore.StaticFiles -v 1.1.3
4. Run >dotnet restore
5. In MySql:

* CREATE DATABASE kristi_hwang
* USE kristi_hwang
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), specialty VARCHAR(255), Clients MULTISET)
* CREATE TABLE clients (stylist_id INT, name VARCHAR(255), phone VARCHAR(255))

6. Run >dotnet run
7. Navigate to localhost:5000 in the browser to start

###Bugs
<hr>
There are no known bugs at the time of the last update.

###Support and Contact
<hr>
Please feel free to leave your comments and/or feedback.  
For further inquiries, please contact Kristi at mailto:krsy3ii@yahoo.com

###Technologies Used
<hr>

* C#
* MVC (.Net Core)
* MySql
* Razor
* HTML
* Boostrap
* CSS
* Git

###Licensing
<hr>
_This software is licensed under the MIT license._
**Copyright(c) 2018, Kristi Hwang**
