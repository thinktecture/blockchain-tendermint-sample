# Tendermint BlockChain Demo - NumberTransfer

## Setup

* Install Tendermint [https://github.com/tendermint/tendermint/releases](https://github.com/tendermint/tendermint/releases)
* Install .NET Core: [https://www.microsoft.com/net/learn/get-started/macos](https://www.microsoft.com/net/learn/get-started/macos) and compile the following projects:
	* NumberTransfer: `cd ./src/NumberTransfer/NumberTransfer && dotnet build`
	* NumberTransferWebApi: `cd ./src/NumberTransfer/NumberTransferWebApi && dotnet build`
* Install Node.js: [https://nodejs.org](https://nodejs.org) and run: `cd ./src/NumberTransfer/NumberTransferWeb && npm install`

## Start

* Start Tendermint: `tendermint node --abci grpc --proxy_app 127.0.0.1:44900 --consensus.create_empty_blocks=false`
	* It will show an error "Echo failed" which is to be expected, since the given proxy app is not running yet
* Start the proxy app: `cd ./src/NumberTransfer/NumberTransfer/bin/Debug/netcoreapp2.0 && dotnet dotnet NumberTransfer.dll BindSettings:Port=44900`
* Start the web app: `cd ./src/NumberTransfer/NumberTransferWeb && npm start`
* Open `http://localhost:4200`

## Generation

The sample uses protoBuf and certificates which need to be generated. However, the repo contains a set of ready-to-use sample data. If you want to regenerate the protos or the certificates, you can do so by using the documentation below.

### Protos

To generate the protos, us the provided `src/generate-protos.sh`. It will regenerate C# files and remove the uncompilable code which in this process is generated.

### Certificates

The demo provides a set of certificates used for signing and validating the requests. If you want, you can regenerate the certificates or use your own.

Generate manually or use the provided `generate.sh` file.

> Be aware, when regenerating the certificates, the `app-settings.json` needs to be adjusted as well! The `generate.sh` file will output all public keys to a file `publickeys.txt`, which can be copied over. It will also copy the certificates to the Web API.

The sample assumes, that the password for the certificates is `thinktecture`. Don't forget to search for that string, if you replace it with other certificates using another password.
