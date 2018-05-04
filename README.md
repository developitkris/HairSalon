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
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), number VARCHAR(32))
* CREATE TABLE clients (INT stylist_id, clientName VARCHAR(255), number VARCHAR(32), )
