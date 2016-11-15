//
// Created by Beeven on 10/11/2016.
//

#ifndef ETG_SERVICE_ENTRY_DATA_SERVICE_IMPL_H
#define ETG_SERVICE_ENTRY_DATA_SERVICE_IMPL_H

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

#include "entry_data.grpc.pb.h"

using grpc::ServerContext;
using grpc::ServerReaderWriter;
using grpc::ServerWriter;
using grpc::Status;
using etg::data::entry::EntryDataService;
using etg::data::entry::GetEntryStatusRequest;
using etg::data::entry::GetEntryStatusResponse;

namespace etg {
namespace data {
namespace entry {

    class EntryDataServiceImpl final : public EntryDataService::Service {

    public:
        explicit EntryDataServiceImpl(const char* pop_service_url);
        ~EntryDataServiceImpl();

        Status GetEntryStatus(ServerContext *context,
                              ServerReaderWriter<GetEntryStatusResponse, GetEntryStatusRequest> *stream) override;

    private:
        std::string pop_service_url;
        struct EntryStatus {
            std::string status_text;
            std::string declare_date;
        };
        bool QueryEntryStatus(const std::string &entry_id, EntryStatus* status);
    };
}
}
}


#endif //ETG_SERVICE_ENTRY_DATA_SERVICE_IMPL_H
