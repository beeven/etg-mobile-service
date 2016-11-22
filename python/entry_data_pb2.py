# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: entry_data.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from google.protobuf import timestamp_pb2 as google_dot_protobuf_dot_timestamp__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='entry_data.proto',
  package='etg.data.entry',
  syntax='proto3',
  serialized_pb=_b('\n\x10\x65ntry_data.proto\x12\x0e\x65tg.data.entry\x1a\x1fgoogle/protobuf/timestamp.proto\")\n\x15GetEntryStatusRequest\x12\x10\n\x08\x65ntry_id\x18\x01 \x01(\t\"q\n\x16GetEntryStatusResponse\x12\x10\n\x08\x65ntry_id\x18\x01 \x01(\t\x12\x13\n\x0bstatus_text\x18\x02 \x01(\t\x12\x30\n\x0c\x64\x65\x63lare_date\x18\x03 \x01(\x0b\x32\x1a.google.protobuf.Timestamp2y\n\x10\x45ntryDataService\x12\x65\n\x0eGetEntryStatus\x12%.etg.data.entry.GetEntryStatusRequest\x1a&.etg.data.entry.GetEntryStatusResponse\"\x00(\x01\x30\x01\x42\x33\n\x0e\x65tg.data.entryB\x08\x45tgProtoP\x01\xa2\x02\x03\x45TG\xaa\x02\x0e\x45tg.Data.Entryb\x06proto3')
  ,
  dependencies=[google_dot_protobuf_dot_timestamp__pb2.DESCRIPTOR,])
_sym_db.RegisterFileDescriptor(DESCRIPTOR)




_GETENTRYSTATUSREQUEST = _descriptor.Descriptor(
  name='GetEntryStatusRequest',
  full_name='etg.data.entry.GetEntryStatusRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='entry_id', full_name='etg.data.entry.GetEntryStatusRequest.entry_id', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=69,
  serialized_end=110,
)


_GETENTRYSTATUSRESPONSE = _descriptor.Descriptor(
  name='GetEntryStatusResponse',
  full_name='etg.data.entry.GetEntryStatusResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='entry_id', full_name='etg.data.entry.GetEntryStatusResponse.entry_id', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='status_text', full_name='etg.data.entry.GetEntryStatusResponse.status_text', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='declare_date', full_name='etg.data.entry.GetEntryStatusResponse.declare_date', index=2,
      number=3, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=112,
  serialized_end=225,
)

_GETENTRYSTATUSRESPONSE.fields_by_name['declare_date'].message_type = google_dot_protobuf_dot_timestamp__pb2._TIMESTAMP
DESCRIPTOR.message_types_by_name['GetEntryStatusRequest'] = _GETENTRYSTATUSREQUEST
DESCRIPTOR.message_types_by_name['GetEntryStatusResponse'] = _GETENTRYSTATUSRESPONSE

GetEntryStatusRequest = _reflection.GeneratedProtocolMessageType('GetEntryStatusRequest', (_message.Message,), dict(
  DESCRIPTOR = _GETENTRYSTATUSREQUEST,
  __module__ = 'entry_data_pb2'
  # @@protoc_insertion_point(class_scope:etg.data.entry.GetEntryStatusRequest)
  ))
_sym_db.RegisterMessage(GetEntryStatusRequest)

GetEntryStatusResponse = _reflection.GeneratedProtocolMessageType('GetEntryStatusResponse', (_message.Message,), dict(
  DESCRIPTOR = _GETENTRYSTATUSRESPONSE,
  __module__ = 'entry_data_pb2'
  # @@protoc_insertion_point(class_scope:etg.data.entry.GetEntryStatusResponse)
  ))
_sym_db.RegisterMessage(GetEntryStatusResponse)


DESCRIPTOR.has_options = True
DESCRIPTOR._options = _descriptor._ParseOptions(descriptor_pb2.FileOptions(), _b('\n\016etg.data.entryB\010EtgProtoP\001\242\002\003ETG\252\002\016Etg.Data.Entry'))
import grpc
from grpc.beta import implementations as beta_implementations
from grpc.beta import interfaces as beta_interfaces
from grpc.framework.common import cardinality
from grpc.framework.interfaces.face import utilities as face_utilities


class EntryDataServiceStub(object):

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.GetEntryStatus = channel.stream_stream(
        '/etg.data.entry.EntryDataService/GetEntryStatus',
        request_serializer=GetEntryStatusRequest.SerializeToString,
        response_deserializer=GetEntryStatusResponse.FromString,
        )


class EntryDataServiceServicer(object):

  def GetEntryStatus(self, request_iterator, context):
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_EntryDataServiceServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'GetEntryStatus': grpc.stream_stream_rpc_method_handler(
          servicer.GetEntryStatus,
          request_deserializer=GetEntryStatusRequest.FromString,
          response_serializer=GetEntryStatusResponse.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'etg.data.entry.EntryDataService', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))


class BetaEntryDataServiceServicer(object):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This class was generated
  only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0."""
  def GetEntryStatus(self, request_iterator, context):
    context.code(beta_interfaces.StatusCode.UNIMPLEMENTED)


class BetaEntryDataServiceStub(object):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This class was generated
  only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0."""
  def GetEntryStatus(self, request_iterator, timeout, metadata=None, with_call=False, protocol_options=None):
    raise NotImplementedError()


def beta_create_EntryDataService_server(servicer, pool=None, pool_size=None, default_timeout=None, maximum_timeout=None):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This function was
  generated only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0"""
  request_deserializers = {
    ('etg.data.entry.EntryDataService', 'GetEntryStatus'): GetEntryStatusRequest.FromString,
  }
  response_serializers = {
    ('etg.data.entry.EntryDataService', 'GetEntryStatus'): GetEntryStatusResponse.SerializeToString,
  }
  method_implementations = {
    ('etg.data.entry.EntryDataService', 'GetEntryStatus'): face_utilities.stream_stream_inline(servicer.GetEntryStatus),
  }
  server_options = beta_implementations.server_options(request_deserializers=request_deserializers, response_serializers=response_serializers, thread_pool=pool, thread_pool_size=pool_size, default_timeout=default_timeout, maximum_timeout=maximum_timeout)
  return beta_implementations.server(method_implementations, options=server_options)


def beta_create_EntryDataService_stub(channel, host=None, metadata_transformer=None, pool=None, pool_size=None):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This function was
  generated only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0"""
  request_serializers = {
    ('etg.data.entry.EntryDataService', 'GetEntryStatus'): GetEntryStatusRequest.SerializeToString,
  }
  response_deserializers = {
    ('etg.data.entry.EntryDataService', 'GetEntryStatus'): GetEntryStatusResponse.FromString,
  }
  cardinalities = {
    'GetEntryStatus': cardinality.Cardinality.STREAM_STREAM,
  }
  stub_options = beta_implementations.stub_options(host=host, metadata_transformer=metadata_transformer, request_serializers=request_serializers, response_deserializers=response_deserializers, thread_pool=pool, thread_pool_size=pool_size)
  return beta_implementations.dynamic_stub(channel, 'etg.data.entry.EntryDataService', cardinalities, options=stub_options)
# @@protoc_insertion_point(module_scope)