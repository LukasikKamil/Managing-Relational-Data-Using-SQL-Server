namespace ALLinONE.Shared;

public interface IHasLastRefreshed
{
    DateTimeOffset LastRefreshed { get; set; }
}
