#!/usr/bin/env bash

# https://github.com/grpc/grpc/blob/master/examples/csharp/helloworld/generate_protos.bat

NUGET_PATH=$HOME/.nuget
TOOLS_PATH=$NUGET_PATH/packages/grpc.tools/1.8.3/tools/macosx_x64/

$TOOLS_PATH/protoc -I=. -I=$GOPATH/src -I=$GOPATH/src/github.com/gogo/protobuf/protobuf --csharp_out Tendermint ./protos/types.proto --grpc_out Tendermint --plugin="protoc-gen-grpc=$TOOLS_PATH/grpc_csharp_plugin"

sed -i "" 's/global::Gogoproto\.GogoReflection\.Descriptor, //g' Tendermint/Types.cs
