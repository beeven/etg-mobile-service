package main

import (
	pb "entry_data"
	"flag"
	"fmt"
	"io"
	"net"

	"golang.org/x/net/context"
	"google.golang.org/grpc"
	"google.golang.org/grpc/credentials"
	"google.golang.org/grpc/grpclog"
)

var (
	tls      = flag.Bool("tls", false, "Connection uses TLS if true, else plain TCP")
	certFile = flag.String("cert_file", "../certs/server.cert", "The TLS cert file")
	keyFile  = flag.String("key_file", "../certs/server.key", "The TLS key file")
	port     = flag.Int("port", 10000, "The server port")
)

type etgServiceServer struct {
}

func (s *etgServiceServer) GetEntryStatus(stream pb.EntryDataService_GetEntryStatusServer) error {
	for {
		in, err := stream.Recv()
		if err == io.EOF {
			return nil
		}
		if err != nil {
			return err
		}
		res := pb.GetEntryStatusResponse{StatusText: "ok", EntryId: in.EntryId}
		if err := stream.Send(&res); err != nil {
			return err
		}
	}
}

func (s *etgServiceServer) GetYDTEntryDataFrom(request *pb.GetYDTEntryDataRequest, stream pb.EntryDataService_GetYDTEntryDataFromServer) error {

	return nil
}

func (s *etgServiceServer) GetYDTEntryDataAt(ctx context.Context, request *pb.GetYDTEntryDataRequest) (response *pb.GetYDTEntryDataResponse, err error) {
	response = new(pb.GetYDTEntryDataResponse)
	response.FileName = "test.txt"

	response.Data = []byte("test")
	return response, nil
}

func newServer() *etgServiceServer {
	s := new(etgServiceServer)
	return s
}

func main() {
	flag.Parse()
	lis, err := net.Listen("tcp", fmt.Sprintf(":%d", *port))
	if err != nil {
		grpclog.Fatalf("failed to listen: %v", err)
	}
	var opts []grpc.ServerOption
	if *tls {
		creds, err := credentials.NewServerTLSFromFile(*certFile, *keyFile)
		if err != nil {
			grpclog.Fatalf("failed to generate credentails %v", err)
		}
		opts = []grpc.ServerOption{grpc.Creds(creds)}
	}
	grpcServer := grpc.NewServer(opts...)
	pb.RegisterEntryDataServiceServer(grpcServer, newServer())
	fmt.Printf("server listening on: %d\n", *port)
	grpcServer.Serve(lis)

}
