cmake_minimum_required(VERSION 3.6)
project(etg_service)


set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

find_package(PkgConfig)
pkg_check_modules(LIBMONGOCXX REQUIRED libmongocxx)
pkg_check_modules(LIBGRPCPP REQUIRED grpc++)
pkg_check_modules(LIBCURLPP REQUIRED curlpp)
include_directories(${LIBMONGOCXX_INCLUDE_DIRS}
        ${LIBCURLPP_INCLUDE_DIRS}
        ${CMAKE_CURRENT_SOURCE_DIR}
        ${CMAKE_CURRENT_BINARY_DIR})

set(PROTO_FILES_DIR ${PROJECT_SOURCE_DIR}/protos)

file(GLOB PROTO_FILES
        "${PROTO_FILES_DIR}/*.proto"
        )

set(GRPC_CPP_PLUGIN grpc_cpp_plugin)
execute_process(COMMAND which /usr/local/bin/grpc_cpp_plugin
        OUTPUT_VARIABLE GRPC_CPP_PLUGIN_PATH
        OUTPUT_STRIP_TRAILING_WHITESPACE)

execute_process(COMMAND protoc -I${PROTO_FILES_DIR} --cpp_out=${CMAKE_CURRENT_BINARY_DIR} --grpc_out=${CMAKE_CURRENT_BINARY_DIR} --plugin=protoc-gen-grpc=${GRPC_CPP_PLUGIN_PATH} ${PROTO_FILES})



set(ETG_SERVICE_SOURCE_FILES
        entry_data.pb.cc
        entry_data.grpc.pb.cc
        entry_data_service_impl.cc
        profile.pb.cc
        profile.grpc.pb.cc
        auth.pb.cc
        auth.grpc.pb.cc
        etg_service_server.cc
        )

add_executable(etg_service_server ${ETG_SERVICE_SOURCE_FILES})

target_link_libraries(etg_service_server
        ${LIBGRPCPP_LIBRARIES}
        ${LIBMONGOCXX_LIBRARIES}
        ${LIBCURLPP_LIBRARIES}
        pthread
        protobuf
        dl
        grpc++_reflection
        )

set(DATABASE_SOURCE_FILES
        database.cc)

add_executable(database ${DATABASE_SOURCE_FILES})

target_link_libraries(database
        ${LIBMONGOCXX_LIBRARIES}
        cryptopp
        )