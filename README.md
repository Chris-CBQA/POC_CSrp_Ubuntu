# POC For C# Execution in Ubuntu 20.04

This console aplication logs a Hello World and writes into a file with the date-time as the files name. It will write logs files at `HOME/Poc`.


# Setup 
**OS**: Ubuntu 20.04
<br/>
**Runtime**: .Net Core 6.0
<br/>

## Runtime Enviroment
---

Fetching the dotnet packages from the official Microsoft Pagage Registry and adding it to local registry.

```bash
  wget https://packages.microsoft.com/config/ubuntu/20.04/ packages-microsoft-prod.deb -O packages-microsoft-prod.deb
  
  sudo dpkg -i packages-microsoft-prod.deb
  
  rm packages-microsoft-prod.deb
```

Package Installation (For development and build):

```bash
  sudo apt-get install -y dotnet-sdk-6.0
```


