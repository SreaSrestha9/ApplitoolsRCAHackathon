Pre-requisites:
1.	 Visual Studio installed on your machine. Workload ".NET desktop development" should be installed in Visual Studio too (if no - add it with Visual Studio Installer)

     •	Install it from:

        https://visualstudio.microsoft.com/downloads/
 
2.	Chrome browser is installed on your machine.

    •	Install Chrome browser from:
    
      https://support.google.com/chrome/answer/95346?co=GENIE.Platform%3DDesktop&hl=en&oco=0 

3.	Chrome Webdriver is on your machine and is in the PATH. Here are some resources from the internet that'll help you.

    Download Chrome Webdriver from:
    
    https://chromedriver.chromium.org/downloads 
    
    https://splinter.readthedocs.io/en/0.1/setup-chrome.html 
    
    https://stackoverflow.com/questions/38081021/using-selenium-on-mac-chrome 
    
    https://www.youtube.com/watch?time_continue=182&v=dz59GsdvUF8
    
4.	Git is installed on your machine.

    Install git from: 
    
    https://www.atlassian.com/git/tutorials/install-git 
    
5.	Restart your machine to implement updated environment variables (need for some OS).


Steps to run the test:

1.	Git clone the repo:

    git clone https://github.com/SreaSrestha9/ApplitoolsRCAHackathon.git 

2.	Navigate to folder  “ApplitoolsRCAHackathon “ and double click the ApplitoolsRCA.sln. This will open the project in Visual Studio

3.	Replace the API key by your API key on Base.cs in “public void Initialize()”:

    config.SetApiKey("your API  key");

4.	In Visual Studio open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and enter command dotnet restore in the console. Command execution       can take several minutes.

5.	In Visual Studio open Solution Explorer.    

6.	Right click on the solution file and select “Manage Nuget Packages”

7.	Install the latest stable version of the Packages listed below: 

      a. Eyes.Selenium

      b. Microsoft.NET.Test.Sdk

      c. NUnit

      d. NUnit3TestAdapter

      e. NUnit.ConsoleRunner

      f. Selenium.Chrome.WebDriver

      g. Selenium Support

      h. Selenium.Webdriver
    
8.	Build the solution.

9.	Under TestCases folder run Part1.cs and Part 2.cs. 

10.	For running Part3.cs, in Base.cs, uncomment the settings to run the test in multiple browsers:

    //Uncomment these to run in multiple browsers
    
            //config.AddBrowser(1200, 800, BrowserType.FIREFOX);
            
            //config.AddBrowser(1200, 800, BrowserType.EDGE_CHROMIUM);
            
            //config.AddBrowser(1200, 800, BrowserType.SAFARI);
            
            //config.AddDeviceEmulation(DeviceName.iPhone_X);
            
    Save and run Part3.cs

