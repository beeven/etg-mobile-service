# 广州海关易通关接口

接口使用gRPC传输，对象以protobuf方式序列化，使用服务器证书与客户端证书认证。

接口及对象定义参看[protos](./protos) 文件夹

## 使用方法
1. 参考[gRPC网站](https://grpc.io)安装对应语言版本的gRPC环境
2. 根据protos文件夹里面的 .proto 文件生成对应的文件，添加到项目中
3. 使用`openssl`等工具生成证书签名请求，发给 administrator@gzcustoms.gov.cn ，由海关签名生成证书后发回
4. 将证书与key应用到client的channel中，服务器地址是 gzeport.gzcustoms.gov.cn:8443 

## Client示例
[python/entry_data_client.py](python/entry_data_client.py)
[csharp/EtgServiceClient](csharp/EtgServiceClient)


## Server 部署步骤
### Windows
1. 编译生成 csharp/EtgService 下的解决方案
2. 命令行执行 csharp/EtgService/EtgService 项目，看是否能正确执行，根据即将部署的服务器域名生成证书，添加到 csharp/EtgService/EtgService/appsettings.json 中
3. 使用 `sc` 命令创建 Windows 服务：`sc create EtgService binPath= 'x:\.....\EtgService.exe --service'`
4. 启动服务

### Linux
1. 编辑 cpp/ :
```bash
mkdir cpp/build
cd cpp/build
cmake ../
make
```
2. 运行 `./cpp/build/etg_service_server`

### Docker
已经生成的镜像在国内存放于aliyun中，直接下载运行即可
```bash
docker pull registry.cn-hangzhou.aliyuncs.com/beeven/etg-grpc-service
docker run -d -p 8443:8443 registry.cn-hangzhou.aliyuncs.com/beeven/etg-grpc-service
```