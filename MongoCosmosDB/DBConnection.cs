using MoCoMad.DataDownload;
using MoCoMad.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace MoCoMad.MongoCosmosDB
{
    public class DBConnection
    {
        #region AZURE COSMOS MONGO DB

        ObservableCollection<AirQualityData> AirQualityDataColletion;

        public MongoClient MongoDBConnection()
        {
            //MOCOMAD1
            //string connectionString = @"mongodb://mocomad:AcAlRDM3cPbD1UtinQ5eMEOxGsKEQVp7Zz1W7y9Luukg1fGon23OoBIJmsWWM43QwjIfCtw4RrtdwW4NR62mhg==@mocomad.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            //MongoClientSettings settings = MongoClientSettings.FromUrl(
            //  new MongoUrl(connectionString)
            //);
            //settings.SslSettings =
            //  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            //var mongoClient = new MongoClient(settings);

            //MOCOMAD2
            string connectionString = @"mongodb://mocomad2:ZEnlszRx6GDrIw1eNpnQjh9yEqYFx47PDIaKUpDjwfVw69aUrvKTvRVpgcfgVXpeHsGpo6lvybIVSazEvgpUzw==@mocomad2.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            try
            {
                MongoClient dbClient = new MongoClient(connectionString);

                return dbClient;


                //#region DATABASE LIST

                //var dbList = dbClient.ListDatabases().ToList();

                //Console.WriteLine("The list of databases are :");
                //foreach (var item in dbList)
                //{
                //    Console.WriteLine(item);
                //}

                //#endregion DATABASE LIST

                ////Get Database and Collection
                //IMongoDatabase db = dbClient.GetDatabase("AirQualityMad");
                //var collList = db.ListCollections().ToList();
                //Console.WriteLine("The list of collections are :");
                //foreach (var item in collList)
                //{
                //    Console.WriteLine(item);
                //}

                //var _2017Collection = db.GetCollection<BsonDocument>("2017");
                //var _2018Collection = db.GetCollection<BsonDocument>("2018");

                //var personColl = db.GetCollection<BsonDocument>("personColl");

                ////CREATE  
                //BsonElement personFirstNameElement = new BsonElement("PersonFirstName", "Sankhojjal");

                //BsonDocument personDoc = new BsonDocument();
                //personDoc.Add(personFirstNameElement);
                //personDoc.Add(new BsonElement("PersonAge", 23));

                //personColl.InsertOne(personDoc);

                ////UPDATE  
                //BsonElement updatePersonFirstNameElement = new BsonElement("PersonFirstName", "Souvik");

                //BsonDocument updatePersonDoc = new BsonDocument();
                //updatePersonDoc.Add(updatePersonFirstNameElement);
                //updatePersonDoc.Add(new BsonElement("PersonAge", 24));

                //BsonDocument findPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sankhojjal"));

                //var updateDoc = personColl.FindOneAndReplace(findPersonDoc, updatePersonDoc);

                //Console.WriteLine(updateDoc);

                ////DELETE  
                //BsonDocument findAnotherPersonDoc = new BsonDocument(new BsonElement("PersonFirstName", "Sourav"));

                //personColl.FindOneAndDelete(findAnotherPersonDoc);

                ////READ  
                //var resultDoc = personColl.Find(new BsonDocument()).ToList();
                //foreach (var item in resultDoc)
                //{
                //    Console.WriteLine(item.ToString());
                //}



            }
            catch (Exception e)
            {
                var error = e.Message;
                return null;
            }
        }

        public void CreateHistoricalData()
        {
            MongoClient dbClient = MongoDBConnection();
            DataDownloadHelper _downloadDataHelper = new DataDownloadHelper();

            #region GET DATABASE AND COLLECTIONS

            IMongoDatabase db = dbClient.GetDatabase("AirQualityMad");
            var collList = db.ListCollections().ToList();
            Console.WriteLine("The list of collections are :");
            foreach (var item in collList)
            {
                Console.WriteLine(item);
            }


            #endregion GET DATABASE AND COLLECTIONS

            #region CREATE HISTORICAL DATA

            #region 2017

            /*
            var _2017OctCollection = db.GetCollection<BsonDocument>("Oct17");
            var _2017NovCollection = db.GetCollection<BsonDocument>("Nov17");
            var _2017DicCollection = db.GetCollection<BsonDocument>("Dic17");

            ObservableCollection<AirQualityData> _2017OctData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2017NovData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2017DicData = new ObservableCollection<AirQualityData>();
            
            _2017OctData = _downloadDataHelper.ReadAirQualityData2017("oct17");
            _2017NovData = _downloadDataHelper.ReadAirQualityData2017("nov17");
            _2017DicData = _downloadDataHelper.ReadAirQualityData2017("dic17");

            foreach (var item in _2017OctData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2017OctCollection.InsertOne(document);
            }

            foreach (var item in _2017NovData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2017NovCollection.InsertOne(document);
            }

            foreach (var item in _2017DicData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2017DicCollection.InsertOne(document);
            }
            */
            #endregion 2017

            #region 2018
            /*
            var _2018EneCollection = db.GetCollection<BsonDocument>("Ene18");
            var _2018FebCollection = db.GetCollection<BsonDocument>("Feb18");
            var _2018MarCollection = db.GetCollection<BsonDocument>("Mar18");
            var _2018AbrCollection = db.GetCollection<BsonDocument>("Abr18");
            var _2018MayCollection = db.GetCollection<BsonDocument>("May18");
            var _2018JunCollection = db.GetCollection<BsonDocument>("Jun18");
            var _2018JulCollection = db.GetCollection<BsonDocument>("Jul18");
            var _2018AgoCollection = db.GetCollection<BsonDocument>("Ago18");
            var _2018SepCollection = db.GetCollection<BsonDocument>("Sep18");
            var _2018OctCollection = db.GetCollection<BsonDocument>("Oct18");

            ObservableCollection<AirQualityData> _2018EneData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018FebData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018MarData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018AbrData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018MayData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018JunData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018JulData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018AgoData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018SepData = new ObservableCollection<AirQualityData>();
            ObservableCollection<AirQualityData> _2018OctData = new ObservableCollection<AirQualityData>();


            _2018EneData = _downloadDataHelper.ReadAirQualityData2017("ene18");
            _2018FebData = _downloadDataHelper.ReadAirQualityData2017("feb18");
            _2018MarData = _downloadDataHelper.ReadAirQualityData2017("mar18");
            _2018AbrData = _downloadDataHelper.ReadAirQualityData2017("abr18");
            _2018MayData = _downloadDataHelper.ReadAirQualityData2017("may18");
            _2018JunData = _downloadDataHelper.ReadAirQualityData2017("jun18");
            _2018JulData = _downloadDataHelper.ReadAirQualityData2017("jul18");
            _2018AgoData = _downloadDataHelper.ReadAirQualityData2017("ago18");
            _2018SepData = _downloadDataHelper.ReadAirQualityData2017("sep18");
            _2018OctData = _downloadDataHelper.ReadAirQualityData2017("oct18");


            var i = 0;
            foreach (var item in _2018EneData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018EneCollection.InsertOne(document);
                i = i + 1;
            }

            i = 0;
            foreach (var item in _2018FebData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018FebCollection.InsertOne(document);
                i = i + 1;
            }

            i = 0;
            foreach (var item in _2018MarData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018MarCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018AbrData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018AbrCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018MayData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018MayCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018JunData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018JunCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018JulData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018JulCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018AgoData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018AgoCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018SepData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018SepCollection.InsertOne(document);
                i = i + 1;
            }
            i = 0;
            foreach (var item in _2018OctData)
            {
                var _jsonItem = JsonConvert.SerializeObject(item);
                var document = BsonSerializer.Deserialize<BsonDocument>(_jsonItem);

                _2018OctCollection.InsertOne(document);
                i = i + 1;
            }
            */
            #endregion 2018

            #endregion CREATE HISTORICAL DATA

        }

        public async Task GetDataFiltered()
        {
            MongoClient client = MongoDBConnection();
            IMongoDatabase db = client.GetDatabase("AirQualityMad");

            IMongoCollection<BsonDocument> month17 = db.GetCollection<BsonDocument>("Oct17");
            IMongoCollection<BsonDocument> month18 = db.GetCollection<BsonDocument>("Oct18");

            int dayInt = DateTime.Today.Day + 1;
            string dayN = dayInt.ToString();

            if (dayN.Length == 1)
            {
                dayN = "0" + dayN;
            }

            BsonElement[] elems = { new BsonElement("Station", "28079004"), new BsonElement("Magnitude", "08"), new BsonElement("Day", dayN) };
            var filter2 = new BsonDocument(elems);

            BsonDocument p17 = new BsonDocument();
            BsonDocument p18 = new BsonDocument();
            await month17.Find(filter2).ForEachAsync(document => p17 = document);
            await month18.Find(filter2).ForEachAsync(document => p18 = document);

            var x = p17.Values;
            var y = p18.Values;

            AirQualityData data17 = new AirQualityData();
            AirQualityData data18 = new AirQualityData();

            data17.Station = x.ElementAt(1).ToString();
            data17.Magnitude = x.ElementAt(2).ToString();
            data17.Technique = x.ElementAt(3).ToString();
            data17.HourData = x.ElementAt(4).ToString();
            data17.Year = x.ElementAt(5).ToString();
            data17.Month = x.ElementAt(6).ToString();
            data17.Day = x.ElementAt(7).ToString();
            data17.HourMeasure = new ObservableCollection<string>();
            var _hourMeasure17 = x.ElementAt(8).AsBsonArray;

            foreach (var item in _hourMeasure17)
            {
                data17.HourMeasure.Add(item.ToString().Trim('{', '}'));
            }

            data18.Station = y.ElementAt(1).ToString();
            data18.Magnitude = y.ElementAt(2).ToString();
            data18.Technique = y.ElementAt(3).ToString();
            data18.HourData = y.ElementAt(4).ToString();
            data18.Year = y.ElementAt(5).ToString();
            data18.Month = y.ElementAt(6).ToString();
            data18.Day = y.ElementAt(7).ToString();
            data18.HourMeasure = new ObservableCollection<string>();
            var _hourMeasure18 = y.ElementAt(8).AsBsonArray;

            foreach (var item in _hourMeasure18)
            {
                data18.HourMeasure.Add(item.ToString().Trim('{', '}'));
            }

            AirQualityDataColletion = new ObservableCollection<AirQualityData>();

            AirQualityDataColletion.Add(data17);
            AirQualityDataColletion.Add(data18);
        }

        public ObservableCollection<AirQualityData> GetAirQualityDataFiltered()
        {
            GetDataFiltered().Wait();
            return AirQualityDataColletion;
        }

        #endregion AZURE COSMOS MONGO DB

    }
}
