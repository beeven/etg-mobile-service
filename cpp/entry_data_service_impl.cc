#include <algorithm>
#include <chrono>
#include <cmath>
#include <iostream>
#include <sstream>
#include <memory>
#include <string>
#include <sys/time.h>

#include <grpc/grpc.h>
#include <grpc++/server.h>
#include <grpc++/server_builder.h>
#include <grpc++/server_context.h>
#include <google/protobuf/util/time_util.h>

#include <curlpp/cURLpp.hpp>
#include <curlpp/Easy.hpp>
#include <curlpp/Options.hpp>

#include <rapidjson/document.h>

//#include <google/protobuf/timestamp.pb.h>

#include "entry_data.grpc.pb.h"
#include "entry_data_service_impl.h"

using grpc::Server;
using grpc::ServerBuilder;
using grpc::ServerContext;
using grpc::ServerReader;
using grpc::ServerReaderWriter;
using grpc::ServerWriter;
using grpc::Status;
using etg::data::entry::EntryDataService;
using etg::data::entry::GetEntryStatusRequest;
using etg::data::entry::GetEntryStatusResponse;
using std::chrono::system_clock;

using etg::data::entry::EntryDataServiceImpl;

EntryDataServiceImpl::EntryDataServiceImpl() {
}

Status EntryDataServiceImpl::GetEntryStatus(ServerContext *context,
                                            ServerReaderWriter<GetEntryStatusResponse, GetEntryStatusRequest> *stream) {

    GetEntryStatusRequest request;
    while (stream->Read(&request)) {
        EntryStatus entryStatus;
        GetEntryStatusResponse response;
        response.set_entry_id(request.entry_id());
        if( this->QueryEntryStatus(request.entry_id(),&entryStatus) ) {
            response.set_status_text(entryStatus.status_text);
            auto timestamp = new google::protobuf::Timestamp();
            google::protobuf::util::TimeUtil::FromString(entryStatus.declare_date, timestamp);
            response.set_allocated_declare_date(timestamp);
        } else {
            response.set_status_text("没有此报关单信息");
        }
        stream->Write(response);
    }
    return Status::OK;
}


bool EntryDataServiceImpl::QueryEntryStatus(const std::string &entry_id, EntryStatus* entryStatus) {
    try {
        {
            curlpp::Cleanup myCleanup;
            curlpp::Easy myRequest;
            std::string requestUrl("http://10.53.34.180:3001/entry_pop/api/entry/");
            requestUrl.append(entry_id);
            myRequest.setOpt<curlpp::options::Url>(requestUrl);
            std::ostringstream oss;
            myRequest.setOpt(curlpp::options::WriteStream(&oss));
            myRequest.perform();
            std::string response(oss.str()); // copy?
            using namespace rapidjson;
            Document document;
            document.Parse(response.c_str());
            if (document["code"].GetInt() == 200) {
                if (document["data"].HasMember(entry_id.c_str())) {
                    entryStatus->declare_date = document["data"][entry_id.c_str()]["declare_date"].GetString();
                    entryStatus->status_text = document["data"][entry_id.c_str()]["status"].GetString();
                    return true;
                }
            }
        }

    }
    catch (curlpp::RuntimeError &e) {
        std::cout << e.what() << std::endl;
    }
    catch (curlpp::LogicError &e) {
        std::cout << e.what() << std::endl;
    }
    return false;
}
