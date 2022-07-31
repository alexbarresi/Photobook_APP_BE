# Photobook_APP_BE


## Description

This .NET core Swashbuckle project exposes two rest API calls, down below you can find a brief description:

1 - verb GET - /api/photobook 
  - This api call retrieves a list of albums and associated photos 
  
2 - verb GET - /api/photobook/id 
  - This api call retrieves a list of albums and associated photos filtered by user ID

These api calls gets consumed by a react/typescript Frontend project

## Frontend repository

Here's the url to the Frontend repo of the photobook app:
https://github.com/alexbarresi/photobook_app_fe


# Technologic stack
C# with .NET Core MVC
Framework version: 6.0(lts)

The template used is .NET core Swashbuckle with Swagger integration 

The command utilized to start the project: 

**dotnet new webapi**


# Swagger

You can access it by adding **'/swagger'** to the main url.

# Start project
please note that **Visual Studio Code** IDE is advised



## Serve 

in this repo you can find the **launch.json** config file, this config file should be enough to configure the 'Run & Debug' VS code tab 

<img width="400" alt="Schermata 2022-07-31 alle 17 56 24" src="https://user-images.githubusercontent.com/10447666/182034855-8b534fa9-8cfb-4d50-9a17-15d79cc8da89.png">

As shown in the photo, you can press the run button to serve and run on localhost.

After that, a localhost page will open in the browser.

You should now see an empty page like this one

<img width="400" alt="Schermata 2022-07-31 alle 18 01 26" src="https://user-images.githubusercontent.com/10447666/182035022-50f0dbc4-d385-4daf-8315-5ef5ac7ef758.png">

Just add **'/swagger'** at the end of 'https://localhost:xxxx' and you should see the exposed APIs.
At this point feel free to use and test them

