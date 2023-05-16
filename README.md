# wordPuzzle
## 8-may-2023
Using the Dictionary provided by https://github.com/DevangMstryls/Oxford-English-Dictionary-41K-words
Updated the sql script to run for me in Server Management Studio 2012
Created a basic application
## 9-may-2023
Add reference by making an engine class library. Seperating the executable project 
## 15-may-2023
Testing of app using console entries is done. Few things I have learned are how to compile output in another folder which requires the following parameters to be set in .csproj file.
1. \<OutputPath>[relative path to output folder]\</OutputPath>
2. \<AppendTargetFrameworkToOutputPath>false\</AppendTargetFrameworkToOutputPath> this will remove "net6.0" folder from ouput and you can see your .dll or .exe directly.
## 16-may-2023
Trying to create wpf/web app to be used as GUI for engine and a better wordpuzzle game.