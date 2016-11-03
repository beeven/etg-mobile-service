#include <chrono>
#include <iostream>
#include <memory>
#include <random>
#include <string>
#include <thread>
#include <sys/time.h>

#include <grpc/grpc.h>
#include <grpc++/channel.h>
#include <grpc++/client_context.h>
#include <grpc++/create_channel.h>
#include <grpc++/security/credentials.h>
//#include "helper.h"
#include "service.grpc.pb.h"

using grpc::Channel;
using grpc::ClientContext;
using grpc::ClientReader;
using grpc::ClientReaderWriter;
using grpc::ClientWriter;
using grpc::Status;
using etg::service::Auth;
using etg::auth::LoginRequest;
using etg::auth::LoginReply;

class EtgServiceClient {
    public:
        EtgServiceClient(std::shared_ptr<Channel> channel) : stub_(Auth::NewStub(channel)) {

        }
        bool Login() {
            LoginRequest loginRequest;
            ClientContext context;

            loginRequest.set_email("beeven@hotmail.com");
            loginRequest.set_login_type(etg::auth::LoginType::EMAIL);

            LoginReply loginReply;
            Status status = stub_->Login(&context, loginRequest, &loginReply);

            if (!status.ok()) {
                std::cout << "Login rpc failed." << std::endl;
                return false;
            }
            if (!loginReply.is_successful()) {
                std::cout << "Login failed." << std::endl;
                std::cout << "Reason: " << loginReply.message() << std::endl;
            } else {
                long seconds = loginReply.timestamp_expire_at().seconds();
                std::cout << "Login is successful." << std::endl;
                std::cout << "Expiring at " << seconds << std::endl;
            }
            return true;

        }
    private:
        std::unique_ptr<Auth::Stub> stub_;
};

int main(int argc, char** argv) {
    EtgServiceClient client(grpc::CreateChannel("localhost:50051",grpc::InsecureChannelCredentials()));
    client.Login();

    return 0;
}