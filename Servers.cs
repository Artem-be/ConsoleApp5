using System;
using System.Collections.Generic;
using System.Linq;

public class Servers { 

    private static readonly Servers _instance = new Servers();
    private readonly HashSet<string> _servers;


    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance => _instance;

    public bool AddServer(string serverAddress)
    {
        // Проверка на корректность и добавление сервера 
        if ((serverAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
             serverAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) &&
            _servers.Add(serverAddress)) // HashSet.Add возвращает false, если элемент уже существует 
        {
            return true;
        }
        return false;
    }

    public List<string> GetHttpServers() =>
        _servers.Where(server => server.StartsWith("http://", StringComparison.OrdinalIgnoreCase)).ToList();

    public List<string> GetHttpsServers() =>
        _servers.Where(server => server.StartsWith("https://", StringComparison.OrdinalIgnoreCase)).ToList();
}