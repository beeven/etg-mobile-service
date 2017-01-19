PROTOC = protoc
PROTOS_PATH = ../protos

all: build

deps:
	go get -v google.golang.org/grpc
	go get -u -v github.com/golang/protobuf/{proto,protoc-gen-go}

build: deps
	go build server

proto:
	@ if ! which protoc > /dev/null; then \
		echo "error: protoc not installed" >&2; \
		exit 1; \
	fi
	go get -u -v github.com/golang/protobuf/protoc-gen-go
	# use $$dir as the root for all proto files in the same directory
	#for dir in $$(git ls-files '*.proto' | xargs -n1 dirname | uniq); do \
	#	protoc -I $$dir --go_out=plugins=grpc:$$dir $$dir/*.proto; \
	#done
	protoc -I $(PROTOS_PATH) --go_out=plugins=grpc:entry_data $(PROTOS_PATH)/entry_data.proto

clean:
	rm -rf *_pb2.py __pycache__/