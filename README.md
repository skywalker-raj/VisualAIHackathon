# Pre-requisites:

1. Visual Studio installed on your machine.
   * [Install it from here](https://visualstudio.microsoft.com/downloads/)
2. If the repo doesnot contain the dependencies then download the following:
	- Download Selenium, Selenium Support, Selenium Webdriver, nunit, nunit console runner and nunit test adapter, Selenium.Webdriver.Chromedriver.
	- Download Microsoft.netcore.app, Microsoft.net.test.sdk from nuget.
	- Download eyes.selenium from nuget.
	
# Steps to run this example

1. Git clone this repo
    
2. Open the folder `VisualAiHackathon`
3. Set your API key in the _APPLITOOLS_API_KEY_ environment variable.
    * You can get your API key by logging into Applitools > Person Icon > My API Key.
4. Double click the `VisualAIRockstar.sln`. This will open the project in Visual Studio.

   **MAKE SURE YOU HAVE THE _APPLITOOLS_API_KEY_ ENVIRONMENT VARIABLE SET BEFORE YOU START VISUAL STUDIO**
5. To Run the traditional test and visual AI test:
	a. Run Traditional test from TraditionalTest.cs file under  Test folder.
	b. Run Visual AI Test from VisualAITest.cs file under  Test folder 

	
#Architecture

1. Services
	This folder contains all the generic selenium/browser communication methods customized for the framework.
2. PageObjects
	This folder contains all the locators for each page.
3. Data Classes
	This folder contains class for Transaction data type for dashboard page test.
4. Common
	This folder consist of all the methods that are common and are used reptitively.
5. Test	
	This folder contains the main test. Legacy test or test using only selenium are under TraditionalTest.cs.
	Whereas all the verification via Applitools are under VisualAITest.
6. Data
	The folder consist config.json file which contains the data like url, messages , username ,pwd etc.
7. Executables
	The folder contains the .exe files i.e. ChromeDriver in this case.
