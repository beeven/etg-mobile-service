# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: profile.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='profile.proto',
  package='etg.profile',
  syntax='proto3',
  serialized_pb=_b('\n\rprofile.proto\x12\x0b\x65tg.profile\"W\n\x0bUserProfile\x12\x0c\n\x04name\x18\x01 \x01(\t\x12\r\n\x05\x65mail\x18\x02 \x01(\t\x12\x0e\n\x06mobile\x18\x03 \x01(\t\x12\x1b\n\x13\x61uthentication_mode\x18\x04 \x01(\r\"\xba\x01\n\x0e\x43ompanyProfile\x12\x12\n\ncompany_id\x18\x01 \x01(\t\x12\x0e\n\x06org_co\x18\x02 \x01(\t\x12\x1a\n\x12social_credit_code\x18\x03 \x01(\t\x12\x0c\n\x04name\x18\x04 \x01(\t\x12\x14\n\x0c\x63ontact_name\x18\x05 \x01(\t\x12\x16\n\x0e\x63ontact_mobile\x18\x06 \x01(\t\x12\x14\n\x0claw_man_name\x18\x07 \x01(\t\x12\x16\n\x0elaw_man_mobile\x18\x08 \x01(\t\"l\n\x14UpdateProfileRequest\x12\x14\n\x0c\x61\x63\x63\x65ss_token\x18\x01 \x01(\t\x12\x0c\n\x04name\x18\x02 \x01(\t\x12\r\n\x05\x65mail\x18\x03 \x01(\t\x12\x0e\n\x06mobile\x18\x04 \x01(\t\x12\x11\n\tnewPasswd\x18\x05 \x01(\t\"?\n\x15UpdateProfileResponse\x12\x15\n\ris_successful\x18\x01 \x01(\x08\x12\x0f\n\x07message\x18\x02 \x01(\t2c\n\x07Profile\x12X\n\rUpdateProfile\x12!.etg.profile.UpdateProfileRequest\x1a\".etg.profile.UpdateProfileResponse\"\x00\x42-\n\x0b\x65tg.profileB\x08\x45tgProtoP\x01\xa2\x02\x03\x45TG\xaa\x02\x0b\x45tg.Profileb\x06proto3')
)
_sym_db.RegisterFileDescriptor(DESCRIPTOR)




_USERPROFILE = _descriptor.Descriptor(
  name='UserProfile',
  full_name='etg.profile.UserProfile',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='name', full_name='etg.profile.UserProfile.name', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='email', full_name='etg.profile.UserProfile.email', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='mobile', full_name='etg.profile.UserProfile.mobile', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='authentication_mode', full_name='etg.profile.UserProfile.authentication_mode', index=3,
      number=4, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
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
  serialized_start=30,
  serialized_end=117,
)


_COMPANYPROFILE = _descriptor.Descriptor(
  name='CompanyProfile',
  full_name='etg.profile.CompanyProfile',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='company_id', full_name='etg.profile.CompanyProfile.company_id', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='org_co', full_name='etg.profile.CompanyProfile.org_co', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='social_credit_code', full_name='etg.profile.CompanyProfile.social_credit_code', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='name', full_name='etg.profile.CompanyProfile.name', index=3,
      number=4, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='contact_name', full_name='etg.profile.CompanyProfile.contact_name', index=4,
      number=5, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='contact_mobile', full_name='etg.profile.CompanyProfile.contact_mobile', index=5,
      number=6, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='law_man_name', full_name='etg.profile.CompanyProfile.law_man_name', index=6,
      number=7, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='law_man_mobile', full_name='etg.profile.CompanyProfile.law_man_mobile', index=7,
      number=8, type=9, cpp_type=9, label=1,
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
  serialized_start=120,
  serialized_end=306,
)


_UPDATEPROFILEREQUEST = _descriptor.Descriptor(
  name='UpdateProfileRequest',
  full_name='etg.profile.UpdateProfileRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='access_token', full_name='etg.profile.UpdateProfileRequest.access_token', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='name', full_name='etg.profile.UpdateProfileRequest.name', index=1,
      number=2, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='email', full_name='etg.profile.UpdateProfileRequest.email', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='mobile', full_name='etg.profile.UpdateProfileRequest.mobile', index=3,
      number=4, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='newPasswd', full_name='etg.profile.UpdateProfileRequest.newPasswd', index=4,
      number=5, type=9, cpp_type=9, label=1,
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
  serialized_start=308,
  serialized_end=416,
)


_UPDATEPROFILERESPONSE = _descriptor.Descriptor(
  name='UpdateProfileResponse',
  full_name='etg.profile.UpdateProfileResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='is_successful', full_name='etg.profile.UpdateProfileResponse.is_successful', index=0,
      number=1, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None),
    _descriptor.FieldDescriptor(
      name='message', full_name='etg.profile.UpdateProfileResponse.message', index=1,
      number=2, type=9, cpp_type=9, label=1,
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
  serialized_start=418,
  serialized_end=481,
)

DESCRIPTOR.message_types_by_name['UserProfile'] = _USERPROFILE
DESCRIPTOR.message_types_by_name['CompanyProfile'] = _COMPANYPROFILE
DESCRIPTOR.message_types_by_name['UpdateProfileRequest'] = _UPDATEPROFILEREQUEST
DESCRIPTOR.message_types_by_name['UpdateProfileResponse'] = _UPDATEPROFILERESPONSE

