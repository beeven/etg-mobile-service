from pymong import MongoClient


class EtgDatabase(object):
    def __init__(self, url):
        self.client = MongoClient(url)
        self.db = client['etg']
    
    def findUserByEmail(self, email):
        pass
    
    def GrantAccessToken(self, userId):
        pass

    def RenewAccessToken(self, access_token):
        pass

    def RevokeAccessToken(self, access_token):
        pass
    
    