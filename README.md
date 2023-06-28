# Understanding RESTFul (POST, PUT and DELETE) services with Windows Communication Foundation (WCF) and Oracle XE.

The REST model relies on the application that accesses the data sending the appropriate HTTP verb as part of the request used to access the data. HTTP besides GET, the HTTP protocol supports other forms of verbs such as POST, PUT, and DELETE, which you can use in a REST service to create, modify, and remove resources, respectively. Using these verbs you can build WCF services that can insert, update, and delete data.

The good practice is that you use HTTP POST requests to specify operations that can add new records, HTTP PUT requests for operations that update existing data, and HTTP DELETE requests to define operations that can remove records.

POST is an exception in certain regards. POST is frequently misused as DELETE and PUT, because the use of DELETE and PUT is either not permitted or technically impossible from the browser's perspective, and you could use HTTP POST requests to update and delete data.

Use the [WebInvoke] attribute for scenarios POST, PUT and DELETE, you use this attribute to identify a URI, but you can also indicate the type of the request message to which to respond.

In the following example, I will build a REST WCF Service to enable insert, update and delete operations for Oracle HR Schema.

You can learn about the HR Schema in this post.

The following table shows the URIs and the parts of the interface that I will implement for each URI in the example.

URI	Method	Output	Input
/employees	POST	bool	An Employee Object
/employees/{id}	PUT	bool	An employee Object with id specified.
/employees/{id}	DELETE	bool	An employee Id
The main steps for this exercise are as follows:

Use the EmployeesDac class, which contains the method for accessing the database.
Write the EmployeesServiceImplementation class with the following code (fig 1).
<p>Fig 1. EmployeeServiceImplementation.cs</p>
<img src="picture_library/wcfpost/EmployeeServiceImplementation.png">
Write a new interface called IEmployeesServiceContract and type the following code(fig 2).
<p>Fig 2. IEmployeeServiceContract.cs</p>
<img src="picture_library/wcfpost/IEmployeeServiceContract.png">
Write the EmployeesService.svc file that references the service implementation with the following code (fig 3).
<p>Fig 3. EmployeeService.svc</p>
<img src="picture_library/wcfpost/EmployeesService.png">
Finally, add the following config file (fig 4)
<p>Fig 4. Web.config</p>
<img src="picture_library/wcfpost/webconfig.png">
Testing the service with Soap UI.
The WCF service that you have built runs the same way as a regular Web application and is hosted by a Web Server.

If you browse the .svc file, you can view the help page for the WCF service. It verifies that the WCF service has been configured correctly (you will see error messages if the WCF service cannot start) and provides information showing how you can connect to the service.

Once we've made all the required settings, running the tests are very easy with SOAP UI. Before running, we can define the json request or query string parameters. Use the Green button to start running the test.

Testing the HTTP-POST request, after completing the execution, the result window displays the JSON Response.
<p>Fig 5. HTTP-POST Request</p>
<img src="picture_library/wcfpost/wcfpost1.png">

Testing the HTTP-PUT request after completing the execution, the result window displays the JSON Response.
<p>Fig 6. HTTP-PUT Request</p>
<img src="picture_library/wcfpost/wcfpost2.png">

Testing the HTTP-DELETE request after completing the execution, the result window displays the JSON Response.
<p>Fig 7. HTTP-DELETE Request</p>
<img src="picture_library/wcfpost/wcfpost3.png">
