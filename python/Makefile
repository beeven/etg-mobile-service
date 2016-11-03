PYTHON = python3
PROTOS_PATH = ../protos

vpath %.proto $(PROTOS_PATH)

all: 
	$(PYTHON) -m grpc.tools.protoc -I $(PROTOS_PATH) --python_out=. --grpc_python_out=. $(PROTOS_PATH)/*

clean:
	rm -rf *_pb2.py __pycache__/