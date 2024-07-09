# LibraryManagement

front-end repo: https://github.com/f1l1ph/libraryManagement</br>
Validation doesn't work on frontend, it is because I want to show that it works on backend.

<h2>Details:</h2>
<ul>
<li> project: ASP.net Core web API</li>
<li>version: .Net 8</li>
<li>database: Postgre on localHost and AzureSQL on azure</li>
<li>CQRS: MediatR</li>
</ul>
<h2>Design patterns:</h2>
Fot this project I chose CQRS and repository patterns.</br>
CQRS - command query responsibility segragation </br>
In project we have:</br>
<ul>
  <li>commands - responsible for writing into database</li> 
  <li>querys - resonsible for reading from database</li>    
</ul>
Every command and query has also handler - "AddBookCommandHandler"

<h3>We also have repositories.</h3>
Repository is responsible for communicating with database using entity framework.</br>

<strong>In theory we should also have 2 or more databases, one for reading and one writing.</strong> In project we have one database but 2 db contexts.

<h3>Validation</h3>
Added validation using Fluent validation library.<br/>
Validation works when adding/modifing book. Also when adding new BorrowOrder.<br/>
<br/>

Also Emailworker checks every 24h for closeDate on each BorrowOrder and sends fake email.

<em>endpoints on the swagger screenshot.</em></br>
![Datapac-swagger](https://github.com/f1l1ph/Zadanie-Datapac/assets/50553234/38fc5d5b-4a46-466a-bddf-93d803bf6db4)


<em>Db diagram, for this project I am using Postgres and AzureSql </em></br>
![Datapac-dbD](https://github.com/f1l1ph/Zadanie-Datapac/assets/50553234/941b34ef-381b-4295-83a6-b771bc16e377)
