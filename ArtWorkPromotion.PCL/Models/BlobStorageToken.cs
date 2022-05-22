using System;
namespace ArtWorkPromotion.PCL.Models
{
	public class BlobStorageToken
	{
		public BlobStorageToken()
		{
		}

		public string Token { get; set; }
		public DateTime ExpiresOn { get; set; }
	}
}

