using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Xml.Linq;

namespace OhceKata.Test;

public class OhceShould {
    [SetUp]
    public void Setup() {
        
    }

    [TestCase("ohce Pedro", "Pedro")]
    [TestCase("ohce Maria", "Maria")]
    [TestCase("ohce Pepe", "Pepe")]
    [TestCase("ohce Juan", "Juan")]
    public void give_greetings_to_user(string command, string name) {
        //Given;
        
        //When
        var console = new MockConsole();
        new Ohce(console).Start(command);
        
        //Then
        Assert.AreEqual( $"¡Buenos días {name}!", console.LastText);
    }
}

public interface IConsole {
    void Write(string message);
}

public class MockConsole : IConsole {
    public string LastText { get; private set; }

    public void Write(string message) {
        LastText = message;
    }
}

public class Ohce {
    private readonly IConsole _console;

    public Ohce(IConsole console) {
        _console = console;
    }

    public void Start(string command)
    {

        var arguments = command.Split(" ");
        if (arguments[0] == "ohce")
        {
            _console.Write($"¡Buenos días {arguments[1]}!");
        }
        
    }
}