

#ifndef ETG_SERVICE_DATABASE_H__
#define ETG_SERVICE_DATABASE_H__


namespace etg {
    namespace service {
        class ETGDatabase {
        public:
            ETGDatabase();
            ETGDatabase(const char* database_url);
            bool VerifyCaptcha(const std::string& captcha_id, const std::string& captcha);
            std::string GenerateCaptcha() const;
        private:
            std::unique_ptr<mongocxx::client> conn;

        };
    }
}



#endif // ETG_SERVICE_DATABASE_H__