
"""The Python implementation of the gRPC route guide client."""

from __future__ import print_function
import grpc

import entry_data_pb2


def generate_entry_ids():
    """Generate ids iterator"""
    entry_ids = ["518920160896053556", "516620160666505983",
                 "518920160896053557", "51520160536088309"]
    for entry in entry_ids:
        yield entry_data_pb2.GetEntryStatusRequest(entry_id=entry)


def query(stub):
    """connect to server using stub object"""
    replies = stub.GetEntryStatus(generate_entry_ids())
    for reply in replies:
        print("{0}:{1}\t{2}".format(reply.entry_id,
                                    reply.status_text, reply.declare_date.ToDatetime()))


def run():
    """setup server"""
    with open('../certs/ca.crt','rb') as f:
        ca_cert = f.read()
    with open('../certs/yidatong.key','rb') as f:
        key = f.read()
    with open('../certs/yidatong.crt', 'rb') as f:
        cert = f.read()
    credential = grpc.ssl_channel_credentials(ca_cert, key, cert)
    channel = grpc.secure_channel('gzeport.gzcustoms.gov.cn:8080', credential)
    #channel = grpc.insecure_channel('gzeport.gzcustoms.gov.cn:8080')
    stub = entry_data_pb2.EntryDataServiceStub(channel)
    query(stub)

if __name__ == "__main__":
    run()
