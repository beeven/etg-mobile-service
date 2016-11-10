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
#include "auth.grpc.pb.h"
#include "entry_data.grpc.pb.h"
#include "entry_data_service_impl.h"

using grpc::Server;
using grpc::ServerBuilder;
using grpc::ServerContext;
using grpc::ServerReader;
using grpc::ServerReaderWriter;
using grpc::ServerWriter;
using grpc::Status;
using etg::auth::Auth;
using etg::auth::LoginRequest;
using etg::auth::LoginResponse;
using std::chrono::system_clock;
using etg::data::entry::EntryDataService;

class EtgServiceImpl final : public Auth::Service {
    public:
        explicit EtgServiceImpl() {

        }

        Status Login(ServerContext* context, const LoginRequest* loginRequest, LoginResponse* LoginResponse) override {
            std::cout << "Login Email: " << loginRequest->email() << std::endl;
            LoginResponse->set_is_successful(true);

            struct timeval tv;
            gettimeofday(&tv, NULL);
            LoginResponse->mutable_timestamp_expire_at()->set_seconds(tv.tv_sec);
            LoginResponse->mutable_timestamp_expire_at()->set_nanos(tv.tv_usec * 1000);
            return Status::OK;
        }
};

void RunServer() {

    EtgServiceImpl service;
    etg::data::entry::EntryDataServiceImpl data_service;

    grpc::SslServerCredentialsOptions options;
    options.force_client_auth = true;
    options.pem_root_certs = "-----BEGIN CERTIFICATE-----\n"
            "MIIFSzCCBDOgAwIBAgIJAK1eE69OSQpDMA0GCSqGSIb3DQEBBQUAMIHJMQswCQYD\n"
            "VQQGEwJDTjESMBAGA1UECBMJR3Vhbmdkb25nMRIwEAYDVQQHEwlHdWFuZ3pob3Ux\n"
            "JjAkBgNVBAoTHUd1YW5nemhvdSBDdXN0b21zIERhdGEgQ2VudGVyMSIwIAYDVQQL\n"
            "ExlJVCBEZXZlbG9wbWVudCBEZXBhcnRtZW50MR8wHQYDVQQDExZlcG9ydC5nemN1\n"
            "c3RvbXMuZ292LmNuMSUwIwYJKoZIhvcNAQkBFhZhZG1pbkBnemN1c3RvbXMuZ292\n"
            "LmNuMB4XDTE2MTEwOTA4NDAzMVoXDTE5MTEwOTA4NDAzMlowgckxCzAJBgNVBAYT\n"
            "AkNOMRIwEAYDVQQIEwlHdWFuZ2RvbmcxEjAQBgNVBAcTCUd1YW5nemhvdTEmMCQG\n"
            "A1UEChMdR3Vhbmd6aG91IEN1c3RvbXMgRGF0YSBDZW50ZXIxIjAgBgNVBAsTGUlU\n"
            "IERldmVsb3BtZW50IERlcGFydG1lbnQxHzAdBgNVBAMTFmVwb3J0Lmd6Y3VzdG9t\n"
            "cy5nb3YuY24xJTAjBgkqhkiG9w0BCQEWFmFkbWluQGd6Y3VzdG9tcy5nb3YuY24w\n"
            "ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDTIJTVIP7FkoiGBgmftHPO\n"
            "MGZb1wdY5WVFwK8gwtmwPweSwMOoLCddey5eIMk7L2KZFciUxLR9oD1vIDetZcKl\n"
            "2OWccOenb/e7A06qFTQb0yfXZQfAXGVb/k+ansHsOVHT64nGFM+Fkr1eECJ4qkpf\n"
            "ilaBn3BRoOsv2igEs9eumAjWDXsibClXk635rLlBkz0N0GryoRt8rhCJZ6CFsHmW\n"
            "PvZLKHgqvTwPxIu5LjKUsjqCW87voxCp2EMGI/XnQnZSsmDINit7Q0iANxLtWNt0\n"
            "sHMxFRT0AalOXsbXdGkrS+9z+Hfo8jDfGrlqwNF+Gl5HKpm6vYx3pFdz0u2wiWqd\n"
            "AgMBAAGjggEyMIIBLjAdBgNVHQ4EFgQUirkI0sbw8+YcockLVrXS+SEL7Pcwgf4G\n"
            "A1UdIwSB9jCB84AUirkI0sbw8+YcockLVrXS+SEL7Pehgc+kgcwwgckxCzAJBgNV\n"
            "BAYTAkNOMRIwEAYDVQQIEwlHdWFuZ2RvbmcxEjAQBgNVBAcTCUd1YW5nemhvdTEm\n"
            "MCQGA1UEChMdR3Vhbmd6aG91IEN1c3RvbXMgRGF0YSBDZW50ZXIxIjAgBgNVBAsT\n"
            "GUlUIERldmVsb3BtZW50IERlcGFydG1lbnQxHzAdBgNVBAMTFmVwb3J0Lmd6Y3Vz\n"
            "dG9tcy5nb3YuY24xJTAjBgkqhkiG9w0BCQEWFmFkbWluQGd6Y3VzdG9tcy5nb3Yu\n"
            "Y26CCQCtXhOvTkkKQzAMBgNVHRMEBTADAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCW\n"
            "wA2LMsIyuK02FiisLFlckQ/yg9wkIVi37z83LR+m24LqHsB4j54HCkPaUCU/sWbq\n"
            "fxcmPgJslEJKBiHT9JQS8AIgrP3/zov3RyA5As+dyEVBh6HTHXAjuCFdyEmhuNRG\n"
            "yR0b9/MPsIncjD+DZrnkV5a2UvROZKGMS/bF6NgsV9eNrAOKZvOX55IvKytYFoTW\n"
            "qZqCqEvNABMzEOGNqmbjnCAETWyTRRMyVzQTpC7KrinaWnYVzRPOOI+MCc4lNIbP\n"
            "dO+ygg2k6HRG1KIzaI4/YKrc7+qAnYo0Ot0ezivfMx4Qzbbq7TXysWH1po5zRSGz\n"
            "EQ7X3D8WAC54mSRvmVCh\n"
            "-----END CERTIFICATE-----";
    options.pem_key_cert_pairs.push_back({
              "-----BEGIN RSA PRIVATE KEY-----\n"
              "MIIEowIBAAKCAQEAyuj7zFxx+X07qGDmtkGKhHyALsvYUeVSx7gc4nmaoS+s1Rbt\n"
              "Ly/cYUyIwFYMJISpZgUSBvPDufPftAQSV4WRkYBpI3romYAccPUP4zqtkV8Vz30z\n"
              "lhdtDZzghOD+pevHQ6Yl/U0XmRAlDV2nFwummnK7J7uuhPuZspSVAqnaomPmPrgr\n"
              "+VI4vRwQapwl1ptLFTSDvK3VkkhV9uz5W/IYKIQY2d97cvTOuD0dG1wYIkX7LhCr\n"
              "4L/cxlv2/YbvomN4UwD3Hmvl2fuL13mmylU/SoSSYH7QniW3xhOLIAfwfRTYG7Qz\n"
              "7BML92CKLYOg5uXYGLHpSnI/V1PKZY7fkfUX3QIDAQABAoIBAFxBQ8KtwXBCvS4Y\n"
              "KK1y7SzBgnJEYi0SC+ocTp211lU03OrhiqNqqlNevcpdFRZBbtegtIqOqE3SkMJD\n"
              "G6fJZd72uFbWWgz4j3XYJgoVMrcmuT7mWN8D9aQ70GT5+y2rHqUmVJ1vQKxqB76k\n"
              "9wRmWrBcO7WcAoQZ9M6Z+YoFeg9cdxSn1pUE3O19BSBJ+FaaUpRN+h22hIGpdE5d\n"
              "dRyfGRZNFc+iauc2lPOSrO16Kz0vGg5xAn8qnUs+1JPaPk6mLNzvhsEJJ74PbyTK\n"
              "YCSMRpFWn/+gXmdK4FolvRrh/Uw6uh6WzsM9OXt876ni+1Z3ERGVtkW2ytZ6pBRL\n"
              "XNaSQI0CgYEA6QvWm7PxYf90605tyGcyJn9gEWFXV6/5e2dHFoYd5DwaADYY8Jyt\n"
              "kxDpq6mVkm2WBFRra6D/goPRLW55iuqXGsMrxLbEXJZqhhUoEyf+gSAJMO4y2Ln0\n"
              "Lu2MYlw85kzpcUeIsifHosHXRqenoI4hBRwLwgToKTLz1FBULUTozysCgYEA3uVG\n"
              "arFyUHhn93PN/2e9z24JujW8dBIuFg8AWaMuLwx3vRDRByQ93e2OSlflqzaPyYIh\n"
              "2oQUEFt5OCRvCLrjGBccWHOhuL9D046i8nNDONaX28UHiXoLIjzZimj9NC5vEKmH\n"
              "9xvQ4/MGqd2xaVkMg/CWp9bdERaFcxtGHQiJ8RcCgYEArMMh7XuQTl3ahzY1HIOk\n"
              "IfX7eeb3oQHLqTf+8yuprTEA9XclNfpwkr3O/HtTbqHevIb4u2k3AcJGp69mWx1d\n"
              "t3FIWSREnX7EqXG1q73SZlcheSycdR4lb0Sa9a/7VZ9ez6OAKtJipL2eobpYAiZb\n"
              "RDZuYP7SPPiQ2axTOtwC2tECgYAlBGbBaV7WxmhdzDm15QC85kVvS2VU0YAd4bfp\n"
              "KxSMc8GfAJ/2U6qCpOUwq5BU8ubGTHpa0/yRCuAC1uopxP/aDFyExA9jo0Acbl/Z\n"
              "bBMJ6Xmm4f3ycvZOZVSri+whMmT3m3AdNd1nPgEpTMwd9tABSX97uE9WeysGhs0K\n"
              "HVTrWQKBgCanFywp6OfplulgNQmqx+rfaGwhurkmvn+T6MAmye1U09wCTAU0ltVF\n"
              "D6De2rVAzFJMMtG1U4SLBXjZ9qaVr2qYxLnelHD0FsGSKYB4wDIiaeNzMOoV68oI\n"
              "2So3h2Gjz5WTMSlnLhUwsD8zq8qkzlCCsKEQ/PXNMGONPq8mRrdO\n"
              "-----END RSA PRIVATE KEY-----",
              "-----BEGIN CERTIFICATE-----\n"
            "MIIDlDCCAnwCAQMwDQYJKoZIhvcNAQEFBQAwgckxCzAJBgNVBAYTAkNOMRIwEAYD\n"
            "VQQIEwlHdWFuZ2RvbmcxEjAQBgNVBAcTCUd1YW5nemhvdTEmMCQGA1UEChMdR3Vh\n"
            "bmd6aG91IEN1c3RvbXMgRGF0YSBDZW50ZXIxIjAgBgNVBAsTGUlUIERldmVsb3Bt\n"
            "ZW50IERlcGFydG1lbnQxHzAdBgNVBAMTFmVwb3J0Lmd6Y3VzdG9tcy5nb3YuY24x\n"
            "JTAjBgkqhkiG9w0BCQEWFmFkbWluQGd6Y3VzdG9tcy5nb3YuY24wHhcNMTYxMTA5\n"
            "MDkyNjA0WhcNMTkxMTA5MDkyNjA0WjBWMQswCQYDVQQGEwJDTjESMBAGA1UECAwJ\n"
            "R3Vhbmdkb25nMRIwEAYDVQQHDAlHdWFuZ3pob3UxCzAJBgNVBAsMAklUMRIwEAYD\n"
            "VQQDDAlsb2NhbGhvc3QwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDK\n"
            "6PvMXHH5fTuoYOa2QYqEfIAuy9hR5VLHuBzieZqhL6zVFu0vL9xhTIjAVgwkhKlm\n"
            "BRIG88O589+0BBJXhZGRgGkjeuiZgBxw9Q/jOq2RXxXPfTOWF20NnOCE4P6l68dD\n"
            "piX9TReZECUNXacXC6aacrsnu66E+5mylJUCqdqiY+Y+uCv5Uji9HBBqnCXWm0sV\n"
            "NIO8rdWSSFX27Plb8hgohBjZ33ty9M64PR0bXBgiRfsuEKvgv9zGW/b9hu+iY3hT\n"
            "APcea+XZ+4vXeabKVT9KhJJgftCeJbfGE4sgB/B9FNgbtDPsEwv3YIotg6Dm5dgY\n"
            "selKcj9XU8pljt+R9RfdAgMBAAEwDQYJKoZIhvcNAQEFBQADggEBAKj1cwrFMiUJ\n"
            "bgXRczNc5UpNsoHs5nDU91DYZM6vSVFQeP74kOAOnXwLjonQzGXWtlaF+zLVjvll\n"
            "PinA6abiYU8iHVfrS1NjS5nxYSIibkBgGtQAvmU5TXb4c1EvNAcdq2+v7PQ/acw8\n"
            "ppb5S1ZBLewwULFS1pRPu/DNnUQovdLNEB+KKp1plUTpGMeYj5vD0xFa4pD5O5/K\n"
            "CGFIZNVqzGvac4NEVL5F541gV0F2OlFgs6+xklKSM/eUEmxkjKDWzdk3UHybd8up\n"
            "dTFwYANrcu66JrRCuHEBkwP3v0C+a2UIazYMfb1sJVzltTGRcxq/nfeQPMUmfzPi\n"
            "avJfH0jzhbU=\n"
            "-----END CERTIFICATE-----"});

    std::string server_address("0.0.0.0:8443");
    ServerBuilder builder;
    //builder.AddListeningPort(server_address, grpc::InsecureServerCredentials());
    builder.AddListeningPort(server_address, grpc::SslServerCredentials(options));
    builder.RegisterService(&service);
    builder.RegisterService(&data_service);
    std::unique_ptr<Server> server(builder.BuildAndStart());
    std::cout << "Server listening on " << server_address << std::endl;
    server->Wait();
}

int main(int argc, char** argv) {
    RunServer();
    return 0;
}