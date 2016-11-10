
PROTOS_PATH = ../protos

all: protos

protos:
	protoc -I $(PROTOS_PATH) --csharp_out=. --grpc_out=. --plugin=protoc-gen-grpc=`which grpc_csharp_plugin` $(PROTOS_PATH)/*

clean:
	rm -rf *_pb2.py __pycache__/