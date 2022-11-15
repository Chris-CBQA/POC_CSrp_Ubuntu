# POC For C# Execution in Ubuntu 20.04

This console application logs a Hello World and writes a simple log into a file with the date-time of execution as the file's name. The log files will be written on `~/PoC/`. All logic is within `./POC_CSrp_Ubuntu/Program.cs`


# Setup 
**OS**: Ubuntu 20.04
<br/>
**Runtime**: .Net Core 6.0
<br/>

## Runtime Environment

Fetching the dotnet package signature from the official Microsoft Package Registry and adding it to the trusted packages list.

```bash
  wget https://packages.microsoft.com/config/ubuntu/20.04/ packages-microsoft-prod.deb -O packages-microsoft-prod.deb
  
  sudo dpkg -i packages-microsoft-prod.deb
  
  rm packages-microsoft-prod.deb
```

Package Installation (For dev / build machine):

```bash
  sudo apt-get install -y dotnet-sdk-6.0
```

Runtime installation (If your machine will only execute your application), it uses the ASP.NET core which contains the most common Web Service utilities.

```bash
  sudo apt-get install -y aspnetcore-runtime-6.0
```

## Preparing package (Build and Send to server)

Clone this project in your **development machine** (Where you installed `dotnet-sdk-6.0`):

```bash
git clone https://github.com/Chris-CBQA/POC_CSrp_Ubuntu.git
cd ./POC_CSrp_Ubuntu
```

**Inside your repo directory**, generate the executable, .dll file, and bundled dependencies. It will create a `./build` directory

```bash
dotnet publish -o ./build
```

If you want to test the published deployment, run the following command:

```bash
dotnet ./build/POC_CSrp_Ubuntu.dll
```

_TODO: Add deployment and execution instructions_