UserProfile = _reflection.GeneratedProtocolMessageType('UserProfile', (_message.Message,), dict(
  DESCRIPTOR = _USERPROFILE,
  __module__ = 'profile_pb2'
  # @@protoc_insertion_point(class_scope:etg.profile.UserProfile)
  ))
_sym_db.RegisterMessage(UserProfile)

CompanyProfile = _reflection.GeneratedProtocolMessageType('CompanyProfile', (_message.Message,), dict(
  DESCRIPTOR = _COMPANYPROFILE,
  __module__ = 'profile_pb2'
  # @@protoc_insertion_point(class_scope:etg.profile.CompanyProfile)
  ))
_sym_db.RegisterMessage(CompanyProfile)

UpdateProfileRequest = _reflection.GeneratedProtocolMessageType('UpdateProfileRequest', (_message.Message,), dict(
  DESCRIPTOR = _UPDATEPROFILEREQUEST,
  __module__ = 'profile_pb2'
  # @@protoc_insertion_point(class_scope:etg.profile.UpdateProfileRequest)
  ))
_sym_db.RegisterMessage(UpdateProfileRequest)

UpdateProfileResponse = _reflection.GeneratedProtocolMessageType('UpdateProfileResponse', (_message.Message,), dict(
  DESCRIPTOR = _UPDATEPROFILERESPONSE,
  __module__ = 'profile_pb2'
  # @@protoc_insertion_point(class_scope:etg.profile.UpdateProfileResponse)
  ))
_sym_db.RegisterMessage(UpdateProfileResponse)


DESCRIPTOR.has_options = True
DESCRIPTOR._options = _descriptor._ParseOptions(descriptor_pb2.FileOptions(), _b('\n\013etg.profileB\010EtgProtoP\001\242\002\003ETG\252\002\013Etg.Profile'))
import grpc
from grpc.beta import implementations as beta_implementations
from grpc.beta import interfaces as beta_interfaces
from grpc.framework.common import cardinality
from grpc.framework.interfaces.face import utilities as face_utilities


class ProfileStub(object):

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.UpdateProfile = channel.unary_unary(
        '/etg.profile.Profile/UpdateProfile',
        request_serializer=UpdateProfileRequest.SerializeToString,
        response_deserializer=UpdateProfileResponse.FromString,
        )


class ProfileServicer(object):

  def UpdateProfile(self, request, context):
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_ProfileServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'UpdateProfile': grpc.unary_unary_rpc_method_handler(
          servicer.UpdateProfile,
          request_deserializer=UpdateProfileRequest.FromString,
          response_serializer=UpdateProfileResponse.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'etg.profile.Profile', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))


class BetaProfileServicer(object):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This class was generated
  only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0."""
  def UpdateProfile(self, request, context):
    context.code(beta_interfaces.StatusCode.UNIMPLEMENTED)


class BetaProfileStub(object):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This class was generated
  only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0."""
  def UpdateProfile(self, request, timeout, metadata=None, with_call=False, protocol_options=None):
    raise NotImplementedError()
  UpdateProfile.future = None


def beta_create_Profile_server(servicer, pool=None, pool_size=None, default_timeout=None, maximum_timeout=None):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This function was
  generated only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0"""
  request_deserializers = {
    ('etg.profile.Profile', 'UpdateProfile'): UpdateProfileRequest.FromString,
  }
  response_serializers = {
    ('etg.profile.Profile', 'UpdateProfile'): UpdateProfileResponse.SerializeToString,
  }
  method_implementations = {
    ('etg.profile.Profile', 'UpdateProfile'): face_utilities.unary_unary_inline(servicer.UpdateProfile),
  }
  server_options = beta_implementations.server_options(request_deserializers=request_deserializers, response_serializers=response_serializers, thread_pool=pool, thread_pool_size=pool_size, default_timeout=default_timeout, maximum_timeout=maximum_timeout)
  return beta_implementations.server(method_implementations, options=server_options)


def beta_create_Profile_stub(channel, host=None, metadata_transformer=None, pool=None, pool_size=None):
  """The Beta API is deprecated for 0.15.0 and later.

  It is recommended to use the GA API (classes and functions in this
  file not marked beta) for all further purposes. This function was
  generated only to ease transition from grpcio<0.15.0 to grpcio>=0.15.0"""
  request_serializers = {
    ('etg.profile.Profile', 'UpdateProfile'): UpdateProfileRequest.SerializeToString,
  }
  response_deserializers = {
    ('etg.profile.Profile', 'UpdateProfile'): UpdateProfileResponse.FromString,
  }
  cardinalities = {
    'UpdateProfile': cardinality.Cardinality.UNARY_UNARY,
  }
  stub_options = beta_implementations.stub_options(host=host, metadata_transformer=metadata_transformer, request_serializers=request_serializers, response_deserializers=response_deserializers, thread_pool=pool, thread_pool_size=pool_size)
  return beta_implementations.dynamic_stub(channel, 'etg.profile.Profile', cardinalities, options=stub_options)
# @@protoc_insertion_point(module_scope)
