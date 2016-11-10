FROM ubuntu:latest

ADD . /code
WORKDIR /code

RUN apt-get update && \
    apt-get install -y libcurlpp-dev libmongoc-dev libcrypto++-dev cmake curl pkg-config libbson-dev && \
    curl -OL https://github.com/mongodb/mongo-cxx-driver/archive/r3.0.2.tar.gz && \
    tar -xzf r3.0.2.tar.gz && \
    cd mongo-cxx-driver-r3.0.2/build && \
    cmake -DCMAKE_BUILD_TYPE=Release -DCMAKE_INSTALL_PREFIX=/usr/local .. && \
    make && make install && \
    cd /code/cpp && mkdir -p