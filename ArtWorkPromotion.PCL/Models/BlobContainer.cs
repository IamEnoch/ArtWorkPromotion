using System;
namespace ArtWorkPromotion.PCL.Models
{
	public class BlobContainer
	{
		public BlobContainer()
		{
		}

        public BlobContainer(string conatinerName, string containerUrl,
            string connectionString, DateTime tokenExpiry)
        {
            ConatinerName = conatinerName;
            ContainerUrl = containerUrl;
            ConnectionString = connectionString;
            TokenExpiry = tokenExpiry;
        }

        public string ConatinerName { get; set; }
        public string ContainerUrl { get; set; }
        public string ConnectionString { get; set; }
        public DateTime TokenExpiry { get; set; }
    }
}

