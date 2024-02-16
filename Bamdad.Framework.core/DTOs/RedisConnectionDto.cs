namespace Bamdad.Framework.core.DTOs;
public class RedisConnectionDto
{
    public RedisConnectionEndpointsDto Endpoints { get; set; }
    public string Password { get; set; }
    public int Database { get; set; }
}
public class RedisConnectionEndpointsDto
{
    public string Host { get; set; }
    public int Port { get; set; }
}
