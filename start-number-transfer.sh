#!/usr/bin/env bash

(cd src/NumberTransfer/NumberTransfer/bin/Debug/netcoreapp2.0/ && dotnet NumberTransfer.dll AppName='Regulator' BindSettings:Port=44900) &
tendermint node --abci grpc --proxy_app 127.0.0.1:44900 --consensus.create_empty_blocks=false &  

# (cd src/NumberTransfer/NumberTransfer/bin/Debug/netcoreapp2.0/ && dotnet NumberTransfer.dll AppName='Telco1' BindSettings:Port=44901) &
# tendermint node --abci grpc --proxy_app 127.0.0.1:44900 --consensus.create_empty_blocks=false &  

# (cd src/NumberTransfer/NumberTransfer/bin/Debug/netcoreapp2.0/ && dotnet NumberTransfer.dll AppName='Telco2' BindSettings:Port=44902) &
# tendermint node --abci grpc --proxy_app 127.0.0.1:44901 --consensus.create_empty_blocks=false &  

# (cd src/NumberTransfer/NumberTransfer/bin/Debug/netcoreapp2.0/ && dotnet NumberTransfer.dll AppName='Telco3' BindSettings:Port=44903) &
# tendermint node --abci grpc --proxy_app 127.0.0.1:46678 --consensus.create_empty_blocks=false &  
