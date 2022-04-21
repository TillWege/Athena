using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Athena
{
	public class Database
	{
		private MongoClient _DBClient;

		public Database(String pServername, String pUsername, String pPassword, int pPort = 27017)
		{
			var ConnectionString = String.Format("mongodb://{0}:{1}", pServername, pPort);


			_DBClient = new MongoClient(ConnectionString);
		}

		public void Test()
		{
			var dbs = _DBClient.GetDatabase("Athena");
			Console.WriteLine(dbs);
		}
	}
}

