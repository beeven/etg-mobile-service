#include <algorithm>
#include <chrono>
#include <cmath>
#include <iostream>
#include <memory>
#include <string>
#include <sys/time.h>

#include <grpc/grpc.h>
#include <grpc++/server.h>
#include <grpc++/server_builder.h>
#include <grpc++/server_context.h>
#include <grpc++/security/server_credentials.h>
//#include <google/protobuf/timestamp.pb.h>
//#include "helper.h"
#include "service.grpc.pb.h"

using grpc::Server;
using grpc::ServerBuilder;
using grpc::ServerContext;
using grpc::ServerReader;
using grpc::ServerReaderWriter;
using grpc::ServerWriter;
using grpc::Status;
using etg::service::Auth;
using etg::auth::LoginRequest;
using etg::auth::LoginReply;
using std::chrono::system_clock;

class EtgServiceImpl final : public Auth::Service {
    public:
        explicit EtgServiceImpl() {

        }

        Status Login(ServerContext* context, const LoginRequest* loginRequest, LoginReply* loginReply) override {
            std::cout << "Login Email: " << loginRequest->email() << std::endl;
            loginReply->set_is_successful(true);

            struct timeval tv;
            gettimeofday(&tv, NULL);
            loginReply->mutable_timestamp_expire_at()->set_seconds(tv.tv_sec);
            loginReply->mutable_timestamp_expire_at()->set_nanos(tv.tv_usec * 1000);
            return Status::OK;
        }
};

void RunServer() {
    std::string server_address("0.0.0.0:50051");
    EtgServiceImpl service;
    ServerBuilder builder;
    builder.AddListeningPort(server_address, grpc::InsecureServerCredentials());
    builder.RegisterService(&service);
    std::unique_ptr<Server> server(builder.BuildAndStart());
    std::cout << "Server listening on " << server_address << std::endl;
    server->Wait();
}

int main(int argc, char** argv) {
    RunServer();
    return 0;
}