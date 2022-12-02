using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CountryMongoDemo.Models
{

    [BsonIgnoreExtraElements]
    public class CountryModel
	{
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId _id { get; set; }
        //[BsonElement("Name")]
		public Name? name { get; set;}
		public List<string>? tld { get; set; }
		public string? cca2 { get; set; }
        public string? ccn3 { get; set; }
        public string? cca3 { get; set; }
        public string? cioc { get; set; }
        public bool independent { get; set; }
        public string? status { get; set; }
        public bool unMember { get; set; }
        public Currencies? currencies { get; set; }
        public Idd? idd { get; set; }
        public List<string>? capital { get; set; }
        public List<string>? altSpellings { get; set; }
        public string? region { get; set; }
        public string? subregion { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class Name
	{
		public string? common { get; set; }
		public string? official { get; set; }
		public NativeName? nativeName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class NativeName
    {
		[BsonElement("eng")]
		public Eng? eng { get; set; }
	}

    [BsonIgnoreExtraElements]
    public class Eng
	{
		public string? official { get; set; }
		public string? common { get; set; }
	}

    [BsonIgnoreExtraElements]
    public class Currencies
	{
        [BsonElement("ttd")]
        public TTD? TTD { get; set; }
	}

    [BsonIgnoreExtraElements]
    public class TTD
	{
			public string? name { get; set; }
			public string? symbol { get; set; }
	}
	
    public class Idd
    {
        public string? root { get; set; }
        public List<string>? suffixes { get; set; }

    }
}

