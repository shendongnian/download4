      string connectionString = "mongodb://10.10.32.125:27017";
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                MongoClient mongoClient = new MongoClient(settings);
                var Server = mongoClient.GetDatabase("mongovaibhav");
                var collection = Server.GetCollection<employee>("mongov");
                ObjectId objectId = ObjectId.Parse(id);
                  var filter = Builders<employee>.Filter.Eq(s => s._id, objectId);   
                string param = "{$set: { fname:'" + fname + "',lname:'" + lname + "',email:'" + email + "',pass:'" + password + "',address :'" + address + "' } }";
                BsonDocument document = BsonDocument.Parse(param);
                collection.UpdateMany(filter, document);
