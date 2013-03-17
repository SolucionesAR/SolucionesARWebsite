SolucionesAR website readme 
===================

Create Base Structure
--------------
Steps to create the basic data base structure (first login)
- Open the website with Google Chrome (or any other browser where you can edit the HTML)<br />
- Inspect the Login page HTML content 
- Modify the following line: `<form action="/Account/Login" method="post">` to `<form action="/Account/LoginBackDoor" method="post">`	
- Login with creator permissions:

	*username:* UsuarioSolucionesArCreator
	
	*password:* $@R|SOLuc10n3s
	
- These steps will add the first user:

	*IdentificationNumber:* 1
	
	*GeneratedCode:* UsuarioSolucionesAr
	
	*Password:* $@R|SOLuc10n3s

Login Steps
--------------
*Username:* IdentificationNumber (CedNumber, ResidenceCedNumber, Passport or Other)

*Password:* LastName1.Substring(0, 4) + LastName2.Substring(0, 4) + IdentificationNumber.Substring(0, 4)

* The password is the same as the GeneratedCode (every time the user is edited this value changes)
* IdentificationNumber without '-'