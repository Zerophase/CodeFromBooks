namespace CacheModel
{
	public interface ILease
	{
		bool IsExpired { get; }
		void Renew();
	}
}