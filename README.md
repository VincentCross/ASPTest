# ASPTest
This is a repository containing an application I developed as part of a technical test for a job application.

It contains both the visual studio project and a release version in:
ASPTest\RandomImage\RandomImage\bin\Release\netcoreapp2.2\publish

Simply running 'dotnet RandomImage.dll' from this location will let you access the site from localhost:5000

There is a known issue/quirk with the register/login/logout where the links don't change until one page after you've logged in/out. Given more time (or assistance) I likely could have figured out a fix. Or more likely, a proper application would use a more secure means of identification (it was not required for this test).