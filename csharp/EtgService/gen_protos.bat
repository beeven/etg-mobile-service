setlocal

@rem enter this directory
cd /d %~dp0

set TOOLS_PATH=packages\Grpc.Tools.1.0.1\tools\windows_x86

%TOOLS_PATH%\protoc.exe -I../../protos --csharp_out EntryData  ../../protos/entry_data.proto --grpc_out EntryData --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe

endlocal