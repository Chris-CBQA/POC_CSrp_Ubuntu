# POC For C# Execution in Ubuntu 20.04

This console application logs a Hello World and writes a simple log into a file with the date-time of execution as the file's name. The log files will be written on `~/PoC/`. All logic is within `./POC_CSrp_Ubuntu/Program.cs`


# Setup 
**OS**: Ubuntu 20.04
<br/>
**Runtime**: .Net Core 6.0
<br/>

---
## Runtime Environment
### Development Kit (For dev / build machine):

- For MacOS or Windows you can download the installer from the official site: https://dotnet.microsoft.com/en-us/download/dotnet/6.0 

- Advised instalation for Ubuntu:
    ```bash
    sudo apt-get update && \
      sudo apt-get install -y dotnet-sdk-6.0
    ```

### Runtime installation (Ubuntu Server machine)

If your machine will only execute your application, install the ASP.NET Core Runtime which contains the most common Web Service utilities.

```bash
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-6.0
```

---

## Preparing package (Build and Send to server)

Clone this project in your **development machine** (Where you installed your .Net SDK):

```bash
git clone https://github.com/Chris-CBQA/POC_CSrp_Ubuntu.git
cd ./POC_CSrp_Ubuntu
```

**Inside your repo directory**, generate the executable, .dll file, and bundled dependencies. It will create a `./build` directory with your compilation.

```bash
dotnet publish -o ./build
```

If you want to test the published deployment, run the following command:

```bash
dotnet ./build/POC_CSrp_Ubuntu.dll
```

Compress the content of the build directory into a zip file, in **Powershell** you can do it with the following command:

```Powershell
Compress-Archive -Path .\build\* -DestinationPath ../PoCBundle.zip
```

We can use SSH to send the compressed file to the server instance:

```
scp -i __key_pair_file_path__ .\PoCBundle.zip  ubuntu@__instance_IP_OR_DNS__:~/PoCBundle.zip
```
---
## Setting up server

Inside the server instance, install the [dotnet runtime](#runtime-installation-ubuntu-server-machine).

Unzip the sent file. It should be at `~/PoCBundle.zip`. Be sure to have already installed the unzip package.

```bash
unzip PoCBundle.zip -d ./PoCApp
```

The application should be able to run by executing the .dll file:

```bash
dotnet ./PoCApp/POC_CSrp_Ubuntu.dll
```

Finally, we can add it to the CRON Jobs:

```bash
crontab -e
```

We will make it execute every minute, change the CRON syntax as you may like, the console output will be written into a file called `poc_logs.log`:

```cron
* * * * * dotnet ~/PoCApp/POC_CSrp_Ubuntu.dll >> ~/poc_logs.log
```