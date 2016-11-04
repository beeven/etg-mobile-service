#include <iostream>
#include <iomanip>
#include <bsoncxx/builder/stream/document.hpp>
#include <bsoncxx/json.hpp>
#include <mongocxx/client.hpp>
#include <mongocxx/instance.hpp>

#include <cryptopp/modes.h>
#include <cryptopp/aes.h>
#include <cryptopp/filters.h>

#include "database.h"




void AESTest() {
    byte key[CryptoPP::AES::DEFAULT_KEYLENGTH], iv[CryptoPP::AES::BLOCKSIZE];
    memset(key, 0x00, CryptoPP::AES::DEFAULT_KEYLENGTH);
    memset(iv, 0x00, CryptoPP::AES::BLOCKSIZE);
    std::string plaintext = "Hello world!";
    std::string ciphertext;
    std::string decryptedtext;
    std::cout << "Plain Text (" << plaintext.size() << " bytes)" << std::endl;
    std::cout << plaintext;
    std::cout << std::endl << std::endl;

    CryptoPP::AES::Encryption aesEncryption(key, CryptoPP::AES::DEFAULT_KEYLENGTH);
    CryptoPP::CBC_Mode_ExternalCipher::Encryption cbcEncryption(aesEncryption, iv);
    CryptoPP::StreamTransformationFilter stfEncryptor(cbcEncryption, new CryptoPP::StringSink(ciphertext));
    stfEncryptor.Put(reinterpret_cast<const unsigned char *>(plaintext.c_str()), plaintext.length() + 1);
    stfEncryptor.MessageEnd();

    std::cout << "Cipher Text (" << ciphertext.size() << " bytes)" << std::endl;
    for (int i = 0; i < ciphertext.size(); i++) {
        std::cout << "0x" << std::hex << (0xFF & static_cast<byte>(ciphertext[i])) << " ";
    }
    std::cout << std::endl << std::endl;

    CryptoPP::AES::Decryption aesDecryption(key, CryptoPP::AES::DEFAULT_KEYLENGTH);
    CryptoPP::CBC_Mode_ExternalCipher::Decryption cbcDecryption( aesDecryption, iv);
    CryptoPP::StreamTransformationFilter stfDecryptor(cbcDecryption, new CryptoPP::StringSink(decryptedtext));
    stfDecryptor.Put(reinterpret_cast<const unsigned char*>(ciphertext.c_str()), ciphertext.size());
    stfDecryptor.MessageEnd();
    std::cout << "Decrypted Text: " << std::endl;
    std::cout << decryptedtext << std::endl << std::endl;
}


int main(int argc, char **argv) {
    //mongocxx::instance inst{};
    mongocxx::client conn{mongocxx::uri{}};
    bsoncxx::builder::stream::document document{};

    auto collection = conn["test"]["testcollection"];
    document << "hello" << "world";
    collection.insert_one(document.view());
    auto cursor = collection.find({});
    for (auto doc: cursor) {
        std::cout << bsoncxx::to_json(doc) << std::endl;
    }

    bsoncxx::oid *doc_id;

    if(argc > 1) {
        doc_id = new bsoncxx::oid{argv[1]};
    } else {
        doc_id = new bsoncxx::oid{"581beda4a115e0a9a70f56e1"};
    }

    mongocxx::stdx::optional<bsoncxx::document::value> maybe_result = collection.find_one(bsoncxx::builder::stream::document{} << "_id" << *doc_id << bsoncxx::builder::stream::finalize);
    if(maybe_result) {
        std::cout << "found:" << bsoncxx::to_json(*maybe_result) << std::endl;
    }
    //AESTest();
}