FROM ubuntu:latest

ADD . /code
WORKDIR /code

RUN apt-get update && \
    apt-get install -y libcurlpp-dev libcrypto++-dev git-core curl pkg-config && \
    cd /tmp && \
    curl -OL https://github.com/mongodb/libbson/releases/download/1.3.6/libbson-1.3.6.tar.gz && \
    tar -xzf libbson-1.3.6.tar.gz && cd libbson-1.3.6 && \
    ./configure && make && make install && cd /tmp && \
    curl -OL https://github.com/mongodb/mongo-c-driver/releases/download/1.3.6/mongo-c-driver-1.3.6.tar.gz && \
    tar -xzf mongo-c-driver-1.3.6.tar.gz && cd mongo-c-driver-1.3.6 && \
    ./configure && make && make install && cd /tmp && \
    curl -OL https://cmake.org/files/v3.6/cmake-3.6.3.tar.gz && \
    tar -xzf cmake-3.6.3.tar.gz && cd cmake-3.6.3 && \
    ./configure && make && make install && cd /tmp && \
    curl -OL https://github.com/mongodb/mongo-cxx-driver/archive/r3.0.2.tar.gz && \
    tar -xzf r3.0.2.tar.gz && \
    cd mongo-cxx-driver-r3.0.2/build && \
    cmake -DCMAKE_BUILD_TYPE=Release -DCMAKE_INSTALL_PREFIX=/usr/local .. && \
    make && make install && cd /tmp && \
    curl -OL https://github.com/miloyip/rapidjson/archive/v1.1.0.tar.gz && \
    tar -xzf v1.1.0.tar.gz && cd rapidjson-1.1.0 && \
    cp -R ./include/rapidjson /usr/local/include/ && cd /tmp

RUN git clone https://github.com/grpc/grpc && \
    cd grpc && git submodule update --init && \
    cd ./third_party/protobuf && \
    ./autogen.sh && ./configure && make && make install && \
    cd ../../ && make && make install

RUN mkdir -p /code/cpp/build && cd /code/cpp/build && \
    cmake ../ && make

EXPOSE 8443 50052

CMD ["/code/cpp/build/etg_service_server"]